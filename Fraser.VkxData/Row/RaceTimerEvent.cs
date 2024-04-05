namespace Fraser.VkxData.Row;

public class RaceTimerEvent : VkxRow
{
    public override RowType Type => RowType.RaceTimerEvent;
    public ulong Time { get; protected set; }
    public TimerEvent EventType { get; protected set; }
    public Int32 TimerValue { get; protected set; }

    public RaceTimerEvent(Stream stream) : base(stream)
    {
        Time = ReadULong();
        EventType = (TimerEvent)ReadByte();
        TimerValue = ReadInt();
    }
}

public enum TimerEvent
{
    RESET = 0,
    START = 1,
    SYNC = 2,
    RACE_START = 3,
    RACE_END = 4,
}
