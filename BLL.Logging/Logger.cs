using System;
using System.IO;
using System.Text;

namespace BLL.Logging
{
    public class Logger
    {
        public static void Log(string message)
        {
            var now = DateTime.Now;
            var logFileName = $"{now.Year}-{now.Month}-{now.Day}.log";
            using (var file = new StreamWriter(logFileName, true, Encoding.Default))
            {
                file.WriteLine($"[{now}] {message}");
                file.Close();
            }
        }
    }
}
