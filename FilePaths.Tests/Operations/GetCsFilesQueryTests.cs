using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FilePaths.FilesEnumerator;
using FilePaths.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FilePaths.Tests.Operations
{
    [TestClass]
    public class GetCsFilesQueryTests
    {
        private List<string> _files = new List<string>
            { "third.cs", "forth.cs" };
        private List<string> _expectedResult = new List<string>
            { "third.cs /", "forth.cs /" };
        
        [TestMethod]
        public async Task ExecuteQueryAsyncTest()
        {
            var fileEnumeratorMock = new Mock<IFilesEnumerator>();
            fileEnumeratorMock.Setup(
                    m => m.GetFilesListAsync(It.IsAny<CancellationToken>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(_files);

            const string folder = "folder";
            var ct = new CancellationToken();
            var query = new GetCsFilesQuery(fileEnumeratorMock.Object);
            var res = (await query.ExecuteQueryAsync(folder, ct)).ToList();

            fileEnumeratorMock.Verify(
                m => m.GetFilesListAsync(It.Is<CancellationToken>(x => x == ct), It.Is<string>(x => x == folder),
                    It.Is<string>(x => x == "*.cs")), Times.Once);
            CollectionAssert.AreEqual(_expectedResult, res);
        }
    }
}