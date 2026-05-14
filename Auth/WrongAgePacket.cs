using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.WrongAgePacket)]
public record WrongAgePacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);