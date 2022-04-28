global using static HWU_Discord_Bot.CommandManager.Command.CommandModule;
using HWU_Discord_Bot.Exceptions;

namespace HWU_Discord_Bot.CommandManager;
public partial class Command
{
    public enum CommandModule
    {
        Help, LolRiTTeR, HWU
    }
    public static CommandModule? GetCommandModuleByName(string name)
    {
        string[] names = Enum.GetNames(typeof(CommandModule));
        string[] lowcaseNames = names.Select(x => x.ToLower()).ToArray();
        int index = lowcaseNames.ToList().FindIndex(x => x == name.ToLower());
        if (index == -1)
            return null;
        return (CommandModule)Enum.Parse(typeof(CommandModule), names[index]);
    }
    public static CommandModule GetCommandModuleByName(MessageData msg, string name)
    {
        CommandModule? module = GetCommandModuleByName(name);
        if (module == null)
            throw new CommandModuleNotFoundException(msg, name);
        return (CommandModule)module;
    }
    public static Dictionary<CommandModule, string> ModuleDescription = new()
    {
        { Help, "Help in understand the bot" },
        { LolRiTTeR, "LolRiTTeR bot commands" },
        { HWU, "Teams specially for your favorite Comrades <3" },
    };
}
