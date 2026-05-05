using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

[PacketId(PacketId.RegistrationPacket)]
public class RegistrationPacket : BasePacket
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public short Age { get; set; }
}