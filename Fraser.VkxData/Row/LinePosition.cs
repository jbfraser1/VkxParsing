using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public class LinePosition : VkxRow
    {
        public override RowType Type => RowType.LinePosition;
        public ulong Time { get; protected set; }
        public LineEndType LineEnd { get; protected set; }
        public Int32 Latitude { get; protected set; }
        public Int32 Longitude { get; protected set; }

        public LinePosition(Stream stream) : base(stream)
        {
            Time = ReadULong();
            LineEnd = (LineEndType)ReadByte();
            Latitude = ReadInt();
            Longitude = ReadInt();
        }
    }

    public enum LineEndType
    {
        PinLeft = 0,
        BoatRight = 1,
    }
}
