using HWU_Discord_Bot.CommandManager;

namespace HWU_Discord_Bot.Commands;
public class CommandCollection
{
    public BaseCommand this[string cmd]
    {
        get => Commands.Find(z => z.Cmd == cmd);
    }
    public BaseCommand this[int index]
    {
        get => Commands[index];
    }
    public List<BaseCommand> Commands = new List<BaseCommand>();
    public bool HasCmd(string cmd) => Commands.Find(z => z.Cmd == cmd) != null;
    public List<BaseCommand> GetCmds(string cmd) => Commands.FindAll(z => z.Cmd == cmd);
    public int Count { get => Commands.Count; }
}