using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

[PacketId(PacketId.RegistrationPacket)]
public class RegistrationPacket : BasePacket
{
    public string Nickname { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}