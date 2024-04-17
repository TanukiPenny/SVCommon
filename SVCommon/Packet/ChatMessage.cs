// MB start
using MessagePack;

namespace SVCommon.Packet;


[MessagePackObject]
public class ChatMessage
{
    [Key(0)]
    public string Nick { get; set; }
    
    [Key(1)]
    public string Message { get; set; }


}
// MB end