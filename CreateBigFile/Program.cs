using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CreateBigFile
{
    class Program
    {
        static string file = @"D:\Projects\testBigFile.txt";
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            using (FileStream fs = File.Create(file))
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(RandomString(10000));
                    fs.Write(info, 0, info.Length);
                    Console.WriteLine(i);
                }
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
