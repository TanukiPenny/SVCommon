// PB, MB, JP start
using MessagePack;

namespace SVCommon.Packet;

[MessagePackObject]
public class UserLeave
{
    [Key(0)]
    public string Nick { get; set; }
}
// PB, MB, JP end