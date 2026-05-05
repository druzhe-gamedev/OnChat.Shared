using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

public abstract class BasePacket : IPacket
{
    public Guid CorrelationId { get; set; }
}

public abstract class Response : BasePacket
{
    public string Desciption { get; set; }
}

public abstract class SuccessResponse : Response, ISuccessfulResponse
{
    public string Description { get; set; }
}

public abstract class FailureResponse : Response, IFailureResponse
{
    public string Description { get; set; }
}