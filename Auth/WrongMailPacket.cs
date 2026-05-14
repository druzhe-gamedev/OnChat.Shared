using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.WrongMailPacket)]
public record WrongMailPacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);