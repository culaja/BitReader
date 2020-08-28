using System.IO;
using BitStreams;
using FluentAssertions;
using Xunit;

namespace BitStreamsTests
{
    public class BitReaderTests
    {
        [Fact]
        public void Test1()
        {
            var bitReader = new BitReader(new MemoryStream(new byte[] { 0xFF, 0xFF, 0xFF }));

            bitReader.Read(3).Value.Should().Be(7);
            bitReader.Read(3).Value.Should().Be(7);
            bitReader.Read(3).Value.Should().Be(7);
            bitReader.Read(3).Value.Should().Be(7);
            bitReader.Read(3).Value.Should().Be(7);
            bitReader.Read(3).Value.Should().Be(7);
            bitReader.Read(3).Value.Should().Be(7);
            bitReader.Read(3).Value.Should().Be(7);
            bitReader.Read(3).HasValue.Should().BeFalse();
        }
    }
}