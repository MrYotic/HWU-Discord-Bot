using static HWU_Discord_Bot.Map.HighwayList;
using static HWU_Discord_Bot.Map.HighwayList.Rotation;
namespace HWU_Discord_Bot.Map;
public class HighwayList
{
    public enum Rotation
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest,
    }
    public NetherHighway NetherHighway { get; set; } = new NetherHighway();
    public NetherHighway NetherDugHighway { get; set; } = new NetherHighway();
}
public class NetherHighway
{
    public RoadArray Roads { get; set; } = new RoadArray();
    public RingArray Rings { get; set; } = new RingArray();
}
public class RoadArray 
{
    public (Rotation rotation, long length) this[Rotation rotation]
    {
        get => Roads.ToList().Find(z=>z.rotation==rotation);
        set => Roads[Roads.ToList().FindIndex(z => z.rotation == rotation)] = value;
    }
    public void AddLength(Rotation rotation, long length) => Roads[Roads.ToList().FindIndex(z => z.rotation == rotation)].length += length;
    public void SetLength(Rotation rotation, long length) => Roads[Roads.ToList().FindIndex(z => z.rotation == rotation)].length = length;
    private (Rotation rotation, long length)[] Roads = new (Rotation, long)[8] {
        (North, 0), (NorthEast, 0),
        (South, 0), (SouthEast, 0),
        (West, 0), (SouthWest, 0),
        (East, 0), (NorthWest, 0),
    };
}
public class RingArray 
{
    public Ring this[Rotation start, Rotation end]
    {
        get => Rings.ToList().Find(z => z.Start == start && z.End == end);
        set => Rings[Rings.ToList().FindIndex(z => z.Start == start && z.End == end)] = value;
    }
    public void AddLength(Rotation startRotation, Rotation endRotation, long coord, long length) => Rings[FindIndex(startRotation, endRotation, coord)].Length += length;
    public void SetLength(Rotation startRotation, Rotation endRotation, long coord, long length) => Rings[FindIndex(startRotation, endRotation, coord)].Length = length;
    private int FindIndex(Rotation startRotation, Rotation endRotation, long coord) => Rings.ToList().FindIndex(z => z.Start == startRotation && z.End == endRotation && GetDistance(z.Coord, coord) < 10);
    private long GetDistance(long x0, long x1) => (long)Math.Sqrt(Math.Pow(x0 - x1, 2));
    private List<Ring> Rings = new();
    public class Ring
    {
        public Ring(Rotation start, Rotation end, long coord, long length)
        {
            Start = start;
            End = end;
            Coord = coord;
            Length = length;
        }
        public Rotation Start { get; set; }
        public Rotation End { get; set; }
        public long Coord { get; set; }
        public long Length { get; set; }
    }
}