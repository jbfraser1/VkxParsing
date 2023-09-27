using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public class Internal07 : VkxRow
    {
        public override RowType Type => RowType.Internal07;

        public Internal07(Stream stream) : base(stream)
        {
            // skip forward
            stream.Seek(12, SeekOrigin.Current);

        }

    }
}
