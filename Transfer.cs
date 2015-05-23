using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace voice_programming
{
    class Transfer
    {
        public Transfer(string[] pattern)
        {
            // 词法分析
            int length = pattern.Length;
            // 动词
            string act = pattern[0];

            // 路径
            string originalPath = "";
            int i = 1, j = 0;
            for (; i < length - 1; i++)
            {
                if (isDir(pattern[i]))
                {
                    originalPath += pattern[i];
                }
            }
            // 条件
            string[] condition = null;
            int k = 0;
            for (; i < length - 1; i++)
            {
                condition[k++] = pattern[i];
            }
            // 操作对象
            string target = pattern[length - 1];
        }

        public string generateOpen(string path, string[] condition, string target)
        {
            if (!File.Exists("C:\\function\\open.txt"))
            {
                FileStream fs1 = new FileStream("C:\\function\\open.txt", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                writer.WriteLine("CD " + path);
                writer.WriteLine("ENABALE RET_LIST");
                writer.WriteLine("FOREACH f IN READ_ALL_FILES(CWD)");
                writer.WriteLine("");
                writer.WriteLine("IF F3()");
                writer.WriteLine();
            }
            return "";
        }
        public bool isDongci(string word)
        {
            FileStream fs = new FileStream("dongci.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                if (line == word)
                {
                    fs.Close();
                    return true;
                }
            }
            fs.Close();
            return false;
        }

        public bool isDir(string word)
        {
            Regex reg_root = new Regex("盘");
            Regex reg_dir = new Regex("文件夹");
            Regex reg_table = new Regex("桌面");
            Regex reg_jieci = new Regex("下的");
            if (reg_root.IsMatch(word) || reg_dir.IsMatch(word) || reg_table.IsMatch(word) || reg_jieci.IsMatch(word))
            {
                return true;
            }
            return false;
        }

        //时间、人物、类型、应用程序;
        public string getPath(string[] pathWords)
        {
            string s = "C盘下";
            return "";
        }
    }
}
