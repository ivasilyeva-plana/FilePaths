using System;
using FilePaths.FilesEnumerator;
using FilePaths.Models;

namespace FilePaths.Operations
{
    internal class FilesQueryFactory : IFilesQueryFactory
    {
        private readonly IFilesEnumerator _filesEnumerator;

        public FilesQueryFactory(IFilesEnumerator filesEnumerator)
        {
            _filesEnumerator = filesEnumerator;
        }

        public IFilesQuery GetQuery(Actions action)
        {
            switch (action)
            {
                case Actions.All:
                    return new GetAllFilesQuery(_filesEnumerator);
                default:
                    throw new Exception("Action is not recognized");
            }
        }
    }
}
