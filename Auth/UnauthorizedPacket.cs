using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.UnauthorizedPacket)]
public record UnauthorizedPacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);