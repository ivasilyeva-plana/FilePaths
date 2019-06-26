using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilePaths.Operations
{
    public interface IFilesQuery
    {
        Task<IEnumerable<string>> ExecuteQueryAsync(string startingFolder,  CancellationToken ct);
    }
}