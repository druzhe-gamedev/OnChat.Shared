using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

public abstract class BasePacket : IPacket
{
    public Guid CorrelationId { get; set; }
}