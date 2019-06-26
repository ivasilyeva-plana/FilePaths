using FilePaths.Models;
using FilePaths.Ninject;
using FilePaths.Operations;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FilePaths
{
    class Program
    {
        private const string Exit = "q";

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

            var registrations = new NinjectRegistrations(inputData.ActionValue);
            var kernel = new StandardKernel(registrations);

            var cts = new CancellationTokenSource();
            
            _ = StartOperationAsync(inputData,  cts.Token, kernel);

            Console.WriteLine($"Enter '{Exit}' to cancel operation");

            var command = Console.ReadLine();

            if (command != null && command.Equals(Exit))
            {
                Console.WriteLine("Operation is canceled.");
                cts.Cancel();
                Console.Read();
            }
        }

        private static async Task WriteToFile(string fileName, IEnumerable<string> list)
        {
            using (var sw = new StreamWriter(fileName, false))
            {
                await sw.WriteAsync(string.Join(Environment.NewLine, list.ToArray()));
            }
        }

        private static async Task StartOperationAsync(InputData inputData, CancellationToken ct, IKernel kernel)
        {
            var query = kernel.Get<IFilesQuery>();
            var outList = await query.ExecuteQueryAsync(inputData.StartDirectory, ct);
            
            await WriteToFile(inputData.ResultFilePath, outList);
            
            Console.WriteLine($"Result is stored to: {inputData.ResultFilePath}");
        }
    }
}
