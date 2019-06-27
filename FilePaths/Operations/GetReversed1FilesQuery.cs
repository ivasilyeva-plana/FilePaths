using FilePaths.FilesEnumerator;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FilePaths.Operations
{
    public class GetReversed1FilesQuery : IFilesQuery
    {
        private readonly IFilesEnumerator _filesEnumerator;

        public GetReversed1FilesQuery(IFilesEnumerator filesEnumerator)
        {
            _filesEnumerator = filesEnumerator;
        }

        public async Task<IEnumerable<string>> ExecuteQueryAsync(string startingFolder, CancellationToken ct)
        {
            var list = await _filesEnumerator.GetFilesListAsync(ct, startingFolder); 
            return list.Select(f => string.Join(@"\", f.Split('\\').Reverse()));
        }
        
        
    }
}
