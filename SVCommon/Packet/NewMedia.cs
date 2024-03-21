using MessagePack;

namespace SVCommon.Packet;

[MessagePackObject]
public class NewMedia
{
    [Key(0)]
    public Uri Uri { get; set; }
}