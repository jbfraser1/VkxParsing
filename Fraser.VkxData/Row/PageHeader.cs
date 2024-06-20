namespace Fraser.VkxData.Row;

public class PageHeader : VkxRow
{
    public override RowType Type => RowType.PageHeader;
    public byte FormatVersion { get; protected set; }
    public Int64 InternalLogState { get; protected set; }

    public PageHeader(Stream stream) : base(stream)
    {
        FormatVersion = (byte)stream.ReadByte();
        Span<byte> bytes = stackalloc byte[6];
        stream.ReadExactly(bytes);
        InternalLogState = bytes[0] | bytes[1] << 8 | bytes[2] << 16 | bytes[3] << 24 | bytes[4] << 32 | bytes[5] << 40;
    }

}
