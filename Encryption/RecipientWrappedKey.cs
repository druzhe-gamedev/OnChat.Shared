namespace OnChat.Shared.Encryption;

public record RecipientWrappedKey(byte[] Nonce, byte[] Ciphertext, byte[] Tag);