using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public class Temperature : VkxRow
    {
        public override RowType Type => RowType.Temperature;
        public ulong Time { get; protected set; }
        public float TemperatureDegrees { get; protected set; }

        public Temperature(Stream stream) : base(stream)
        {
            // skip 8 bytes
            Time = ReadULong();
            TemperatureDegrees = ReadSingle();
        }
    }

}
