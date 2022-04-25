namespace HWU_Discord_Bot.CommandManager;
public class Command
{

}
public class BaseCommand
{
    public BaseCommand(string cmd, string? description, bool exutable, Action<string[]>? action)
    {
        Cmd = cmd;
        Description = description;
        Executable = exutable;
        Action = action;
    }
    public BaseCommand(string cmd, string? description, Action<string[]>? action) : this(cmd, description, true, action) { }
    public BaseCommand(string cmd) : this(cmd, null, false, null) { }
    public string Cmd { get; set; }
    public string? Description { get; set; }
    public bool Executable { get; set; }    
    public Action<string[]>? Action { get; set; }
    public void Execute(params string[] args) => Action.Invoke(args);
} 