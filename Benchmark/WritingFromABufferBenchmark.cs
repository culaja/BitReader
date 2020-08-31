using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BitStreams;

namespace Benchmark
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [RPlotExporter]
    public class WritingFromABufferBenchmark
    {
        private byte[] _buffer;
        private BitWriter _bitWriter;

        [Params(1000, 10000, 100000, 1000000, 10000000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _buffer = new byte[N];
            _bitWriter = new BitWriter(new MemoryStream());
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _bitWriter.Dispose();
        }

        [Benchmark]
        public void WritingRegularBytes()
        {
            for (var i = 0; i < N; ++i)
            {
                _buffer[i] = 0x05;
            }
        }

        [Benchmark]
        public void WritingBits()
        {
            for (var i = 0; i < N; ++i)
            {
                _bitWriter.Write(0x05, 3);
            }
        }
    }
}