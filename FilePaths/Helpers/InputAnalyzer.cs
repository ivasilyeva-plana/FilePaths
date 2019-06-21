using FilePaths.Models;
using System;
using System.IO;
using System.Linq;

namespace FilePaths.Helpers
{
    internal class InputAnalyzer
    {
        private const string DefFilePath = "result.txt";
        private readonly string[] _args;

        public InputAnalyzer(string[] args)
        {
            _args = args;
        }

        public InputData GetInputDataValues()
        {
            var message = GetValidateMessage();
            if (!string.IsNullOrEmpty(message))
            {
                throw new ApplicationException(message);
            }

            return new InputData
            {
                StartDirectory = _args[0],
                ActionValue = (Actions)Enum.Parse(typeof(Actions), _args[1], true),
                ResultFilePath = _args.Length==3 ? _args[2] : DefFilePath
            };
        }

        private string GetValidateMessage()
        {
            var message = string.Empty;
            var availableActions = Enum.GetNames(typeof(Actions))
                .Select(a => a.ToLower()).ToArray();
            if (_args.Length >= 2 && _args.Length <= 3)
            {
                if (!Directory.Exists(_args[0]))
                {
                    message = $"There isn't such directory: {_args[0]}";
                }

                if (!Enum.TryParse<Actions>(_args[1],true, out var action))
                {
                   
                    message = $"{_args[1]} - invalid action parameter. Action list: {string.Join(", ", availableActions)}";
                }

                if (_args.Length > 2)
                {
                    var resFile = new FileInfo(_args[2]);
                    resFile.Create();
                }
            }
            else
            {
                message = $"Command line arguments:{Environment.NewLine}" +
                           $"  directory  -  start directory;{Environment.NewLine}" +
                           $"  action  -  action name. Action name list: {string.Join(", ", availableActions)};{Environment.NewLine}" +
                           $"  file path  -  path to the result file (default value results.txt);";

            }

            return message;
        }
    }
}
