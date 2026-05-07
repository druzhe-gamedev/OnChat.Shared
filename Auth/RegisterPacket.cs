using OnChat.Protocol;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.RegistrationPacket)]
public record RegistrationPacket(Guid CorrelationId, string Username, string Email, string Password, short Age) : BasePacket(CorrelationId);