// PB, MB, JP start
using MessagePack;

namespace SVCommon.Packet;

[MessagePackObject]
public class DisconnectMessage
{
    [Key(0)]
    public string Message { get; set; }
}
// PB, MB, JP end