// PB, MB, JP start
using MessagePack;

namespace SVCommon.Packet;

[MessagePackObject]
public class TimeSync
{
    [Key(0)]
    public long Time { get; set; }
}
// PB, MB, JP end