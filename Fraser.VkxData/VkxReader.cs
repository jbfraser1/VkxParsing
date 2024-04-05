using System.Collections;
using System.ComponentModel;
using Fraser.VkxData.Row;

namespace Fraser.VkxData
{
    public class VkxReader : IEnumerable<VkxRow>
    {
        private Stream _stream;

        public VkxReader(string filePath)
        {
            _stream = new FileStream(
                filePath,
                new FileStreamOptions
                {
                    Access = FileAccess.Read,
                });
        }

        public VkxReader(Stream stream)
        {
            _stream = stream;
        }

        public async Task<VkxTrack> ReadTrack()
        {
            var track = new VkxTrack();
            while (_stream.Position < _stream.Length)
            {
                var row = ParseNextRow();
                if (row is PositionVelocityOrientation pvo)
                {
                    track.Add(pvo);
                }
            }

            return track;
        }

        public IEnumerator<VkxRow> GetEnumerator()
        {
            while (_stream.Position < _stream.Length)
            {
                yield return ParseNextRow();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private VkxRow ParseNextRow()
        {
            int temp = _stream.ReadByte();
            var rowType = (RowType)temp;
            switch (rowType)
            {
                case RowType.PageHeader:
                    return new PageHeader(_stream);
                case RowType.PageTerminator:
                    return new PageTerminator(_stream);
                case RowType.PositionVelocityOrientation:
                    return new PositionVelocityOrientation(_stream);
                case RowType.Declination:
                    return new Declination(_stream);
                case RowType.RaceTimerEvent:
                    return new RaceTimerEvent(_stream);
                case RowType.LinePosition:
                    return new LinePosition(_stream);
                case RowType.ShiftAngle:
                    return new ShiftAngle(_stream);
                case RowType.DeviceConfiguration:
                    return new DeviceConfiguration(_stream);
                case RowType.Wind:
                    return new Wind(_stream);
                case RowType.SpeedThroughWater:
                    return new SpeedThroughWater(_stream);
                case RowType.Depth:
                    return new Depth(_stream);
                case RowType.Temperature:
                    return new Temperature(_stream);
                case RowType.Load:
                    return new Load(_stream);
                case RowType.Internal01:
                    return new Internal01(_stream);
                case RowType.Internal07:
                    return new Internal07(_stream);
                case RowType.Internal0E:
                    return new Internal0E(_stream);
                case RowType.Internal20:
                    return new Internal20(_stream);

                default:
                    throw new NotImplementedException();
            }


        }
    }
}
