using OnChat.Protocol;

namespace OnChat.Shared;

[PacketId(PacketId.TokensPacket)]
public record TokensPacket(Guid CorrelationId, string AccessToken, string RefreshToken) : BasePacket(CorrelationId);