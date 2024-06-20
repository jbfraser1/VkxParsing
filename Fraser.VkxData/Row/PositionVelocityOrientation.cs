namespace Fraser.VkxData.Row;

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

    public override string ToString()
    {
        var (x, y, z) = ToDegrees();
        var tempTime = DateTime.UnixEpoch.AddMilliseconds(Time);


        return $"{tempTime}:  Lat: {Latitude / 10000000.0} Long: {Longitude / 10000000.0} SoG: {SpeedOverGroundMetersPerSecond:0.00} CoG: {CourseOverGroundRadians * 180 / Math.PI:0.00} {x:0.00}, {y:0.00}, {z:0.00}";
    }

    Tuple<double, double, double> ToDegrees()
    {
        double x, y, z;
        
        // roll (x-axis rotation)
        double sinr_cosp = 2 * (QuaternionW * QuaternionX + QuaternionY * QuaternionZ);
        double cosr_cosp = 1 - 2 * (QuaternionX * QuaternionX + QuaternionY * QuaternionY);
        x = Math.Atan2(sinr_cosp, cosr_cosp);

        // pitch (y-axis rotation)
        double sinp = Math.Sqrt(1 + 2 * (QuaternionW * QuaternionY - QuaternionX * QuaternionZ));
        double cosp = Math.Sqrt(1 - 2 * (QuaternionW * QuaternionY - QuaternionX * QuaternionZ));
        y = 2 * Math.Atan2(sinp, cosp) - Math.PI / 2;

        // yaw (z-axis rotation)
        double siny_cosp = 2 * (QuaternionW * QuaternionZ + QuaternionX * QuaternionY);
        double cosy_cosp = 1 - 2 * (QuaternionY * QuaternionY + QuaternionZ * QuaternionZ);
        z = Math.Atan2(siny_cosp, cosy_cosp);

        return new Tuple<double, double, double>(x *180 / Math.PI, y * 180 / Math.PI, z * 180 / Math.PI);
        
    }
}
