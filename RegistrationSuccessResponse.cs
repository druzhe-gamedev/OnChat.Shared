using OnChat.Protocol.Packets;

namespace OnChat.Shared;

public class RegistrationSuccessResponse : ISuccessfulResponse
{
    public Guid CorrelationId { get; set; }
    public string Description { get; }
}