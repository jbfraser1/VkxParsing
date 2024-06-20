namespace Fraser.VkxData.Row;

public class ShiftAngle : VkxRow
{
    public override RowType Type => RowType.ShiftAngle;
    public ulong Time { get; protected set; }
    public Tack Tack { get; protected set; }
    public ManualOrAuto ManualOrAuto { get; protected set; }
    public float TrueHeadingDegrees { get; protected set; }
    public float SpeedOverGroundKnots { get; protected set; }

    public ShiftAngle(Stream stream) : base(stream)
    {
        Time = ReadULong();
        Tack = (Tack)ReadByte();
        ManualOrAuto = (ManualOrAuto)ReadByte();
        TrueHeadingDegrees = ReadSingle();
        SpeedOverGroundKnots = ReadSingle();
    }
}

public enum Tack
{
    Starboard = 0,
    Port = 1,
}

public enum ManualOrAuto
{
    Auto = 0,
    Manual = 1,
}
