using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    class DirectoryReader
    {
        public void ReadEveryCsFile(string path, Action<FileInfo> actionOnFile)
        {
            var dir = new DirectoryInfo(path);
            var subdirs = dir.GetDirectories();
            if (subdirs.Length != 0)
            {
                foreach (var subdir in subdirs)
                {
                    this.ReadEveryCsFile(subdir.FullName, actionOnFile);
                }
            }

            var files = dir.GetFiles("*.cs");
            foreach (var file in files)
            {
                actionOnFile(file);
            }
        }
    }
}
