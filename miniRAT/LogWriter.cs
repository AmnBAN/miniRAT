using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace miniRAT
{
    /// <summary>
    /// Write log to console or file
    /// </summary>
    class LogWriter
    {
        public static void WriteLog(string log)
        {
            Console.WriteLine(DateTime.Now.ToString()+" "+ log);
        }
    }
}
