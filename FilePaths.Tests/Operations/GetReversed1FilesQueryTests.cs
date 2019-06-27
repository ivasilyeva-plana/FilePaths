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
    public class GetReversed1FilesQueryTests
    {
        private readonly List<string> _files = new List<string>
            { @"Directory1\first.file", @"Directory2\second.cs" };
        private readonly List<string> _expectedResult = new List<string>
            { @"first.file\Directory1", @"second.cs\Directory2"};
        
        [TestMethod]
        public async Task ExecuteQueryAsyncTest()
        {
            var fileEnumeratorMock = new Mock<IFilesEnumerator>();
            fileEnumeratorMock.Setup(
                    m => m.GetFilesListAsync(It.IsAny<CancellationToken>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(_files);

            const string folder = "folder";
            var ct = new CancellationToken();
            var query = new GetReversed1FilesQuery(fileEnumeratorMock.Object);
            var res = (await query.ExecuteQueryAsync(folder, ct)).ToList();

            fileEnumeratorMock.Verify(
                m => m.GetFilesListAsync(It.Is<CancellationToken>(x => x == ct), It.Is<string>(x => x == folder),
                    It.Is<string>(x => x == "*")), Times.Once);
            CollectionAssert.AreEqual(_expectedResult, res);
        }
    }
}