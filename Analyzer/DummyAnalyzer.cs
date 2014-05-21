using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    public class DummyAnalyzer
    {
        public int CountLineOfCode(string content)
        {
            return content.Split('\n').Count();
        }

    }
}
