using OnChat.Protocol;

namespace OnChat.Shared;

[PacketId(PacketId.RegistrationSuccess)]
public record RegistrationSuccessfulResponse(Guid CorrelationId, string Description) : SuccessfulResponse(CorrelationId, Description);