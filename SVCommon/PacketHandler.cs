using MessagePack;

namespace SVCommon;

public class PacketHandler<TConnection>
{
    public void HandlePacket(TConnection conn, byte[] bytes, int packetId)
    {
        int bytesRead = 0;
        try
        {
            switch ((MessageType)packetId)
            {
                case MessageType.BasicMessage:
                    break;
                case MessageType.Ping:
                    break;
                default:
                    throw new Exception("Packet not registered in PacketHandler!");
            }
        }
        catch (MessagePackSerializationException e)
        {
            OnSerializationException(e, packetId);
        }
        catch (Exception e)
        {
            OnPacketHandlerException(e, packetId);
        }

        if (bytes.Length > bytesRead)
        {
            OnByteLengthMismatch(conn, bytesRead, bytes.Length);
        }
    }
    
    public virtual void OnBasicMessage(TConnection conn) {}
    public virtual void OnPing(TConnection conn) {}
    public virtual void OnSerializationException(MessagePackSerializationException exception, int packetID) {}
    public virtual void OnPacketHandlerException(Exception exception, int packetID) {}
    public virtual void OnByteLengthMismatch(TConnection conn, int readBytes, int totalBytes) {}
}