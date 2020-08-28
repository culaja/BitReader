using System;
using System.IO;

namespace BitStreams
{
    public sealed class BitReader
    {
        private const int BitsInUlong = sizeof(ulong) * 8;
        private const int BitsInByte = sizeof(byte) * 8;
        
        private readonly Stream _stream;

        private ulong _register;
        private int _registerPosition;
        

        public BitReader(Stream stream)
        {
            _stream = stream;
        }

        public ulong? Read(int numberOfBits)
        {
            if (numberOfBits > BitsInUlong) throw new NotSupportedException();
            
            while (_registerPosition < numberOfBits)
            {
                var byteOrNone = _stream.ReadByteOrNone();
                if (byteOrNone == default) return default;

                _register |= (ulong) (byteOrNone.Value << _registerPosition);
                _registerPosition += BitsInByte;
            }

            var result = _register & ulong.MaxValue >> (BitsInUlong - numberOfBits);
            
            _register >>= numberOfBits;
            _registerPosition -= numberOfBits;
            
            return result;
        }
    }
}