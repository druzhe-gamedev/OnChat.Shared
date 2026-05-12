using OnChat.Protocol.Packets;

namespace OnChat.Shared.Users;

[PacketId(PacketId.ReceiverUsersModelsPacket)]
public record ReceiverUsersModelsPacket(Guid CorrelationId, UserModel[] UsersModels) : SuccessfulResponse(CorrelationId);