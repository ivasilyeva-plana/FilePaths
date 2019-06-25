using System.Collections.Generic;

namespace FilePaths.FilesEnumerator
{
    internal interface IFilesEnumerator
    {
        IEnumerable<string> GetFilesList(string startingFolder, string searchPattern = "*");
    }
}