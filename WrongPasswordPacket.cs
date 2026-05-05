using OnChat.Protocol;

namespace OnChat.Shared;

[PacketId(PacketId.WrongPasswordPacket)]
public record WrongPasswordPacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);