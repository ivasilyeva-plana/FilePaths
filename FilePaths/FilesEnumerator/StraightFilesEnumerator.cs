using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FilePaths.FilesEnumerator
{
    internal class StraightFilesEnumerator : IFilesEnumerator
    {
        public Task<IEnumerable<string>> GetFilesListAsync(CancellationToken ct, string startingFolder, string searchPattern = "*")
            => Task.Run(() =>
                Directory.GetFiles(startingFolder, searchPattern, SearchOption.AllDirectories)
                .Select(s => s.Substring(startingFolder.Length + 1)), ct);

    }
}
