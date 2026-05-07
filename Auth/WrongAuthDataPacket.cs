using OnChat.Protocol;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.WrongAuthDataPacket)]
public record WrongAuthDataPacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);