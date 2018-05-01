using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;

namespace AdoDotNetCompare
{
    [MemoryDiagnoser]
    [InliningDiagnoser]
    [TailCallDiagnoser]
    public class BenchmarkCases
    {
        private readonly TestClass _benchClass = new TestClass();

        [Benchmark]
        public void Dapper() => _benchClass.Dapper();

        [Benchmark]
        public void SqlDataReaderIndex() => _benchClass.SqlDataReaderIndex();

        [Benchmark]
        public void SqlDataReaderNamed() => _benchClass.SqlDataReaderNamed();

        [Benchmark]
        public void SqlDataReaderIndexSequential() => _benchClass.SqlDataReaderIndexSequential();

        [Benchmark]
        public void SqlDataReaderNamedSequential() => _benchClass.SqlDataReaderNamedSequential();

        [Benchmark]
        public void Fill() => _benchClass.Fill();

        [Benchmark]
        public void TableLoad() => _benchClass.TableLoad();

        [Benchmark]
        public void TableLoadSequential() => _benchClass.TableLoadSequential();
    }
}