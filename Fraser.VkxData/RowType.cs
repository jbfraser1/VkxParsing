using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData
{
    public enum RowType
    {
        PageHeader = 0xff,
        PageTerminator = 0xfe,
        PositionVelocityOrientation = 0x02,
        Declination = 0x03,
        RaceTimerEvent = 0x04,
        LinePosition = 0x05,
        ShiftAngle = 0x06,
        DeviceConfiguration = 0x08,
        Wind = 0x0a,
        SpeedThroughWater = 0x0b,
        Depth = 0x0c,
        Temperature = 0x10,
        Load = 0x0f,

        Internal01 = 0x01,
        Internal07 = 0x07,
        Internal0E = 0x0e,
        Internal20= 0x20,

    }
}
