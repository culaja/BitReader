using System.IO;
using BitStreams;
using FluentAssertions;
using Xunit;
// ReSharper disable PossibleInvalidOperationException

namespace BitStreamsTests
{
    public class BitReaderTests
    {
        [Fact]
        public void Test1()
        {
            var stream = new MemoryStream();
            using (var bitWriter = new BitWriter(stream))
            {
                bitWriter.Write(1, 3);
                bitWriter.Write(2, 3);
                bitWriter.Write(3, 3);
                bitWriter.Write(4, 3);
                bitWriter.Write(5, 3);
                bitWriter.Write(6, 3);
                bitWriter.Write(7, 3);
                bitWriter.Write(1, 3);
            }

            stream.Seek(0, SeekOrigin.Begin);
            
            var bitReader = new BitReader(stream);

            bitReader.Read(3).Value.Should().Be(1);
            bitReader.Read(3).Value.Should().Be(2);
            bitReader.Read(3).Value.Should().Be(3);
            bitReader.Read(3).Value.Should().Be(4);
            bitReader.Read(3).Value.Should().Be(5);
            bitReader.Read(3).Value.Should().Be(6);
            bitReader.Read(3).Value.Should().Be(7);
            bitReader.Read(3).Value.Should().Be(1);
            bitReader.Read(3).HasValue.Should().BeFalse();
        }
    }
}