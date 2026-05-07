using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.RegistrationPacket)]
public record RegistrationPacket(Guid CorrelationId, string Username, string Email, string Password, short Age) : BasePacket(CorrelationId);