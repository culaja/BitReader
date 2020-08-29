using System;
using System.IO;

namespace BitStreams
{
    public sealed class BitWriter : IDisposable
    {
        private const int BitsInUlong = sizeof(ulong) * 8;
        private const int BitsInByte = sizeof(byte) * 8;
        
        private readonly Stream _stream;

        private ulong _register;
        private int _registerPosition = BitsInUlong;

        public BitWriter(Stream stream)
        {
            _stream = stream;
        }

        public void Write(ulong value, int numberOfBits)
        {
            if (numberOfBits > BitsInUlong - BitsInByte) throw new ArgumentOutOfRangeException();
            
            while (_registerPosition <= BitsInUlong - BitsInByte)
            {
                var byteToWrite = (byte)(_register >> BitsInUlong - BitsInByte);
                _stream.WriteByte(byteToWrite);
                _register <<= BitsInByte;
                _registerPosition += BitsInByte;
            }

            _registerPosition -= numberOfBits;
            _register |= value << _registerPosition;
        }

        public void Dispose()
        {
            while (_registerPosition < BitsInUlong)
            {
                var byteToWrite = (byte)(_register >> BitsInUlong - BitsInByte);
                _stream.WriteByte(byteToWrite);
                _register <<= BitsInByte;
                _registerPosition += BitsInByte;
            }
        }
    }
}