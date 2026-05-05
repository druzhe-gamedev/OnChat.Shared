using OnChat.Protocol;

namespace OnChat.Shared;

[PacketId(PacketId.AuthenticationPacket)]
public record AuthenticationPacket(Guid CorrelationId, string Login, string Message) : BasePacket(CorrelationId);