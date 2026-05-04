using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

public abstract class AuthenticatedPacket : IPacket
{
    public string Token { get; set; }
}