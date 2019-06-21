using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePaths.Models
{
    class InputData
    {
        public string StartDirectory { get; set; }
        public PathAction ActionValue { get; set; }
        public string ResultFilePath { get; set; }
    }
}
