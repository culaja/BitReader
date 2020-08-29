using System.IO;
using System.Linq;
using BitStreams;
using FluentAssertions;
using Xunit;
// ReSharper disable PossibleInvalidOperationException

namespace BitStreamsTests
{
    public sealed class BitReaderAndWriterPerformanceTests
    {
        private static readonly byte[] Buffer = Enumerable.Repeat((byte)0xAA, 100000000).ToArray();
        
        [Theory]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        [InlineData(10000000)]
        [InlineData(100000000)]
        public void read_multiple_shorts_from_standard_buffer(int numberOfReads)
        {
            for (var i = 0; i < numberOfReads; ++i)
            {
                Buffer[i].Should().Be(0xAA);
            }
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        [InlineData(10000000)]
        [InlineData(100000000)]
        public void read_bits_from_buffer(int numberOfReads)
        {
            var bitReader = new BitReader(new MemoryStream(Buffer));
            for (var i = 0; i < numberOfReads; ++i)
            {
                bitReader.Read(2).Value.Should().Be(0x02);
            }
        }
    }
}