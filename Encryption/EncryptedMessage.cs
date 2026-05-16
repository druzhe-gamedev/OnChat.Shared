namespace OnChat.Shared.Encryption;

public record EncryptedMessage(RecipientEntry[] RecipientEntries, byte[] EphemeralPublicKey, byte[] Nonce, byte[] Ciphertext, byte[] Tag, DateTimeOffset? TimeStamp);