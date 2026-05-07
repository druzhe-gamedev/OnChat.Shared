using OnChat.Protocol;

namespace OnChat.Shared.Messages;

[PacketId(PacketId.SendMessagePacket)]
public record SendMessagePacket(Guid CorrelationId, string Token, string ReceiverId, string Message) : AuthenticatedPacket(CorrelationId, Token);