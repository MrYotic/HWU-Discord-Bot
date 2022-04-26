global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using Discord;
global using Discord.API;
global using Discord.Net;
global using Discord.WebSocket;
global using Discord.Commands;
global using HWU_Discord_Bot;
global using static HWU_Discord_Bot.Wrapper;
global using HWU_Discord_Bot.Commands;
global using HWU_Discord_Bot.CommandManager;
global using HWU_Discord_Bot.Handles;
using HWU_Discord_Bot.Handles;

public class Program
{
    public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
    public async Task MainAsync()
    {
        var token = "OTY3OTM0OTA5MzQxNjU1MDQw.YmXhoQ.Oy5OOFNLso7wOKvQWpXP7A9FEQw";
        bot = new DiscordSocketClient();
        bot.Log += Log;
        await bot.LoginAsync(TokenType.Bot, token);
        await bot.StartAsync();

        commandService = new CommandService();
        commandHandler = new CommandHandler();
        discord = new HWU_Discord_Bot.Discord();
        cfg = new Config();
        await commandHandler.InstallCommandsAsync();

        commands = Command.Instance;

        Thread.Sleep(10000);
        Thread.Sleep(int.MaxValue);
    }
    private Task Log(LogMessage msg)
    {
        Console.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "]" + msg.ToString().Remove(0, 8));
        return Task.CompletedTask;
    }

}