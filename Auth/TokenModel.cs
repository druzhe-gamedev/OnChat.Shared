namespace OnChat.Shared.Auth;

public record TokenModel(string token, DateTimeOffset expiresAt);