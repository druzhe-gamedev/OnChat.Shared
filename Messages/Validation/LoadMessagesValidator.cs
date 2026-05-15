using OnChat.Shared.Validation;
using OnChat.Protocol.Packets;

namespace OnChat.Shared.Messages.Validation;

public class LoadMessagesValidator : ValidatorBase<LoadMessagesPacket, PacketId>
{
    public readonly MinMaxConstraint<byte> QuantityConstraint = new(new MinMaxValue<byte>(0, 255));
    
    public LoadMessagesValidator()
    {
        AddConstraint(packet => packet.Quantity, QuantityConstraint, PacketId.WrongLimitsPacket);
    }
}