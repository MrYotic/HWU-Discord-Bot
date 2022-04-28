namespace HWU_Discord_Bot.HWUSide;
public class Comrade
{
    public Comrade(string username, DateTime lastSeen)
    {
        UserName = username;
        LastSeen = lastSeen;
    }
    public string UserName { get; set; }
    public DateTime LastSeen { get; set; }
    public bool Online = false;
}