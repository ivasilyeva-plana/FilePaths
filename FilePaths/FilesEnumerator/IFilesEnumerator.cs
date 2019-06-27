using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilePaths.FilesEnumerator
{
    public interface IFilesEnumerator
    {
        Task <IEnumerable<string>> GetFilesListAsync(CancellationToken ct, string startingFolder, string searchPattern = "*");
    }
}