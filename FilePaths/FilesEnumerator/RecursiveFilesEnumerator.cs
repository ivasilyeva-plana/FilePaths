using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FilePaths.FilesEnumerator
{
    internal class RecursiveFilesEnumerator : IFilesEnumerator
    {
        public Task<IEnumerable<string>> GetFilesListAsync(CancellationToken ct, string startingFolder, string searchPattern = "*")
            => Task.Run(() => GetFilesFromSubFolders(startingFolder, searchPattern, ct)
                .Select(s => s.Substring(startingFolder.Length + 1)));

        private List<string> GetFilesFromSubFolders(string folderName, string searchPattern,  CancellationToken ct)
        {
            var folderNames = Directory.GetDirectories(folderName);
            var fileNames = Directory.GetFiles(folderName, searchPattern).ToList();

            if (ct.IsCancellationRequested) return fileNames;

            if (folderNames == null || !folderNames.Any()) return fileNames;

            foreach (var folder in folderNames)
            {
                if (ct.IsCancellationRequested) break;
                fileNames.AddRange(GetFilesFromSubFolders(folder, searchPattern, ct));
            }

            return fileNames;
        }
    }
}
