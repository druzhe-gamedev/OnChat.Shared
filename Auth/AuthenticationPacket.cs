using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.AuthenticationPacket)]
public record AuthenticationPacket(Guid CorrelationId, string Login, string Password) : BasePacket(CorrelationId);