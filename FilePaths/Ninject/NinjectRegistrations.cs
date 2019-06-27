using FilePaths.FilesEnumerator;
using FilePaths.Models;
using FilePaths.Operations;
using Ninject.Modules;
using System;

namespace FilePaths.Ninject
{
    public class NinjectRegistrations : NinjectModule
    {
        private readonly Actions _action;

        public NinjectRegistrations(Actions action) => _action = action;

        public override void Load()
        {
            Bind<IFilesEnumerator>().To<RecursiveFilesEnumerator>();

            switch (_action)
            {
                case Actions.All:
                    Bind<IFilesQuery>().To<GetAllFilesQuery>();
                    break;
                case Actions.Cs:
                    Bind<IFilesQuery>().To<GetCsFilesQuery>();
                    break;
                case Actions.Reversed1:
                    Bind<IFilesQuery>().To<GetReversed1FilesQuery>();
                    break;
                case Actions.Reversed2:
                    Bind<IFilesQuery>().To<GetReversed2FilesQuery>();
                    break;
                default:
                    throw new Exception("Action is not recognized");
            }
        }
    }
}
