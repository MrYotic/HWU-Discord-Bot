using static HWU_Discord_Bot.CommandManager.Command;

namespace HWU_Discord_Bot.CommandManager;
public class BaseCommand
{
    public BaseCommand(string cmd, string? description, CommandModule module, Action<MessageData, string[]>? action, List<string> args)
    {
        Cmd = cmd;
        Description = description;
        Action = action;
        Arguments = args;
        Module = module;
    }
    public BaseCommand(string cmd, string? description, CommandModule module, Action<MessageData, string[]>? action) : this(cmd, description, module, action, new List<string> { }) { }
    public int Complexity { get => Cmd.Split(' ').Length + ArgumentCount; }
    public string Cmd { get; set; }
    public string? Description { get; set; }
    public List<string> Arguments { get; set; }
    public int ArgumentCount { get => Arguments.Count; }
    public bool SecretCommand { get; set; }
    public CommandModule Module { get; private set; }
    public Action<MessageData, string[]>? Action { get; set; }
    public void Execute(MessageData msg, params string[] args) => Action?.Invoke(msg, args);
}