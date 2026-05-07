using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.WrongLoginPacket)]
public record WrongLoginPacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);