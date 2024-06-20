namespace Fraser.VkxData.Row;

public class Wind : VkxRow
{
    public override RowType Type => RowType.Wind;
    public ulong Time { get; protected set; }
    public float WindDirectionDegrees { get; protected set; }
    public float WindSpeedMetersPerSecond { get; protected set; }

    public Wind(Stream stream) : base(stream)
    {
        Time = ReadULong();
        WindDirectionDegrees = ReadSingle();
        WindSpeedMetersPerSecond = ReadSingle();
    }
}
