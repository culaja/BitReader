using System.IO;

namespace BitStreams
{
    internal static class StreamExtensions
    {
        public static byte? ReadByteOrNone(this Stream stream)
        {
            var result = stream.ReadByte();
            if (result == -1)
            {
                return default;
            }

            return (byte) result;
        }
            
    }
}