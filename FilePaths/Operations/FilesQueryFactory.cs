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
                case Actions.Cs:
                    return new GetCsFilesQuery(_filesEnumerator);
                case Actions.Reversed1:
                    return new GetReversed1FilesQuery(_filesEnumerator);
                case Actions.Reversed2:
                    return new GetReversed2FilesQuery(_filesEnumerator);
                default:
                    throw new Exception("Action is not recognized");
            }
        }
    }
}
