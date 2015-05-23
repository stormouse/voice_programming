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
    public delegate void F3(string condition);
    public class MainProcessor : Processor
    {
        public static readonly string ProcessorName = "MAIN_PROCESSOR";
        private string cwd;
        private Processor currentProcessor;
        private List<object> objectList;
        private string functionFile;
        string[] separator = { " " };

        public MainProcessor()
        {
            ProcessorFactory.StartProcessor(ProcessorName, this);
            functionFile = "functions.txt";
        }

        public void Process()
        {
            while (true)
            {
                string str = GetNewString();
                if (str != "")
                {
                    Read(str);
                }
            }
        }

        public void Read(string str)
        {
            List<string> strList = new List<string>(str.Split(separator, StringSplitOptions.RemoveEmptyEntries));
            if(strList.Count == 0) return;

            if (strList[0] == "PROCESSOR")
            {
                if (strList[1] == "=")
                {
                    currentProcessor = ProcessorFactory.GetProcessor(strList[2]);
                }

                return ;
            }
            else if(strList[0] == "FILELIST")
            {
                if (strList[1] == "=")
                {
                    objectList = GlobalArrayFactory.GetArray(strList[2]);
                }
            }
            else if (strList[0][0] == '$')
            {
                string[] fs = strList[0].Split("("[0]);
                string fname = fs[0];


                List<object> args = new List<object>();
                foreach (string s in fs[1].Split(","[0]))
                {
                    if (s != "")
                    {
                        object obj = GetObject(s);
                        args.Add(obj);
                    }
                }
                
                currentProcessor.ExecFunction(fname, args);
            }
            
        }

        public void ExecFunction(string str, List<object> args)
        {
            if (str == "OPEN")
            {
                // should search it in the engine list;
                WordProcessor wproc = new WordProcessor();
                ProcessorFactory.StartProcessor(WordProcessor.ProcessorName, wproc);
                currentProcessor = wproc;
                wproc.Read("OPEN(" + args[0].ToString() + ")");
            }

            StreamReader sr;
            try
            {
                sr = new StreamReader(functionFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return;
            }

            while (sr.Peek() >= 0)
            {
                string s = sr.ReadLine();
                if (s.Split(" "[0])[0] == str)
                {
                    currentProcessor.Read(str);
                }
            }
        }
        
    }
}
