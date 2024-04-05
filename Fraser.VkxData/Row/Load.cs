namespace Fraser.VkxData.Row;

public class Load : VkxRow
{
    public override RowType Type => RowType.Load;
    public ulong Time { get; protected set; }
    public string SensorShortName { get; protected set; }
    public float LoadAmount { get; protected set; }

    public Load(Stream stream) : base(stream)
    {
        // skip 8 bytes
        Time = ReadULong();
        SensorShortName = ReadCharacters(4);
        LoadAmount = ReadSingle();
    }
}
