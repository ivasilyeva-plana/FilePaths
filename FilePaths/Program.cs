using FilePaths.FilesPathsManagers;
using FilePaths.Helpers;
using FilePaths.Models;
using System;
using System.IO;
using System.Text;
using FilePaths.Operations;

namespace FilePaths
{
    class Program
    {
        static InputData _inputData;
        static void Main(string[] args)
        {
            var inputDataAnalyzer = new InputAnalyzer(args);
            try
            {
                _inputData = inputDataAnalyzer.GetInputDataValues();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }


            
            //var x = new FIlesInfo1(_inputData.StartDirectory);
            //var outList = x.FileInfoList();

            var factory = new FilesQueryFactory(new FilesEnumerator.FilesEnumerator());
            var query = factory.GetQuery(_inputData.ActionValue);
            var outList = query.ExecuteQuery(_inputData.StartDirectory);

            using (var sw = new StreamWriter(_inputData.ResultFilePath, false))
            {
                foreach (var i in outList)
                {
                    sw.WriteLine(i);
                }
            }

            Console.WriteLine($"Result is stored to: {_inputData.ResultFilePath}");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        
    }
}
