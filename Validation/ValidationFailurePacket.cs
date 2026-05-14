using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Validation;
[PacketId(PacketId.ValidationFailurePacket)]
public record ValidationFailurePacket(Guid CorrelationId, string? Description = "") : FailureResponse(CorrelationId, Description);