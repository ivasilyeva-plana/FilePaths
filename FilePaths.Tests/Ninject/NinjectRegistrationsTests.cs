using System;
using FilePaths.Models;
using FilePaths.Ninject;
using FilePaths.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace FilePaths.Tests.Ninject
{
    [TestClass]
    public class NinjectRegistrationsTests
    {
        [TestMethod]
        public void AllActionResolveTest()
            => ResolveActionTest(Actions.All, typeof(GetAllFilesQuery));

        [TestMethod]
        public void CsActionResolveTest()
            => ResolveActionTest(Actions.Cs, typeof(GetCsFilesQuery));

        [TestMethod]
        public void Reversed1ActionResolveTest()
            => ResolveActionTest(Actions.Reversed1, typeof(GetReversed1FilesQuery));

        [TestMethod]
        public void Reversed2ActionResolveTest()
            => ResolveActionTest(Actions.Reversed2, typeof(GetReversed2FilesQuery));
        
        private void ResolveActionTest(Actions action, Type expectedType)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(action));

            var obj = kernel.Get<IFilesQuery>();

            Assert.IsInstanceOfType(obj, expectedType);
        }
    }
}