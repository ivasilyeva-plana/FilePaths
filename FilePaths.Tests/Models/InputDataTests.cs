using System;
using System.IO;
using FilePaths.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilePaths.Tests.Models
{
    [TestClass]
    public class InputDataTests
    {
        [TestMethod]
        public void ParseValidParametersTest()
        {
            const string resultFileName = "somefile.txt";
            const Actions action = Actions.All;
            var sampleFolder = Directory.GetCurrentDirectory();
            var inputData = InputData.Parse(sampleFolder, action.ToString().ToLower(), resultFileName);

            Assert.IsNotNull(inputData);
            Assert.AreEqual(sampleFolder, inputData.StartDirectory);
            Assert.AreEqual(resultFileName, inputData.ResultFilePath);
            Assert.AreEqual(action, inputData.ActionValue);
        }

        [TestMethod]
        public void ParseValidUpperCaseParametersTest()
        {
            const string resultFileName = "somefile.txt";
            const Actions action = Actions.All;
            var sampleFolder = Directory.GetCurrentDirectory();
            var inputData = InputData.Parse(sampleFolder, action.ToString(), resultFileName);

            Assert.IsNotNull(inputData);
            Assert.AreEqual(sampleFolder, inputData.StartDirectory);
            Assert.AreEqual(resultFileName, inputData.ResultFilePath);
            Assert.AreEqual(action, inputData.ActionValue);
        }

        [TestMethod]
        public void ParseValidParametersWithoutResultFileTest()
        {
            const string expectedFileName = "result.txt";
            const Actions action = Actions.All;
            var sampleFolder = Directory.GetCurrentDirectory();
            var inputData = InputData.Parse(sampleFolder, action.ToString().ToLower());

            Assert.IsNotNull(inputData);
            Assert.AreEqual(sampleFolder, inputData.StartDirectory);
            Assert.AreEqual(expectedFileName, inputData.ResultFilePath);
            Assert.AreEqual(action, inputData.ActionValue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ParseTooManyParametersTest()
        {
            const string expectedFileName = "result.txt";
            const Actions action = Actions.All;
            var sampleFolder = Directory.GetCurrentDirectory();
            _ = InputData.Parse(sampleFolder, action.ToString().ToLower(), expectedFileName, "redundantParameter");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ParseNotEnoughParametersTest()
        {
            var sampleFolder = Directory.GetCurrentDirectory();
            _ = InputData.Parse(sampleFolder);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ParseInvalidActionTest()
        {
            const string expectedFileName = "result.txt";
            const string action = "dummyAction";
            var sampleFolder = Directory.GetCurrentDirectory();
            _ = InputData.Parse(sampleFolder, action, expectedFileName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ParseInvalidFolderTest()
        {
            const string expectedFileName = "result.txt";
            const Actions action = Actions.All;
            var sampleFolder = "*??*?";
            _ = InputData.Parse(sampleFolder, action.ToString().ToLower(), expectedFileName, "redundantParameter");
        }
    }
}