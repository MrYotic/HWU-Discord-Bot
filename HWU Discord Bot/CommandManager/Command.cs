using HWU_Discord_Bot.Exceptions;
using LolRiTTeRBotAPI.DataTypes;
using static HWU_Discord_Bot.Helper;

namespace HWU_Discord_Bot.CommandManager;
public partial class Command
{
    //public static List<string> GetCommandsList() => commands.Commands.Where(z=>!z.SecretCommand).Select(z => $"**{z.Cmd}** {""+(z.ArgumentCount != 0 ? (string.Join(' ', z.Arguments.Select(x => $"[{x}]"))) : "")} - {z.Description}").ToList();
    public static EmbedBuilder GetEmbedCommandList(List<BaseCommand> commands)
    {
        EmbedBuilder eb = new()
        {
            Title = "a command list.",
        };
        commands.Where(z => !z.SecretCommand).ToList().ForEach(z => eb.AddField($"**{z.Cmd}** {"" + (z.ArgumentCount != 0 ? (string.Join(' ', z.Arguments.Select(x => $"[{x}]"))) : "")}", z.Description, false));
        return eb;
    }
    public static EmbedBuilder GetEmbedCommandList(List<BaseCommand> commands, CommandModule module)
    {
        EmbedBuilder eb = new()
        {
            Title = "a command list.",
        };
        commands.Where(z => !z.SecretCommand && z.Module == module).ToList().ForEach(z => eb.AddField($"**{z.Cmd}** {"" + (z.ArgumentCount != 0 ? (string.Join(' ', z.Arguments.Select(x => $"[{x}]"))) : "")}", z.Description, false));
        return eb;
    }
    private static EmbedFieldBuilder FEmbed(string name, dynamic value, bool inline) => new() { Name = name, IsInline = inline, Value = value.ToString()};
    private static EmbedFieldBuilder FEmbed(string name, dynamic value) => new() { Name = name, IsInline = true, Value = value.ToString() };
    delegate void cmdDel(MessageData msg, string[] args);
    public static CommandCollection Instance { get =>
new()
{
    Commands = new()
    {
        #region Help
        new("help", "Show a list of commands.", Help, new((msg, args) =>
        {
            discord.SendEmbed(GetEmbedCommandList(commands.Commands), msg.ChannelID);
        })),
        new("help", "Show a list of commands of module.", Help, new((msg, args) =>
        {
            CommandModule module = GetCommandModuleByName(msg, args[0]);
            discord.SendEmbed(GetEmbedCommandList(commands.Commands.Where(z => z.Module == module).ToList()), msg.ChannelID);
        }), new() { "module" }),
        new("modules", "Show a list of all command modules.", Help, new((msg, args) =>
        {
            discord.SendEmbed(
                new EmbedBuilder()
                {
                    Title = "All Command Modules.",
                    Fields = Enum.GetValues(typeof(CommandModule)).Cast<CommandModule>().Select(z => new EmbedFieldBuilder()
                    {
                        Name = z.ToString(),
                        Value = ModuleDescription[z],
                    }).ToList(),
                }, msg.ChannelID);
        })),
        new("ping", "Get a response from the bot.", Help, new((msg, args) =>
        {
            discord.SendMessage("pong", msg.ChannelID);
        })) { SecretCommand = true },
        new("pong", "Get a response from the bot.", Help, new((msg, args) =>
        {
            discord.SendMessage("ping", msg.ChannelID);
        })) { SecretCommand = true },
        #endregion
        #region LolRiTTeR
        new("queue", "Show length of both queues.", LolRiTTeR, new((msg, args) =>
        {
            Queue queue = api.GetQueue();
            discord.SendEmbed(new()
            {
                Title = "Server Queue:",
                Fields = new()
                {
                    FEmbed("Standard", queue.QueueLength),
                    FEmbed("Priority", queue.PrioQueueLength),
                }
            }, msg.ChannelID);
        })),
        new("stats", "Show player statistic.", LolRiTTeR, new((msg, args) =>
        {
            Stats stats = api.GetStats(args[0]);
            if (!stats.IsExists) throw new PlayerNotFoundException(msg, args[0]);
            discord.SendEmbed(new()
            {
                Title = $"\'{args[0]}\' statistics:",
                Fields = new()
                {
                    FEmbed("Kills", stats.Kills),
                    FEmbed("Deaths", stats.Deaths),
                    FEmbed("KD", Math.Round(stats.Kills / (double)stats.Deaths, 2)),
                    FEmbed("Joins", stats.Joins),
                },
                Footer = new EmbedFooterBuilder()
                {
                    Text = $"uuid: {stats.Uuid.Replace("-", "")}",
                }
            }, msg.ChannelID);
        }), new() { "username" }),
        new("sstats", "Show player statistic by all account.", LolRiTTeR, new((msg, args) =>
        {
            Stats stats = api.GetStackStats(args[0]);
            if (!stats.IsExists) throw new PlayerNotFoundException(msg, args[0]);
            discord.SendEmbed(new()
            {
                Title = $"\'{args[0]}\' statistics:",
                Fields = new()
                {
                    FEmbed("Kills", stats.Kills),
                    FEmbed("Deaths", stats.Deaths),
                    FEmbed("KD", Math.Round(stats.Kills / (double)stats.Deaths, 2)),
                    FEmbed("Joins", stats.Joins),
                },
                Footer = new EmbedFooterBuilder()
                {
                    Text = $"uuid: {stats.Uuid.Replace("-", "")}",
                }
            }, msg.ChannelID);
        }), new() { "username" }),
        new("accounts", "Show all past username accounts.", LolRiTTeR, new((msg, args) =>
        {
            Stats[] rawStats = api.GetStatsAllAccount(args[0]);
            List<Stats> stats = rawStats.Where(z => z.IsExists).ToList();
            List<EmbedFieldBuilder> fields = new();
            stats.ForEach(z =>
            {
                fields.Add(FEmbed(DeleteFormatting(z.UserName), $"{z.Joins}Joins  {(z.Kills > 0 ? z.Kills + "Kills  " : "")}{(z.Deaths > 0 ? z.Deaths + "Deaths  " : "")}{(z.Kills == 0 ? "" : (Math.Round(z.Kills / (double)z.Deaths, 2) + "KD"))}", false));
            });
            discord.SendEmbed(new()
            {
                Title = $"All past '{args[0]}' nicknames statistics: ",
                Description = $"{args[0]} has {rawStats.Length} nicknames of which {stats.Count} was on 2b2t.",
                Fields = fields,
            }, msg.ChannelID);
        }), new() { "username" }),
        new("lastkill", "Show last kill certain player.", LolRiTTeR, new((msg, args) =>
        {
            LastKill kill = api.GetLastKill(args[0]);
            //if (!kill.IsExists) throw new PlayerNotFoundException(msg, args[0]);
            discord.SendEmbed(new()
            {
                Title = $"Last kill by {kill.UserName}:",
                Fields = new()
                {
                    FEmbed("Message: ", kill.Message, true),
                    FEmbed("Passed: ", TimeSpanToString(AgoTime(kill.Time)), true),
                    FEmbed("Time: ", kill.Time.ToString(), true),
                }
            }, msg.ChannelID);
        }), new() { "username"}),
        new("lastdeath", "Show last death certain player.", LolRiTTeR, new((msg, args) =>
        {
            LastDeath death = api.GetLastDeath(args[0]);
            //if (!death.) throw new PlayerNotFoundException(msg, args[0]);
            discord.SendEmbed(new()
            {
                Title = $"Last {death.UserName} death:",
                Fields = new()
                {
                    FEmbed("Message: ", death.Message, true),
                    FEmbed("Passed: ", TimeSpanToString(AgoTime(death.Time)), true),
                    FEmbed("Time: ", death.Time.ToString(), true),
                }
            }, msg.ChannelID);
        }), new() { "username" }),
        new("seen", "Show time when the player was last on the server.", LolRiTTeR, new((msg, args) =>
        {
            Seen seen = api.GetSeen(args[0]);
            if(!seen.IsExists) throw new PlayerNotFoundException(msg, args[0]);
            discord.SendEmbed(new()
            {
                Title = $"Last {seen.Name} seen:",
                Fields = new()
                {
                    FEmbed("Passed: ", TimeSpanToString(AgoTime(seen.Time)), true),
                    FEmbed("Time: ", seen.Time.ToString(), true),
                }
            }, msg.ChannelID);
        }), new() { "username" }),
        #endregion
        #region HWU
        new("comrades", "Show all followed comrades.", HWU, new((msg, args) =>
        {
            List<Comrade> c = cfg.FollowComrades;
            discord.SendEmbed(new()
            {
                Title = "Comrades:",
                Fields = cfg.FollowComrades.OrderBy(z => !z.Online).Select(z => FEmbed(z.UserName, z.Online ? "Online" : TimeSpanToString(AgoTime(z.LastSeen)) + " ago", false)).ToList(),
            }, msg.ChannelID);
        })),
        #endregion
    },
};}}