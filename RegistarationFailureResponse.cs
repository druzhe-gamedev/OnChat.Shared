using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

[PacketId(PacketId.RegistrationFailure)]
public class RegistarationFailureResponse : FailureResponse;