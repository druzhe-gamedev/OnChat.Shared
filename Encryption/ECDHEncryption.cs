using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace OnChat.Shared.Encryption;

// ReSharper disable once InconsistentNaming
public static class ECDHEncryption
{
    public static EncryptedMessage EncryptMessage(IEnumerable<(Guid, byte[])> recipients, string message)
    {
        using ECDiffieHellman ephemeralEcdh = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);
        byte[] ephemeralPublicKey = ephemeralEcdh.ExportSubjectPublicKeyInfo();

        byte[] messageKey = RandomNumberGenerator.GetBytes(32);
        
        byte[] nonce = RandomNumberGenerator.GetBytes(12);
        byte[] plaintext = Encoding.UTF8.GetBytes(message);
        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];

        using AesGcm aes = new(messageKey);
        aes.Encrypt(nonce, plaintext, ciphertext, tag);

        List<RecipientEntry> recipientsEntries = [];

        foreach ((Guid id, byte[] publicKey) in recipients)
        {
            using ECDiffieHellman recipientEcdh = ECDiffieHellman.Create();
            recipientEcdh.ImportSubjectPublicKeyInfo(publicKey, out _);
            ECDiffieHellmanPublicKey recipientPublicKey = recipientEcdh.PublicKey;
            
            byte[] wrappedNonce = RandomNumberGenerator.GetBytes(12);
            byte[] wrappedTag = new byte[16];
            byte[] wrappedMessageKey = new byte[messageKey.Length];

            byte[] sharedSecret = ephemeralEcdh.DeriveKeyFromHash(recipientPublicKey, HashAlgorithmName.SHA256);
            byte[] derivedKey = DeriveEncryptionKey(sharedSecret);
            
            using AesGcm wrapAes = new(derivedKey);
            wrapAes.Encrypt(wrappedNonce, messageKey, wrappedMessageKey, wrappedTag);

            recipientsEntries.Add(
                new RecipientEntry(id, new RecipientWrappedKey(wrappedNonce, wrappedMessageKey, wrappedTag))
            );
        }

        return new EncryptedMessage(
            recipientsEntries.ToArray(),
            ephemeralPublicKey,
            nonce,
            ciphertext,
            tag,
            DateTimeOffset.Now
        );
    }
    
    public static string DecryptMessage(EncryptedMessage message, Guid userId, byte[] recipientPrivateKey)
    {
         RecipientEntry? recipient = message.RecipientEntries.FirstOrDefault(recipient => recipient.UserId == userId);
        
        if (recipient == null)
            return "Not a recipient";
        
        using ECDiffieHellman recipientEcdh = ECDiffieHellman.Create();
        recipientEcdh.ImportPkcs8PrivateKey(recipientPrivateKey, out _);

        using ECDiffieHellman ephemeralEcdh = ECDiffieHellman.Create();
        ephemeralEcdh.ImportSubjectPublicKeyInfo(message.EphemeralPublicKey, out _);
        ECDiffieHellmanPublicKey ephemeralPublicKey = ephemeralEcdh.PublicKey;

        byte[] sharedSecret = recipientEcdh.DeriveKeyFromHash(ephemeralPublicKey, HashAlgorithmName.SHA256);
        byte[] encryptionKey = DeriveEncryptionKey(sharedSecret);

        byte[] messageKey = new byte[32];
        using AesCcm wrappedAes = new(encryptionKey);
        RecipientWrappedKey wrappedKey = recipient.WrappedKey;
        wrappedAes.Decrypt(wrappedKey.Nonce, wrappedKey.Ciphertext, wrappedKey.Tag, messageKey);
        
        using AesGcm messageAes = new(messageKey);
        byte[] plainText = new byte[message.Ciphertext.Length];
        messageAes.Decrypt(message.Nonce, message.Ciphertext, message.Tag, plainText);
        
        return Encoding.UTF8.GetString(plainText);
    }
    
    public static (byte[] publicKey, byte[] privateKey) GetKeys()
    {
        using ECDiffieHellman ecdh = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);

        byte[] publicKey = ecdh.ExportSubjectPublicKeyInfo();
        byte[] privateKey = ecdh.ExportPkcs8PrivateKey();

        return (publicKey, privateKey);
    }

    // todo salt
    private static byte[] DeriveEncryptionKey(byte[] sharedSecret) =>
        HKDF.DeriveKey(HashAlgorithmName.SHA256, sharedSecret, 32);
}