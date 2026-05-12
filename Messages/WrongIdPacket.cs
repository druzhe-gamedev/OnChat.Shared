using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Messages;

[PacketId(PacketId.WrongIdPacket)]
public record WrongIdPacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);
