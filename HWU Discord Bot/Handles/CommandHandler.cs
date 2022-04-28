using System.Reflection;

namespace HWU_Discord_Bot.Handles;
public class CommandHandler
{
    public async Task InstallCommandsAsync()
    {
        bot.MessageReceived += HandleCommandAsync;
        await commandService.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
    }
    private SocketUserMessage socketMsg;
    private async Task HandleCommandAsync(SocketMessage socMsg)
    {
        socketMsg = socMsg as SocketUserMessage;
        if (socketMsg == null) return;
        MessageData msg = new MessageData(socMsg);
        string text = msg.Text;
        if (!text.StartsWith(cfg.Prefix))
            return;
        text = text.Substring(cfg.Prefix.Length).TrimStart();
        BaseCommand? com = IsCmd(text);
        if(com != null)
        {
            com.Execute(msg, text.Split(" ").Reverse().Take(com.ArgumentCount).ToArray());
        }
    }   
    private BaseCommand IsCmd(string msg)
    {
        string[] args = msg.ToLower().Split(' ');
        CommandCollection cmd = commands;
        if (cmd.Count != 0)
            for (int i = 0; i < cmd.Count; i++)
            {
                BaseCommand com = cmd.Commands[i];
                if (com.Complexity == args.Length)
                {
                    if (com.Cmd == string.Join(' ', args.Take(args.Length - com.ArgumentCount)))
                    {
                        if (com.ArgumentCount == args.Length - 1)
                            return com;
                    }
                }      
            }
        return null;
    }
}