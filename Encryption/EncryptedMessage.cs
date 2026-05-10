namespace OnChat.Shared.Encryption;

public record EncryptedMessage(byte[] EphemeralPublicKey, byte[] Nonce, byte[] Ciphertext, byte[] Tag);