using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voice_programming
{
    public class ProcessorFactory
    {
        private static Hashtable factory = new Hashtable();
        public static Processor GetProcessor(string name)
        {
            return (Processor)factory[name];
        }

        public static void StartProcessor(string name, Processor p)
        {
            factory.Add(name, p);
        }
    }
}
