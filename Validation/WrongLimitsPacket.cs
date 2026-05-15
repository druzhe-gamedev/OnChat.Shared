using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Validation;

[PacketId(PacketId.WrongLimitsPacket)]
public record WrongLimitsPacket(Guid CorrelationId, string? Description = "") : FailureResponse(CorrelationId, Description);