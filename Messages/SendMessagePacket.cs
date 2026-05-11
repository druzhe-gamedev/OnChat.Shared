using OnChat.Protocol;
using OnChat.Protocol.Packets;
using OnChat.Shared.Encryption;

namespace OnChat.Shared.Messages;

[PacketId(PacketId.SendMessagePacket)]
public record SendMessagePacket(Guid CorrelationId, string Token, Guid ReceiverId, EncryptedMessage EncryptedMessage) : AuthenticatedPacket(CorrelationId, Token);