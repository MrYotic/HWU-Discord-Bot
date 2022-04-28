using HWU_Discord_Bot.Commands;
using HWU_Discord_Bot.Handles;
using HWU_Discord_Bot.HWUSide;

namespace HWU_Discord_Bot;
public class Wrapper
{
    public static DiscordSocketClient bot;
    public static CommandService commandService;
    public static CommandHandler commandHandler;
    public static CommandCollection commands;
    public static Config cfg;
    public static Discord discord;
    public static LolRiTTeRBotAPI.API api;
    public static ServerSpectator spectator;
}