using OnChat.Protocol;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.RegistrationFailure)]
public record RegistrationFailureResponse(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);