using LolRiTTeRBotAPI.DataTypes;

namespace HWU_Discord_Bot.HWUSide;
public class ServerSpectator
{
    private Thread updater;
    public bool Working { get => updater != null && updater.IsAlive; }
    public void StartSpectate(TimeSpan delay)
    {
        (updater = new Thread(() => {
            while (true)
            {
                Update();
                Thread.Sleep(delay);
            }
        })).Start();
    }
    private void Update()
    {
        Tab tab = api.GetTab();
        List<string> players = tab.Players.Select(x => x.UserName.ToLower()).ToList();
        for(int i = 0; i < cfg.FollowComrades.Count; i++)
        {
            if (players.Contains(cfg.FollowComrades[i].UserName.ToLower()))
            {
                cfg.FollowComrades[i].LastSeen = DateTime.Now;
                cfg.FollowComrades[i].Online = true;
            } else cfg.FollowComrades[i].Online = false;
        }
    }
}