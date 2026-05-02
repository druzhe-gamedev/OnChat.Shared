using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

[PacketId(PacketId.MessagePacket)]
public class MessagePacket : IPacket
{
    public string UserId { get; set; }
    public string Message { get; set; }
}