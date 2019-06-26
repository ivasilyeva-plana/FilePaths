using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FilePaths.FilesEnumerator
{
    internal class FilesEnumerator : IFilesEnumerator
    {/*
        public IEnumerable<string> GetFilesList(string startingFolder, string searchPattern = "*")
            => Directory.GetFiles(startingFolder, searchPattern, SearchOption.AllDirectories)
                .Select(s => s.Substring(startingFolder.Length + 1)).ToList();*/

        public async Task <IEnumerable<string>> GetFilesListAsync( CancellationToken ct, string startingFolder, string searchPattern = null)
            => await Task.Run(() => GetFilesFromSubFolders(startingFolder, searchPattern, ct)
                .Select(s => s.Substring(startingFolder.Length + 1)));

        private List<string> GetFilesFromSubFolders(string folderName, string searchPattern,  CancellationToken ct)
        {
            var folderNames = Directory.GetDirectories(folderName);
            var fileNames = Directory.GetFiles(folderName, searchPattern).ToList();

            if (ct.IsCancellationRequested)
            {
                Console.WriteLine("Operation is canceled.");
                return fileNames;
            }

            fileNames.AddRange(fileNames);

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
