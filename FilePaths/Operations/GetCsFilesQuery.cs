using FilePaths.FilesEnumerator;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<string>> ExecuteQueryAsync(string startingFolder)
            => await Task.Run(()=>_filesEnumerator.GetFilesList(startingFolder, "*.cs")
                .Select(f => $"{f} /"));
    }
}
