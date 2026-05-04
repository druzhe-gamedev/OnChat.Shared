using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

[PacketId(PacketId.SendMessagePacket)]
public class SendMessagePacket : AuthenticatedPacket
{
    public string ReceiverId { get; set; }
    public string Message { get; set; }
}