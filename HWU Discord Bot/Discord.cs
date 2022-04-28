namespace HWU_Discord_Bot;
public class Discord
{
    public void SendMessage(string msg, ulong idChannel) => (bot.GetChannel(idChannel) as IMessageChannel).SendMessageAsync(msg);
    public void SendEmbed(EmbedBuilder msg, ulong idChannel)
    {
        msg.Color = Color.DarkRed;
        (bot.GetChannel(idChannel) as IMessageChannel).SendMessageAsync("", false, msg.Build()); ;
    }
}