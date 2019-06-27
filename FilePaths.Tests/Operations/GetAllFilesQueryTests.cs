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
    public class GetAllFilesQueryTests
    {
        private List<string> _files = new List<string>
            { "first.file", "second.file" };
        
        [TestMethod]
        public async Task ExecuteQueryAsyncTest()
        {
            var fileEnumeratorMock = new Mock<IFilesEnumerator>();
            fileEnumeratorMock.Setup(
                m => m.GetFilesListAsync(It.IsAny<CancellationToken>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(_files);

            const string folder = "folder";
            var ct = new CancellationToken();
            var query = new GetAllFilesQuery(fileEnumeratorMock.Object);
            var res = (await query.ExecuteQueryAsync(folder, ct)).ToList();

            fileEnumeratorMock.Verify(
                m => m.GetFilesListAsync(It.Is<CancellationToken>(x => x == ct), It.Is<string>(x => x == folder),
                    It.Is<string>(x => x == "*")), Times.Once);
            CollectionAssert.AreEqual(_files, res);
        }
    }
}