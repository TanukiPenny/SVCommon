namespace SVCommon;

public enum MessageType
{
    BasicMessage = 1,
    Ping = 2,
    Login = 3,
    DisconnectMessage = 4,
    UserJoin = 5,
    UserLeave = 6,
    HostChange = 7,
    LoginResponse = 8,
    NewMedia = 9,
    TimeSync = 10,
}