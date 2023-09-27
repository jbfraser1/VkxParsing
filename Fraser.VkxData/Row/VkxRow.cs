using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraser.VkxData.Row
{
    public abstract class VkxRow
    {
        protected VkxRow(Stream s)
        {
            _stream = s;
        }
        public abstract RowType Type { get; }

        protected Stream _stream { get; set; }

        protected byte ReadByte()
        {
            Span<byte> bytes = stackalloc byte[1];
            _stream.ReadExactly(bytes);
            return bytes[0];
        }

        protected uint ReadUInt()
        {
            Span<byte> bytes = stackalloc byte[4];
            _stream.ReadExactly(bytes);
            return (uint)(bytes[0] | bytes[1] << 8 | bytes[2] << 16 | bytes[3] << 24);
        }

        protected int ReadInt()
        {
            Span<byte> bytes = stackalloc byte[4];
            _stream.ReadExactly(bytes);
            return (bytes[0] | bytes[1] << 8 | bytes[2] << 16 | bytes[3] << 24);
        }

        protected ulong ReadULong()
        {
            Span<byte> bytes = stackalloc byte[8];
            _stream.ReadExactly(bytes);
            return (ulong)bytes[0] | (ulong)bytes[1] << 8 | (ulong)bytes[2] << 16 | (ulong)bytes[3] << 24
                           | (ulong)bytes[4] << 32 | (ulong)bytes[5] << 40 | (ulong)bytes[6] << 48 | (ulong)bytes[7] << 56;
        }

        protected ushort ReadUShort()
        {
            Span<byte> bytes = stackalloc byte[2];
            _stream.ReadExactly(bytes);
            return (ushort)(bytes[0] | bytes[1] << 8);
        }

        protected Single ReadSingle()
        {
            Span<byte> bytes = stackalloc byte[4];
            _stream.ReadExactly(bytes);
            return BitConverter.ToSingle(bytes);
        }

        protected string ReadCharacters(int length)
        {
            Span<byte> bytes = stackalloc byte[length];
            _stream.ReadExactly(bytes);
            return Encoding.ASCII.GetString(bytes);
        }

    }
}
