using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5.Task2._1
{
    public class ConsoleLogger : ILogger
    {
        public readonly string _className;

        public ConsoleLogger()
        {
            _className = this.GetType().Name;
        }
        public ConsoleLogger(string className)
        {
            _className = className;
        }

        public void Trace(string message)
        {
            Log(message, LogLevel.Trace);
        }

        public void Info(string message)
        {
            Log(message, LogLevel.Info);
        }

        public void Debug(string message)
        {
            Log(message, LogLevel.Debug);
        }

        public void Warning(string message)
        {
            Log(message, LogLevel.Warning);
        }

        public void Error(string message)
        {
            Log(message, LogLevel.Error);
        }

        public void Fatal(string message)
        {
            Log(message, LogLevel.Fatal);
        }

        public void Log(string message, LogLevel level)
        {
            string LogMessage = FormatLogMessage(message, level);
            Console.WriteLine(LogMessage);
        }



        public string FormatLogMessage(string message, LogLevel level)
        {
            string dateTime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            return $"{dateTime} | {_className} | {level} | {message}";
            
        }
    }
}
