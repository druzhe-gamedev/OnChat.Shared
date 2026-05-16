using OnChat.Protocol.Packets;

namespace OnChat.Shared.Users;

[PacketId(PacketId.GetUserModelPacket)]
public record GetUserModelPacket(Guid CorrelationId, Guid UserId) : BasePacket(CorrelationId);