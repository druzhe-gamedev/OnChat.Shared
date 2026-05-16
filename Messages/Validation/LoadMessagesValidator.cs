using OnChat.Shared.Validation;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Messages.Validation;

public class LoadMessagesValidator : ValidatorBase<LoadMessagesPacket, PacketId>
{
    public readonly MinMaxConstraint<int> QuantityConstraint = new(new MinMaxValue<int>(0, 255));
    public readonly MinMaxConstraint<int> PageConstraint = new(new MinMaxValue<int>(0, int.MaxValue));
    
    public LoadMessagesValidator()
    {
        AddConstraint(packet => packet.Quantity, QuantityConstraint, PacketId.WrongLimitsPacket);
        AddConstraint(packet => packet.Page, PageConstraint, PacketId.WrongLimitsPacket);
    }
}