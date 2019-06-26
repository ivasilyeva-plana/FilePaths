using FilePaths.Models;

namespace FilePaths.Operations
{
    internal interface IFilesQueryFactory
    {
        IFilesQuery GetQuery();
    }
}