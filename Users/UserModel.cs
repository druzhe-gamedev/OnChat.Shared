namespace OnChat.Shared.Users;

public record UserModel(Guid UserId, string Username, byte[] PublicKey);