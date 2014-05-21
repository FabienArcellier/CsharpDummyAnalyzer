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
            return DeleteEmptyLine(DeleteComment(content)).Split('\n').Count();
        }

        private string DeleteEmptyLine(string content)
        {
            var sb = new StringBuilder();
            foreach (var line in content.Split('\n'))
            {
                if (line.Trim().Length != 0)
                {
                    sb.AppendLine(line);
                }
            }

            return sb.ToString();
        }

        private string DeleteComment(string content)
        {
            var sb = new StringBuilder();
            var blockcomment = false;
            foreach (var line in content.Split('\n'))
            {
                var linecomment = false;
                if (line.Trim().StartsWith("/*"))
                {
                    if (!line.Contains("*/"))
                    {
                        blockcomment = true;
                    }
                    else
                    {
                        linecomment = true;
                    }
                }
                
                if(blockcomment == false && linecomment == false)
                {
                    sb.AppendLine(line);
                }

                if (line.Contains("*/"))
                {
                    blockcomment = false;
                }
            }

            return sb.ToString();
        }

    }
}
