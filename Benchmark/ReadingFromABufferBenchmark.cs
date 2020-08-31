using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BitStreams;

namespace Benchmark
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [RPlotExporter]
    public class ReadingFromABufferBenchmark
    {
        private byte[] _buffer;
        private BitReader _bitReader;

        [Params(1000, 10000, 100000, 1000000, 10000000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _buffer = new byte[N];
            new Random(42).NextBytes(_buffer);
            _bitReader = new BitReader(new MemoryStream(_buffer));
        }

        [Benchmark]
        public void ReadingRegularBytes()
        {
            byte tempByte;
            for (var i = 0; i < N; ++i)
            {
                tempByte = _buffer[i];
            }
        }

        [Benchmark]
        public void ReadingBits()
        {
            byte? tempByte;
            for (var i = 0; i < N; ++i)
            {
                tempByte = _bitReader.ReadAsByte(3);
            }
        }
    }
}