using MessagePack;
using SVCommon.Packet;

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
                    var msg = MessagePackSerializer.Deserialize<BasicMessage>(bytes, out bytesRead);
                    OnBasicMessage(conn, msg);
                    break;
                case MessageType.Ping:
                    OnPing(conn);
                    break;
                case MessageType.Login:
                    var login = MessagePackSerializer.Deserialize<Login>(bytes, out bytesRead);
                    OnLogin(conn, login);
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
    
    public virtual void OnBasicMessage(TConnection conn, BasicMessage msg) {}
    public virtual void OnPing(TConnection conn) {}
    public virtual void OnLogin(TConnection conn, Login login) {}
    public virtual void OnSerializationException(MessagePackSerializationException exception, int packetID) {}
    public virtual void OnPacketHandlerException(Exception exception, int packetID) {}
    public virtual void OnByteLengthMismatch(TConnection conn, int readBytes, int totalBytes) {}
}