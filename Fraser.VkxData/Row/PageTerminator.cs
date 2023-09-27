using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public class PageTerminator : VkxRow
    {
        public override RowType Type => RowType.PageTerminator;
        public ushort PreviousPageLength { get; protected set; }

        public PageTerminator(Stream stream) : base(stream)
        {
            PreviousPageLength = ReadUShort();
        }

    }
}
