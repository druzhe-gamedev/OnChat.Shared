using OnChat.Protocol.Packets;

namespace OnChat.Shared.Users;

[PacketId(PacketId.GetUsersModelsPacket)]
public record GetUsersModelsPacket(Guid CorrelationId) : BasePacket(CorrelationId);