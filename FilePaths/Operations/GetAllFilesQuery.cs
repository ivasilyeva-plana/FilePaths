using System;
using FilePaths.FilesEnumerator;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace FilePaths.Operations
{
    internal class GetAllFilesQuery : IFilesQuery
    {
        private readonly IFilesEnumerator _filesEnumerator;

        public GetAllFilesQuery(IFilesEnumerator filesEnumerator)
        {
            _filesEnumerator = filesEnumerator;
        }

        public async Task<IEnumerable<string>> ExecuteQueryAsync(string startingFolder,  CancellationToken ct)
            => await _filesEnumerator.GetFilesListAsync(ct, startingFolder);
    }
}
