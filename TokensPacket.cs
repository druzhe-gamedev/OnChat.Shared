using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

[PacketId(PacketId.TokensPacket)]
public class TokensPacket : IPacket
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}