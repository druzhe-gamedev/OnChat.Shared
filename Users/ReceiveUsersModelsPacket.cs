using OnChat.Protocol.Packets;

namespace OnChat.Shared.Users;

[PacketId(PacketId.ReceiveUsersModelsPacket)]
public record ReceiveUsersModelsPacket(Guid CorrelationId, UserModel[] UsersModels) : SuccessfulResponse(CorrelationId);