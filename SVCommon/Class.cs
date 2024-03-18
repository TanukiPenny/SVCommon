using MessagePack;

namespace SVCommon;

[MessagePackObject]
public class MessageResponse
{
    [Key(0)]
    public string Message { get; set; }

    public override string ToString()
    {
        return $"MessageResponse - [Message: {Message}]";
    }
}