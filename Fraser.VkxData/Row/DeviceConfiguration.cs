using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public class DeviceConfiguration : VkxRow
    {
        public override RowType Type => RowType.DeviceConfiguration;
        public uint ConfigurationStates { get; protected set; }
        public byte LoggingRateHertz { get; protected set; }

        public DeviceConfiguration(Stream stream) : base(stream)
        {
            // skip 8 bytes
            ReadULong();
            ConfigurationStates = ReadUInt();
            LoggingRateHertz = ReadByte();
        }
    }

    public enum ConfigurationStateOptions
    {
        FixedToFrame = 1,
    }

}
