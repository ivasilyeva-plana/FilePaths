using FilePaths.FilesEnumerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePaths.Operations
{
    internal class GetReversed2FilesQuery : IFilesQuery
    {
        private readonly IFilesEnumerator _filesEnumerator;

        public GetReversed2FilesQuery(IFilesEnumerator filesEnumerator)
        {
            _filesEnumerator = filesEnumerator;
        }

        public async Task<IEnumerable<string>> ExecuteQueryAsync(string startingFolder)
            => await Task.Run(()=> _filesEnumerator.GetFilesList(startingFolder)
                           .Select(f => new string(f.ToCharArray().Reverse().ToArray())));
        
    }
}
