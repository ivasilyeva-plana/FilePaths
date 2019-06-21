using System.Collections.Generic;

namespace FilePaths.FilesPathsManagers
{
    internal class FIlesInfo1 : FilesInfoBase
    {
        public FIlesInfo1(string startDirectory): base(startDirectory)
        {
            
        }

        protected override List<string> PathMaker(List<string> list) => list;
    }
}
