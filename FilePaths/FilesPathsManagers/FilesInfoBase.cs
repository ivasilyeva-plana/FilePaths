using FilePaths.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilePaths.FilesPathsManagers
{
    internal abstract class FilesInfoBase : IFilesInfo
    {
        protected string StartDirectory;
        private readonly List<string>  _fileList = new List<string>();

        protected FilesInfoBase(string startDirectory)
        {
            StartDirectory = startDirectory;
        }

        public List<string> FileInfoList()
        {
            FileInfoList(StartDirectory, string.Empty);
            return _fileList;
        }

        private void FileInfoList(string dirName, string path)
        {

            string[] dirs = Directory.GetDirectories(dirName);
            string[] files = Directory.GetFiles(dirName);

            var tail = files.Select(s => s.Substring(StartDirectory.Length+1)).ToList();

            tail = PathMaker(tail);

            _fileList.AppendList(tail);

            if (dirs.Any())
            {
                foreach (var dir in dirs)
                {
                    FileInfoList(dir, dir);
                }
            }
        
        }

        protected abstract List<string> PathMaker(List<string> list);

    }
}
