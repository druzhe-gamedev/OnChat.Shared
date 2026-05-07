using OnChat.Protocol;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.WrongPasswordPacket)]
public record WrongPasswordPacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);