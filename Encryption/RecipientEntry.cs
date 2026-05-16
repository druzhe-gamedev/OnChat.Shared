namespace OnChat.Shared.Encryption;

public record RecipientEntry(Guid UserId, RecipientWrappedKey WrappedKey);