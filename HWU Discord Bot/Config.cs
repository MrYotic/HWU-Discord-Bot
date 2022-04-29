using HWU_Discord_Bot.HWUSide;
using HWU_Discord_Bot.Map;
using static Newtonsoft.Json.JsonConvert;
namespace HWU_Discord_Bot;
public class Config
{
    public void Load() => cfg = DeserializeObject<Config>(File.ReadAllText(Path));
    public void Save() => File.WriteAllText(Path, SerializeObject(cfg));
    public string Path { get; set; } = $@"C:\Users\{Environment.UserName}\HWUDiscordCfg.json";
    public string Prefix { get; set; } = "=>";
    public List<Comrade> FollowComrades { get; set; }
    public HighwayList HighwayList { get; set; }
}