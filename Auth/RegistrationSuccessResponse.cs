using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.RegistrationSuccess)]
public record RegistrationSuccessfulResponse(Guid CorrelationId, string Description) : SuccessfulResponse(CorrelationId, Description);