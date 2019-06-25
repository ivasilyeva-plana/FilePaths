using System;
using System.IO;
using System.Linq;

namespace FilePaths.Models
{
    internal class InputData
    {
        private const string DefaultResultFilePath = "result.txt";

        public string StartDirectory { get; }
        public Actions ActionValue { get; }
        public string ResultFilePath { get; }

        public InputData(string startDirectory, Actions action, string resultFilePath)
        {
            StartDirectory = startDirectory;
            ActionValue = action;
            ResultFilePath = resultFilePath;
        }

        public static InputData Parse(string[] args)
        {
            Validate(args); 

            return new InputData(args[0],
                (Actions) Enum.Parse(typeof(Actions), args[1], true),
                args.Length > 2 ? args[2] : DefaultResultFilePath);
        }

        private static void Validate(string[] args)
        {
            var message = string.Empty;
            var availableActions = Enum.GetNames(typeof(Actions))
                .Select(a => a.ToLower()).ToArray();

            if (args.Length < 2 || args.Length > 3)
                throw new Exception($"Command line arguments:{Environment.NewLine}" +
                                    $"  directory  -  start directory;{Environment.NewLine}" +
                                    $"  action  -  action name. Action name list: {string.Join(", ", availableActions)};{Environment.NewLine}" +
                                     "  file path  -  path to the result file (default value results.txt);");

            if (!Directory.Exists(args[0]))
                throw new Exception($"There is no such directory: {args[0]}");

            if (!Enum.TryParse<Actions>(args[1], true, out _))
                throw new Exception(
                    $"{args[1]} - invalid action parameter. Action list: {string.Join(", ", availableActions)}");

            if (args.Length > 2)
                new FileInfo(args[2]).Create();
        }
    }
}
