namespace OnChat.Shared;

public abstract record AuthenticatedPacket(Guid CorrelationId, string Token) : BasePacket(CorrelationId);