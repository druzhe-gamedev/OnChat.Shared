using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Auth;

[PacketId(PacketId.TokensRotationPacket)]
public record TokensRotationPacket(Guid CorrelationId, string RefreshToken) : BasePacket(CorrelationId);