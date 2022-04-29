using System.Drawing;
using Image = System.Drawing.Image;
using Color = System.Drawing.Color;

namespace HWU_Discord_Bot.Map;
public class MapManager
{
    public Image Map { get; private set; }
    private Graphics g;
    private Size size;
    private float blockScale;
    public MapManager(Size imageMapSize, int sqRadius)
    {
        Map = new Bitmap(imageMapSize.Width, imageMapSize.Height);
        size = imageMapSize;
        g = Graphics.FromImage(Map);
        blockScale = imageMapSize.Width / (float)sqRadius;
    }
    public void DrawNetherrack() => FillPixelPolygon(Color.DarkRed, (0, 0), (0, Map.Height), (Map.Width, Map.Height), (Map.Width, 0));
    public void DrawDugNetherrack() =>  FillPixelPolygon(Color.DarkOrange, (0, 0), (0, Map.Height), (Map.Width, Map.Height), (Map.Width, 0));
    public void DrawHighways()
    {
        cfg.HighwayList.NetherDugHighway.Roads.Roads.ToList().ForEach(z => FillBlockPolygon(Color.DarkOrange, (0, 0), (0, 5), (z.length), ()));
    }
    private void FillBlockPolygon(Color color, params (float x, float y)[] points) => g.FillPolygon(new SolidBrush(color), points.Select(z => new PointF(z.x * blockScale + size, z.y * blockScale)).ToArray());
    private void FillPixelPolygon(Color color, params (float x, float y)[] points) => g.FillPolygon(new SolidBrush(color), points.Select(z => new PointF(z.x, z.y)).ToArray());
}