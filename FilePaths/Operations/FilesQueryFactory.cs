using FilePaths.Models;
using Ninject;

namespace FilePaths.Operations
{
    internal class FilesQueryFactory : IFilesQueryFactory
    {
        private readonly IKernel _kernel;

        public FilesQueryFactory(IKernel kernel) => _kernel = kernel;

        public IFilesQuery GetQuery() =>_kernel.Get<IFilesQuery>();
    }
}
