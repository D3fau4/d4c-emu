namespace ndas.Internal;

public struct DeviceAuthTokenMessage
{
    public int expires_in { get; set; }
    public string device_auth_token { get; set; }
}