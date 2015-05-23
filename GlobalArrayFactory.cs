using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voice_programming
{
    public class GlobalArrayFactory
    {
        private static Hashtable factory;
        public static void AddGlobalArray(string array_name, List<object> list)
        {
            factory.Add(array_name, list);
        }

        public static List<object> GetArray(string array_name)
        {
            return (List<object>)factory[array_name];
        }


    }
}
