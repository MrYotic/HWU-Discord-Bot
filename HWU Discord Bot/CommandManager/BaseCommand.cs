namespace HWU_Discord_Bot.CommandManager;
public class BaseCommand
{
    public BaseCommand(string cmd, string? description, bool exutable, Action<MessageData, string[]>? action, int argCount)
    {
        Cmd = cmd;
        Description = description;
        Executable = exutable;
        Action = action;
        ArgumentCount = argCount;
    }
    public BaseCommand(string cmd, string? description, Action<MessageData, string[]>? action, int argCount) : this(cmd, description, true, action, argCount) { }
    public BaseCommand(string cmd) : this(cmd, null, false, null, 0) { }
    public int Complexity { get => Cmd.Split(' ').Length + ArgumentCount; }
    public string Cmd { get; set; }
    public string? Description { get; set; }
    public bool Executable { get; set; }
    public int ArgumentCount { get; set; }
    public Action<MessageData, string[]>? Action { get; set; }
    public void Execute(MessageData msg, params string[] args) => Action?.Invoke(msg, args);
}