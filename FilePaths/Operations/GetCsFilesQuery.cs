using FilePaths.FilesEnumerator;
using System.Collections.Generic;
using System.Linq;

namespace FilePaths.Operations
{
    internal class GetCsFilesQuery : IFilesQuery
    {
        private readonly IFilesEnumerator _filesEnumerator;

        public GetCsFilesQuery(IFilesEnumerator filesEnumerator)
        {
            _filesEnumerator = filesEnumerator;
        }

        public IEnumerable<string> ExecuteQuery(string startingFolder)
            => _filesEnumerator.GetFilesList(startingFolder, "*.cs")
                .Select(f => $"{f} /");
    }
}
