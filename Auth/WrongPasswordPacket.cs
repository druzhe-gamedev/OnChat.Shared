using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.WrongPasswordPacket)]
public record WrongPasswordPacket(Guid CorrelationId, string Description) : FailureResponse(CorrelationId, Description);