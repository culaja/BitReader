using System.IO;
using BitStreams;
using FluentAssertions;
using Xunit;
// ReSharper disable PossibleInvalidOperationException

namespace BitStreamsTests
{
    public sealed class BitReaderAndWriterUnitTests
    {

        [Theory]
        [InlineData(new ulong[] { 1, 2, 3, 4, 5, 6, 7, 1}, new[] { 3, 3, 3, 3, 3, 3, 3, 3 })]
        [InlineData(new ulong[] { 3, 8, 15, 0, 1, 63, 12, 255 }, new[] { 2, 4, 4, 1, 1, 6, 4, 8 })]
        public void readers_read_all_bits_correctly_after_writer(ulong[] numbersToWrite, int[] numberOfBits)
        {
            var stream = new MemoryStream();
            using (var bitWriter = new BitWriter(stream))
            {
                for (var i = 0; i < numbersToWrite.Length; ++i)
                {
                    bitWriter.Write(numbersToWrite[i], numberOfBits[i]);
                }
            }

            stream.Seek(0, SeekOrigin.Begin);
            
            var bitReader = new BitReader(stream);
            
            for (var i = 0; i < numbersToWrite.Length; ++i)
            {
                bitReader.Read(numberOfBits[i]).Value.Should().Be(numbersToWrite[i]);
            }
        }
    }
}