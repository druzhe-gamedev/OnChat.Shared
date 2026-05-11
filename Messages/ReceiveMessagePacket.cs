using OnChat.Protocol;
using OnChat.Protocol.Packets;
using OnChat.Shared.Encryption;

namespace OnChat.Shared.Messages;

[PacketId(PacketId.ReceiveMessagePacket)]
public record ReceiveMessagePacket(Guid CorrelationId, Guid SenderId, EncryptedMessage Message) : SuccessfulResponse(CorrelationId);