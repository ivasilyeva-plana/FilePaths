using System.Collections.Generic;

namespace FilePaths.Operations
{
    public interface IFilesQuery
    {
        IEnumerable<string> ExecuteQuery(string startingFolder);
    }
}