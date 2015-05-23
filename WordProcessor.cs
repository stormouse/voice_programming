using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace voice_programming
{
    public class WordProcessor : Processor
    {
        public static readonly string ProcessorName = "WORD_PROCESSOR";
        public void Read(string str)
        {
            if (new Regex("^OPEN").Match(str).Success)
            {
                char[] sep = { '(', ')' };
                string filename = str.Split(sep)[1];

                // waiting for word class;
            }
        }
        public void ExecFunction(string fname, List<object> args)
        {
            if (fname == "APPEND")
            {
                
            }
        }

    }
}
