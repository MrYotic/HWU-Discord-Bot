namespace HWU_Discord_Bot;
public class MessageData
{
    public MessageData(string userName, ulong channelID, string text)
    {
        UserName = userName;
        ChannelID = channelID;
        Text = text;
    }
    public MessageData(SocketMessage message)
    {
        UserName = message.Author.Username;
        ChannelID = message.Channel.Id;
        Text = message.Content;
    }
    public string UserName { get; set; }
    public ulong ChannelID { get; set; }
    public string Text { get; set; }
}