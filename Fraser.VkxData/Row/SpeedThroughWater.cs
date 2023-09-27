using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public class SpeedThroughWater : VkxRow
    {
        public override RowType Type => RowType.SpeedThroughWater;
        public ulong Time { get; protected set; }
        public float SpeedOfWaterForwardMetersPerSecond { get; protected set; }
        public float SpeedOfWaterHorizontalMetersPerSecond { get; protected set; }

        public SpeedThroughWater(Stream stream) : base(stream)
        {
            // skip 8 bytes
            Time = ReadULong();
            SpeedOfWaterForwardMetersPerSecond = ReadSingle();
            SpeedOfWaterHorizontalMetersPerSecond = ReadSingle();
        }
    }

}
