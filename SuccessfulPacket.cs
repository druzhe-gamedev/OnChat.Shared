using OnChat.Protocol.Packets;

namespace OnChat.Shared;

[PacketId(PacketId.SuccessfulPacket)]
public record SuccessfulPacket(Guid CorrelationId, string? Description = "") : SuccessfulResponse(CorrelationId, Description);