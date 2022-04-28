namespace HWU_Discord_Bot.Exceptions;
public class CommandModuleNotFoundException : Exception
{
    public CommandModuleNotFoundException(MessageData msg, string moduleName) =>
        discord.SendEmbed(new EmbedBuilder()
        {
            Fields = new List<EmbedFieldBuilder> { new EmbedFieldBuilder(){
                Name = $"Exception: Module \'{moduleName}\' not found.",
                Value = $"To write \"{cfg.Prefix}modules\" for see all exsisted modules.",
                IsInline = true,
            } }
        }, msg.ChannelID);        
}
