using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public class Internal01 : VkxRow
    {
        public override RowType Type => RowType.Internal01;

        public Internal01(Stream stream) : base(stream)
        {
            // skip forward 32 bytes
            stream.Seek(32, SeekOrigin.Current);

        }

    }
}
