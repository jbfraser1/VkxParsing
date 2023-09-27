using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public class Internal0E : VkxRow
    {
        public override RowType Type => RowType.Internal0E;

        public Internal0E(Stream stream) : base(stream)
        {
            // skip forward
            stream.Seek(16, SeekOrigin.Current);

        }

    }
}
