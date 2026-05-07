using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.TokensPacket)]
public record TokensPacket(Guid CorrelationId, TokenModel AccessToken, TokenModel RefreshToken) : SuccessfulResponse(CorrelationId);