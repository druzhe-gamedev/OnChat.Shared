using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

[PacketId(PacketId.RegistrationSuccess)]
public class RegistrationSuccessResponse : ISuccessfulResponse
{
    public Guid CorrelationId { get; set; }
    public string Description { get; set; }
}