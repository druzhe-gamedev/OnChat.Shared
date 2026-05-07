namespace OnChat.Shared.Auth;

public record TokenModel(string Token, DateTimeOffset ExpiresAt);