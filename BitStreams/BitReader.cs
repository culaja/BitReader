using System.IO;

namespace BitStreams
{
    public sealed class BitReader
    {
        private readonly Stream _stream;

        public BitReader(Stream stream)
        {
            _stream = stream;
        }

        public T Read<T>(int numberOfBits) where T : struct
        {
            return default;
        }
    }
}