using FilePaths.FilesPathsManagers;
using FilePaths.Helpers;
using FilePaths.Models;
using System;
using System.IO;
using System.Text;

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


            
            var x = new FIlesInfo1(_inputData.StartDirectory);
            var outList = x.FileInfoList();
         

            using (StreamWriter sw = new StreamWriter(_inputData.ResultFilePath, false, Encoding.Default))
            {
                foreach (var i in outList)
                {
                    sw.WriteLine(i);
                }
            }
            
            Console.ReadKey();
        }

        
    }
}
