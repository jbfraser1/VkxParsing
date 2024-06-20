namespace Fraser.VkxData.Row;

public class Depth : VkxRow
{
    public override RowType Type => RowType.Depth;
    public ulong Time { get; protected set; }
    public float DepthMeters { get; protected set; }

    public Depth(Stream stream) : base(stream)
    {
        Time = ReadULong();
        DepthMeters = ReadSingle();
    }
}
