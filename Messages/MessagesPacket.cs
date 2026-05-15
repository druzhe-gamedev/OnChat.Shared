using OnChat.Protocol;
using OnChat.Protocol.Packets;
using OnChat.Shared.Encryption;

namespace OnChat.Shared.Messages;

[PacketId(PacketId.MessagesPacket)]
public record MessagesPacket(Guid CorrelationId, EncryptedMessage[] Messages) : SuccessfulPacket(CorrelationId);