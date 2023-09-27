using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public class Declination : VkxRow
    {
        public override RowType Type => RowType.Declination;
        public ulong Time { get; protected set; }
        public Single DeclinationOffsetRadians { get; protected set; }
        public Int32 Latitude { get; protected set; } 
        public Int32 Longitude { get; protected set; }

        public Declination(Stream stream) : base(stream)
        {
            Time = ReadULong();
            DeclinationOffsetRadians = ReadSingle();
            Latitude = ReadInt();
            Longitude = ReadInt();
        }

    }
}
