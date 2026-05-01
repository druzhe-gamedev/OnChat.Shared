using OnChat.Protocol;

namespace OnChat.Shared;

[PacketId(PacketId.MessagePacket)]
public class MessagePacket
{
    public string UserId { get; set; }
    public string Message { get; set; }
}