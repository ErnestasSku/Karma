using System;
using System.IO;

namespace Backend.Utils
{
    public static class Logger
    {

        private static string loggerFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Log.txt");

        public static void Error(String message)
        {
            File.AppendAllText(loggerFile, "[ERROR] - " + DateTime.Now.ToString() + " " + message + Environment.NewLine);
        }

        public static void Warning(String message)
        {
            File.AppendAllText(loggerFile, "[WARN] - " + DateTime.Now.ToString() + " " + message + Environment.NewLine);

        }

        public static void Info(String message)
        {
            File.AppendAllText(loggerFile, "[INFO] - " + DateTime.Now.ToString() + " " + message + Environment.NewLine);

        }
    }
}
