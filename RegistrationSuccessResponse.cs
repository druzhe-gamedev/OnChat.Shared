using OnChat.Protocol;
using OnChat.Protocol.Packets;

namespace OnChat.Shared;

[PacketId(PacketId.RegistrationSuccess)]
public class RegistrationSuccessResponse : SuccessResponse;