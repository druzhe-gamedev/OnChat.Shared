namespace OnChat.Shared.Encryption;

[PacketId(PacketId.PublicKeyPacket)]
public record PublicKeyPacket(Guid CorrelationId, string Token, byte[] Value) : AuthenticatedPacket(CorrelationId, Token);