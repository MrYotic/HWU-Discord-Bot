namespace HWU_Discord_Bot;
public class Discord
{
    public void SendMessage(string msg, ulong idChannel) => (bot.GetChannel(idChannel) as IMessageChannel).SendMessageAsync(msg);
}