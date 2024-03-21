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
                case MessageType.DisconnectMessage:
                    var disconnect = MessagePackSerializer.Deserialize<DisconnectMessage>(bytes, out bytesRead);
                    OnDisconnectMessage(conn, disconnect);
                    break;
                case MessageType.UserJoin:
                    var join = MessagePackSerializer.Deserialize<UserJoin>(bytes, out bytesRead);
                    OnUserJoin(conn, join);
                    break;
                case MessageType.UserLeave:
                    var leave = MessagePackSerializer.Deserialize<UserLeave>(bytes, out bytesRead);
                    OnUserLeave(conn, leave);
                    break;
                case MessageType.HostChange:
                    var hostChange = MessagePackSerializer.Deserialize<HostChange>(bytes, out bytesRead);
                    OnHostChange(conn, hostChange);
                    break;
                case MessageType.LoginResponse:
                    var loginResponse = MessagePackSerializer.Deserialize<LoginResponse>(bytes, out bytesRead);
                    OnLoginResponse(conn, loginResponse);
                    break;
                case MessageType.NewMedia:
                    var newMedia = MessagePackSerializer.Deserialize<NewMedia>(bytes, out bytesRead);
                    OnNewMedia(conn, newMedia);
                    break;
                case MessageType.TimeSync:
                    var timeSync = MessagePackSerializer.Deserialize<TimeSync>(bytes, out bytesRead);
                    OnTimeSync(conn, timeSync);
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
    public virtual void OnNewMedia(TConnection conn, NewMedia newMedia) {}
    public virtual void OnTimeSync(TConnection conn, TimeSync timeSync) {}
    public virtual void OnLoginResponse(TConnection conn, LoginResponse loginResponse) {}
    public virtual void OnDisconnectMessage(TConnection conn, DisconnectMessage disconnectMessageisconnectMessage) {}
    public virtual void OnHostChange(TConnection conn, HostChange hostChange) {}
    public virtual void OnUserJoin(TConnection conn, UserJoin userJoin) {}
    public virtual void OnUserLeave(TConnection conn, UserLeave userLeave) {}
    public virtual void OnSerializationException(MessagePackSerializationException exception, int packetID) {}
    public virtual void OnPacketHandlerException(Exception exception, int packetID) {}
    public virtual void OnByteLengthMismatch(TConnection conn, int readBytes, int totalBytes) {}
}