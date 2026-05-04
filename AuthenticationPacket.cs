using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

[PacketId(PacketId.AuthenticationPacket)]
public class AuthenticationPacket : IPacket
{
    public string Login { get; set; }
    public string Message { get; set; }
}