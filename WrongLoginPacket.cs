using OnChat.Protocol;

namespace OnChat.Shared;

[PacketId(PacketId.WrongLoginPacket)]
public record WrongLoginPacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);