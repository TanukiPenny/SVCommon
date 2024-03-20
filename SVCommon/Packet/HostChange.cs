using MessagePack;

namespace SVCommon.Packet;

[MessagePackObject]
public class HostChange
{
    [Key(0)]
    public string Nick { get; set; }
}