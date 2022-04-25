using HWU_Discord_Bot.CommandManager;

namespace HWU_Discord_Bot.Commands;
public class CommandCollection
{
    public List<BaseCommand> Commands = new List<BaseCommand>();
    public List<CommandCollection> CommandCollections = new List<CommandCollection>();
    public bool HasCmd(string cmd) => Commands.Find(z => z.Cmd == cmd) != null;
    //public bool HasCmdCol(string cmd) => Commands.Find(z => z.Cmd == cmd) != null;
}