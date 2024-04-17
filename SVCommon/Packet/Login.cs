// PB, MB, JP start
using MessagePack;

namespace SVCommon.Packet;

[MessagePackObject]
public class Login
{
    [Key(0)]
    public string Nick { get; set; }
    
    public override string ToString()
    {
        return $"Login - [Nick: {Nick}]";
    }
}
// PB MB, JP end