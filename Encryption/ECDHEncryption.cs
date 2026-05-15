using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace OnChat.Shared.Encryption;

// ReSharper disable once InconsistentNaming
public static class ECDHEncryption
{
    public static EncryptedMessage EncryptMessage(byte[] recipientKey, string message)
    {
        using ECDiffieHellman senderEcdh = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);
        byte[] ephemeralPublicKey = senderEcdh.ExportSubjectPublicKeyInfo();

        using ECDiffieHellman recipientEcdh = ECDiffieHellman.Create();
        recipientEcdh.ImportSubjectPublicKeyInfo(recipientKey, out _);
        ECDiffieHellmanPublicKey recipientPublicKey = recipientEcdh.PublicKey;

        byte[] sharedSecret = senderEcdh.DeriveKeyFromHash(recipientPublicKey, HashAlgorithmName.SHA256);
        byte[] encryptionKey = DeriveEncryptionKey(sharedSecret);

        byte[] nonce = RandomNumberGenerator.GetBytes(12);

        using AesGcm aes = new (encryptionKey);
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        byte[] ciphertext = new byte[messageBytes.Length];
        byte[] tag = new byte[16];

        aes.Encrypt(nonce, messageBytes, ciphertext, tag);

        return new EncryptedMessage(ephemeralPublicKey, nonce, ciphertext, tag, DateTimeOffset.Now);
    }
    
    public static string DecryptMessage(EncryptedMessage message, byte[] recipientPrivateKey)
    {
        using ECDiffieHellman recipientEcdh = ECDiffieHellman.Create();
        recipientEcdh.ImportPkcs8PrivateKey(recipientPrivateKey, out _);

        using ECDiffieHellman senderEcdh = ECDiffieHellman.Create();
        senderEcdh.ImportSubjectPublicKeyInfo(message.EphemeralPublicKey, out _);
        ECDiffieHellmanPublicKey senderPublicKey = senderEcdh.PublicKey;

        byte[] sharedSecret = recipientEcdh.DeriveKeyFromHash(senderPublicKey, HashAlgorithmName.SHA256);
        byte[] encryptionKey = DeriveEncryptionKey(sharedSecret);

        using AesGcm aes = new(encryptionKey);
        byte[] plainText = new byte[message.Ciphertext.Length];
        aes.Decrypt(message.Nonce, message.Ciphertext, message.Tag, plainText);
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