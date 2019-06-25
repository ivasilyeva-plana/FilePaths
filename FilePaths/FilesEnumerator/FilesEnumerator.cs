using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilePaths.FilesEnumerator
{
    internal class FilesEnumerator : IFilesEnumerator
    {
        public IEnumerable<string> GetFilesList(string startingFolder, string searchPattern = "*")
            => Directory.GetFiles(startingFolder, searchPattern, SearchOption.AllDirectories)
                .Select(s => s.Substring(startingFolder.Length + 1)).ToList();
    }
}
