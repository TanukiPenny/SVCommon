using MessagePack;

namespace SVCommon.Packet;

[MessagePackObject]
public class BasicMessage
{
    [Key(0)]
    public string Message { get; set; }

    public override string ToString()
    {
        return $"BasicMessage - [Message: {Message}]";
    }
}