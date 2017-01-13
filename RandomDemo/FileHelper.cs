using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text;
using System.Collections;

namespace RandomDemo
{
 
    class FileHelper
    {
        private static string path = "获奖号码.txt";
        public static ArrayList Read()
        {
            ArrayList result = new ArrayList();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                //Console.WriteLine(line.ToString());
                result.Add(Convert.ToInt32(line.ToString()));
            }
            sr.Close();
            return result;
        }

        public static void Write(string text)
        {
            FileStream fs = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.WriteLine(text);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}
