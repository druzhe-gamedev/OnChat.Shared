namespace OnChat.Shared;

public interface IPacket
{
    PacketType PacketType { get; }
    void Serialize(BinaryWriter writer);
    void Deserialize(BinaryReader reader);
}