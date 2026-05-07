using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.RegistrationFailure)]
public record RegistrationFailureResponse(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);