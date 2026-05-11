using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Messages;

[PacketId(PacketId.SendMessagePacket)]
public record SendMessagePacket(Guid CorrelationId, string Token, Guid ReceiverId, string Message) : AuthenticatedPacket(CorrelationId, Token);