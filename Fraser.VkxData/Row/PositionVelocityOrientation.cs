using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public class PositionVelocityOrientation : VkxRow
    {
        public override RowType Type => RowType.PositionVelocityOrientation;

        public ulong Time { get; protected set; }
        public Int32 Latitude { get; protected set; }
        public Int32 Longitude { get; protected set; }
        public Single SpeedOverGroundMetersPerSecond { get; protected set; }
        public Single CourseOverGroundRadians { get; protected set; }
        public Single AltitudeMeters { get; protected set; }
        public Single QuaternionW { get; protected set; }
        public Single QuaternionX { get; protected set; }
        public Single QuaternionY { get; protected set; } 
        public Single QuaternionZ { get; protected set; }

        public PositionVelocityOrientation(Stream stream) : base(stream)
        {
            Time = ReadULong();
            Latitude = ReadInt();
            Longitude = ReadInt();
            SpeedOverGroundMetersPerSecond = ReadSingle();
            CourseOverGroundRadians = ReadSingle();
            AltitudeMeters = ReadSingle();
            QuaternionW = ReadSingle();
            QuaternionX = ReadSingle();
            QuaternionY = ReadSingle();
            QuaternionZ = ReadSingle();
        }
    }
}
