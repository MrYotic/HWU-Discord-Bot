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
using HWU_Discord_Bot.Handles;

bot = new DiscordSocketClient();
var token = "vY3zSP0pWVT5dsBIqHqeq1w7ZaoOldFH";
await bot.LoginAsync(TokenType.Bot, token);
await bot.StartAsync();

commandService = new CommandService();
commandHandler = new CommandHandler();
await commandHandler.InstallCommandsAsync();

commands = new CommandCollection() {
    Commands = new List<BaseCommand>
    {
        new BaseCommand("ping", "Get a response from the bot.", new((string[] args) =>
        {

        }))
    }
};