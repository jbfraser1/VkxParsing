namespace Fraser.VkxData.Row;

public class Internal20 : VkxRow
{
    public override RowType Type => RowType.Internal0E;

    public Internal20(Stream stream) : base(stream)
    {
        // skip forward
        stream.Seek(13, SeekOrigin.Current);
    }
}
