using OnChat.Protocol.Packets;

namespace OnChat.Shared.Users;

[PacketId(PacketId.ReceiveUserModelPacket)]
public record ReceiveUserModelPacket(Guid CorrelationId, UserModel UserModel) : SuccessfulResponse(CorrelationId);