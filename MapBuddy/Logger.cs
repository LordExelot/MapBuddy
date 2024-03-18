using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MapBuddy
{
    internal class Logger
    {
        public string log;

        public Logger()
        {
            log = "";
        }

        public void WriteLog()
        {
            string logDir = GetLogDir();

            bool exists = Directory.Exists(logDir);

            if (!exists)
            {
                Directory.CreateDirectory(logDir);
            }

            File.AppendAllText(Path.Combine(logDir, "log.txt"), log);

            log = "";
        }

        public void AddToLog(string text)
        {
            log = log + text + "\n";
        }

        public string GetLogDir()
        {
            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Log");
        }
    }
}
