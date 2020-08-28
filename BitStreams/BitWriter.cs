using System;
using System.IO;

namespace BitStreams
{
    public sealed class BitWriter
    {
        private const int BitsInUlong = sizeof(ulong) * 8;
        private const int BitsInByte = sizeof(byte) * 8;
        
        private readonly Stream _stream;

        private ulong _register;
        private int _registerPosition;

        public BitWriter(Stream stream)
        {
            _stream = stream;
        }

        public void Write(ulong value, int numberOfBits)
        {
        }
    }
}