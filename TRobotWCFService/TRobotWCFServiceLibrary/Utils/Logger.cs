using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TRobotWCFServiceLibrary.Utils
{
    public static class Logger
    {
        public static void Log(Exception e)
        {
            string path = Directory.GetCurrentDirectory() + @"/ExceptionLog.txt";

            if (File.Exists(path))
            {
                using (StreamWriter log = File.AppendText(path))
                {
                    WriteExceptionLog(e, log);
                }
            }
            else
            {
                using (StreamWriter log = File.CreateText(path))
                {
                    WriteExceptionLog(e, log);
                }
            }
        }

        private static void WriteExceptionLog(Exception e, StreamWriter log)
        {
            log.WriteLine("Exception log:");
            log.WriteLine();
            log.WriteLine("Timestamp:");
            log.WriteLine(DateTime.Now.ToString());
            log.WriteLine();
            log.WriteLine("Type:");
            log.WriteLine(e.GetType());
            log.WriteLine();
            log.WriteLine("Message:");
            log.WriteLine(e.Message);
            log.WriteLine();
            log.WriteLine("StackTrace:");
            log.WriteLine(e.StackTrace);
            log.WriteLine();
            log.WriteLine("------------------------------");
            log.WriteLine("------------------------------");
            log.WriteLine();
        }
    }
}
