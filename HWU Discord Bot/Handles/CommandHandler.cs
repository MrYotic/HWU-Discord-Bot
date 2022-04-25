using System.Reflection;

namespace HWU_Discord_Bot.Handles;
public class CommandHandler
{
    public async Task InstallCommandsAsync()
    {
        bot.MessageReceived += HandleCommandAsync;
        await commandService.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
    }
    private SocketUserMessage msg;
    private async Task HandleCommandAsync(SocketMessage socMsg)
    {
        msg = socMsg as SocketUserMessage;
        if (msg == null) return;


    }
}