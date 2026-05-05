using OnChat.Protocol.Packets;

namespace OnChat.Shared;

public abstract record BasePacket(Guid CorrelationId) : IPacket
{
    public Guid CorrelationId { get; set; } = CorrelationId;
}

public abstract record Response(Guid CorrelationId, string Description) : BasePacket(CorrelationId);

public abstract record SuccessResponse(Guid CorrelationId, string Description) : Response(CorrelationId, Description), ISuccessfulResponse
{
    public string Description { get; set; } = Description;
}

public abstract record FailureResponse(Guid CorrelationId, string Description) : Response(CorrelationId, Description), IFailureResponse
{
    public string Description { get; set; } = Description;
}