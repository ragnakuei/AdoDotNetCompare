using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace AdoDotNetCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkCases>();
            Console.ReadLine();

            //var testClass = new TestClass();
            //Console.WriteLine(testClass.SqlDataReaderIndex());
            //Console.WriteLine(testClass.SqlDataReaderNamed());
            //Console.WriteLine(testClass.SqlDataReaderIndexSequential());
            //Console.WriteLine(testClass.SqlDataReaderNamedSequential());
            //Console.WriteLine(testClass.Fill());
            //Console.WriteLine(testClass.TableLoad());
            //Console.WriteLine(testClass.TableLoadSequential());
            //Console.WriteLine(testClass.Dapper());
        }
    }
}
