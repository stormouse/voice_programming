using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace voice_programming
{
    class FileManage
    {
        public bool appendString(string fileName, string content)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.Write(content);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            return true;
        }
    }
}
