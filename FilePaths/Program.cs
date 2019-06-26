﻿using FilePaths.Models;
using FilePaths.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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


            var cts = new CancellationTokenSource();
            
            _ = StartOperationAsync(inputData,  cts.Token);

            const string exit = "q";
            Console.WriteLine($"Enter '{exit}' to cancel operation");

            string command = Console.ReadLine();

            if (command != null && command.Equals(exit))
            {
                cts.Cancel();
            }
         
            
     
            Console.Read();
         
            
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

        private static async Task StartOperationAsync(InputData inputData, CancellationToken ct)
        {
            var factory = new FilesQueryFactory(new FilesEnumerator.FilesEnumerator());
            var query = factory.GetQuery(inputData.ActionValue);

            var outList = await query.ExecuteQueryAsync(inputData.StartDirectory, ct);
            
            WriteToFile(inputData.ResultFilePath, outList);
            
            Console.WriteLine($"Result is stored to: {inputData.ResultFilePath}");
   
        }
    }
}
