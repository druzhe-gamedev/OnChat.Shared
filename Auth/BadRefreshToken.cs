using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.BadRefreshTokenPacket)]
public record BadRefreshToken(Guid CorrelationId, string? Description) : FailureResponse(CorrelationId, Description);