using OnChat.Protocol;

namespace OnChat.Shared;

[PacketId(PacketId.AuthenticationSuccessfulPacket)]
public record AuthenticationSuccessfulPacket(Guid CorrelationId, string Description) : SuccessfulResponse(CorrelationId, Description);