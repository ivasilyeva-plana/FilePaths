using FilePaths.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePaths.FilesPathsManagers
{
    internal class FilesInfoBase
    {
        internal readonly string StartDirectory;

        public FilesInfoBase(string startDirectory)
        {
            StartDirectory = startDirectory;
        }


        public void FileInfoList(string dirName, string path, ref List<string> fileList )
        {

            string[] dirs = Directory.GetDirectories(dirName);
            string[] files = Directory.GetFiles(dirName);

            var tail = files.Select(s => s.Substring(StartDirectory.Length+1)).ToList();

            fileList.AppendList(tail);

            if (dirs.Any())
            {
                foreach (var dir in dirs)
                {
                    FileInfoList(dir, dir, ref fileList);
                }
            }
        
        }
    }
}
