using MessagePack;

namespace SVCommon.Packet;

[MessagePackObject]
public class UserJoin
{
    [Key(0)]
    public string Nick { get; set; }
}