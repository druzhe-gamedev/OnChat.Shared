namespace OnChat.Shared;

public class MessagePacket : IPacket
{
    public PacketType PacketType = PacketType.MessagePacket;
    public string UserId { get; set; }
    public string Message { get; set; }

    public void Serialize(BinaryWriter writer)
    {
        writer.Write(UserId);
        writer.Write(Message);
    }

    public void Deserialize(BinaryReader reader)
    {
        UserId = reader.ReadString();
        Message = reader.ReadString();
    }
}