using System.Drawing;
using Image = System.Drawing.Image;
using Color = System.Drawing.Color;

namespace HWU_Discord_Bot.Map;
public class MapManager
{
    public Image Map { get; private set; }
    public 
    private Graphics g;
    public MapManager(Size imageMapSize)
    {
        Map = new Bitmap(imageMapSize.Width + imageMapSize.Width / 4, imageMapSize.Height);
        g = Graphics.FromImage(Map);
    }
    public void DrawNetherrack() => g.FillPolygon(new SolidBrush(Color.DarkRed), new Point[] {new(0, 0), new (0, Map.Height), new(Map.Width, Map.Height), new(Map.Width, 0)});
    public void DrawDugNetherrack() => Console.Write("");

}