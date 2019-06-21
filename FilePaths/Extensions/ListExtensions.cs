using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePaths.Extensions
{
    static class ListExtensions
    {
        public static void AppendList(this List<string> self, List<string> tail)
        {
            
            if (self == null)
            {
                self = tail;
            }
            else
            {
                self.AddRange(tail);
            }
        }
    }
}
