using MessagePack;

namespace SVCommon.Packet;

[MessagePackObject]
public class Play
{
    [Key(0)]
    public Uri Uri { get; set; }
}