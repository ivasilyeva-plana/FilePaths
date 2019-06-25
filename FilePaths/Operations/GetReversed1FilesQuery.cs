using FilePaths.FilesEnumerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePaths.Operations
{
    internal class GetReversed1FilesQuery : IFilesQuery
    {
        private readonly IFilesEnumerator _filesEnumerator;

        public GetReversed1FilesQuery(IFilesEnumerator filesEnumerator)
        {
            _filesEnumerator = filesEnumerator;
        }

        public async Task<IEnumerable<string>> ExecuteQueryAsync(string startingFolder)
            => await Task.Run(()=>_filesEnumerator.GetFilesList(startingFolder)
                .Select(f => string.Join(@"\", f.Split('\\').Reverse())));
        
        
    }
}
