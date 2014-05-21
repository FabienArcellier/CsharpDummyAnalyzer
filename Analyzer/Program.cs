using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Tracer.WriteTrace(args[0]);

            var reader = new DirectoryReader();
            var parser = new DummyAnalyzer();
            var result = new Dictionary<string, int>();

            reader.ReadEveryCsFile(args[0], f => {
                var content = File.ReadAllText(f.FullName);
                var length = parser.CountLineOfCode(content);
                result.Add(f.FullName, length);
            });

            var report = result.ToList().OrderByDescending(s => s.Value);
            foreach (var keyvalue in report)
            {
                Tracer.WriteTrace(String.Format("{0};{1}", keyvalue.Key, keyvalue.Value));
            }

            Console.In.ReadLine();
        }
    }
}
