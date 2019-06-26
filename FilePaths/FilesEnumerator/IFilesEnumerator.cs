using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilePaths.FilesEnumerator
{
    internal interface IFilesEnumerator
    {
        Task <IEnumerable<string>> GetFilesListAsync(CancellationToken ct, string startingFolder, string searchPattern = "*");
    }
}