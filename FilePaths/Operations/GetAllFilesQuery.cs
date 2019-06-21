using FilePaths.FilesEnumerator;
using System.Collections.Generic;

namespace FilePaths.Operations
{
    internal class GetAllFilesQuery : IFilesQuery
    {
        private readonly IFilesEnumerator _filesEnumerator;

        public GetAllFilesQuery(IFilesEnumerator filesEnumerator)
        {
            _filesEnumerator = filesEnumerator;
        }

        public IEnumerable<string> ExecuteQuery(string startingFolder)
            => _filesEnumerator.GetFilesList(startingFolder);
    }
}
