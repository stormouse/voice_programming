using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voice_programming
{
    public abstract class Processor
    {
        public static readonly string ProcessorName;
        public static object[] fileList;
        public void ExecFunction(string function_name, List<object> args);
        public void Read(string str);
    }
}
