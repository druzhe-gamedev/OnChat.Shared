using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Messages;

[PacketId(PacketId.LoadMessagesPacket)]
public record LoadMessagesPacket(Guid CorrelationId, string Token, Guid ChatParticipant, int Quantity, int Page) : AuthenticatedPacket(CorrelationId, Token);