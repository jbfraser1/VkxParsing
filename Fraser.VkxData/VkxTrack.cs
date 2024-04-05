using Fraser.VkxData.Row;

namespace Fraser.VkxData;

public class VkxTrack : IEnumerable<VkxPoint>
{
    private List<VkxPoint> _points = new List<VkxPoint>();

    public void Add(PositionVelocityOrientation position)
    {
        Add(new VkxPoint
        {
            Latitude = position.Latitude,
            Longitude = position.Longitude
        });
    }
    public void Add(VkxPoint point)
    {
        _points.Add(point);
    }

    public void Add(double latitude, double longitude)
    {
        _points.Add(new VkxPoint { Latitude = latitude, Longitude = longitude});
    }

    public IEnumerator<VkxPoint> GetEnumerator()
    {
        return _points.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
