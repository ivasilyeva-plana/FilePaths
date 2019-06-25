using FilePaths.FilesEnumerator;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FilePaths.Operations
{
    internal class GetCsFilesQuery : IFilesQuery
    {
        private readonly IFilesEnumerator _filesEnumerator;

        public GetCsFilesQuery(IFilesEnumerator filesEnumerator)
        {
            _filesEnumerator = filesEnumerator;
        }

        public async Task<IEnumerable<string>> ExecuteQueryAsync(string startingFolder,  CancellationToken ct)
        {
            var list = await _filesEnumerator.GetFilesListAsync(ct, startingFolder, "*.cs");
            return list.Select(f => $"{f} /");
        }
     
                
    }
}
