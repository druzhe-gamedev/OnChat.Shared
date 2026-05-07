using OnChat.Protocol;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.TokensPacket)]
public record TokensPacket(Guid CorrelationId, TokenModel AccessToken, TokenModel RefreshToken) : SuccessfulResponse(CorrelationId);