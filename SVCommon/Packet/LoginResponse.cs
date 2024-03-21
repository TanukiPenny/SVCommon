using MessagePack;

namespace SVCommon.Packet;

[MessagePackObject]
public class LoginResponse
{
    [Key(0)] 
    public bool Success { get; set; }

    [Key(1)]
    public bool Host { get; set; }

}