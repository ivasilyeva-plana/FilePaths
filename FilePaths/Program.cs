using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FilePaths.Extensions;
using FilePaths.Helpers;
using FilePaths.Models;

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
               // Console.ReadKey();
                return;
            }

            _inputData.StartDirectory = args[0];
            var outList = new List<string>();


            FileInfoList(_inputData.StartDirectory, string.Empty, ref outList );

            using (StreamWriter sw = new StreamWriter(_inputData.ResultFilePath, false, Encoding.Default))
            {
                foreach (var i in outList)
                {
                    sw.WriteLine(i);
                }
            }
            
            Console.ReadKey();
        }

        private static void FileInfoList(string dirName, string path, ref List<string> fileList )
        {

            string[] dirs = Directory.GetDirectories(dirName);
            string[] files = Directory.GetFiles(dirName);

            var tail = files.Select(s => s.Substring(_inputData.StartDirectory.Length+1)).ToList();

            fileList.AppendList(tail);

            if (dirs.Any())
            {
                foreach (var dir in dirs)
                {
                    FileInfoList(dir, dir, ref fileList);
                }
            }
        
        }
    }
}
