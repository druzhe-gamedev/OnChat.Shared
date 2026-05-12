using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Messages;

[PacketId(PacketId.SendMessagePacket)]
public record WrongIdPacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);
