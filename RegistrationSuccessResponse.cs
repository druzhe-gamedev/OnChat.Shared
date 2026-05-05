using OnChat.Protocol;

namespace OnChat.Shared;

[PacketId(PacketId.RegistrationSuccess)]
public record RegistrationSuccessResponse(Guid CorrelationId, string Description) : SuccessResponse(CorrelationId, Description);