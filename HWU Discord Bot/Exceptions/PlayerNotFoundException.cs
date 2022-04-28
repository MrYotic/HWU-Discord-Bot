namespace HWU_Discord_Bot.Exceptions;
public class PlayerNotFoundException : Exception
{
    public PlayerNotFoundException(MessageData msg, string username) =>
    discord.SendEmbed(new EmbedBuilder()
    {
        Fields = new List<EmbedFieldBuilder> { new EmbedFieldBuilder(){
                Name = $"Exception: Player \'{username}\' not found.",
                Value = $"Maybe this player don`t join on 2b2t.",
                IsInline = true,
            } }
    }, msg.ChannelID);
}