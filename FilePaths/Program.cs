using FilePaths.Models;
using FilePaths.Operations;
using System;
using System.Collections.Generic;
using System.IO;

namespace FilePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            InputData inputData;
            try
            {
                inputData = InputData.Parse(args);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            var factory = new FilesQueryFactory(new FilesEnumerator.FilesEnumerator());
            var query = factory.GetQuery(inputData.ActionValue);
            var outList = query.ExecuteQuery(inputData.StartDirectory);

            WriteToFile(inputData.ResultFilePath, outList);

            Console.WriteLine($"Result is stored to: {inputData.ResultFilePath}");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void WriteToFile(string fileName, IEnumerable<string> list)
        {
            using (var sw = new StreamWriter(fileName, false))
            {
                foreach (var i in list)
                {
                    sw.WriteLine(i);
                }
            }
        }
    }
}
