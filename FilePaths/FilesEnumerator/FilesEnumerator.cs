using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilePaths.FilesEnumerator
{
    internal class FilesEnumerator : IFilesEnumerator
    {
        public IEnumerable<string> GetFilesList(string startingFolder)
            => GetFilesFromSubFolders(startingFolder)
                .Select(s => s.Substring(startingFolder.Length + 1));

        private List<string> GetFilesFromSubFolders(string folderName)
        {
            var folderNames = Directory.GetDirectories(folderName);
            var fileNames = Directory.GetFiles(folderName).ToList();

            fileNames.AddRange(fileNames);

            if (folderNames == null || !folderNames.Any()) return fileNames;

            foreach (var folder in folderNames)
            {
                fileNames.AddRange(GetFilesFromSubFolders(folder));
            }

            return fileNames;
        }
    }
}
