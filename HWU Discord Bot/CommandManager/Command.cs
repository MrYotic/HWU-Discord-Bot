namespace HWU_Discord_Bot.CommandManager;
public class Command
{
    delegate void cmdDel(MessageData msg, string[] args);
    public static CommandCollection Instance { get =>
new()
{
    Commands = new()
    {
        new("ping", "Get a response from the bot.", new((MessageData msg, string[] args) =>
        {
            discord.SendMessage("pong", msg.ChannelID);
        }), 0),
        new("pong", "Get a response from the bot.", new((MessageData msg, string[] args) =>
        {
            discord.SendMessage("ping", msg.ChannelID);
        }), 0),
    },
};}}