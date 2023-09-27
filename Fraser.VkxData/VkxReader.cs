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
                case RowType.ShiftAngle:
                case RowType.DeviceConfiguration:
                case RowType.Wind:
                case RowType.SpeedThroughWater:
                case RowType.Depth:
                case RowType.Temperature:
                case RowType.Load:
                    throw new NotImplementedException();
                case RowType.Internal01:
                    return new Internal01(_stream);
                case RowType.Internal07:
                    return new Internal07(_stream);
                case RowType.Internal0E:
                    return new Internal0E(_stream);

                default:
                    throw new NotImplementedException();
            }


        }
    }
}
