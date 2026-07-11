using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Practice5.Task2._1
{
    public class FileLogger : ILogger
    {
        public readonly string _className;
        public readonly string _filePath;
        // Коструктор со встроенным именем 
        public FileLogger(string FilePath = "log.txt")
        {
            _className = this.GetType().Name;
            _filePath = FilePath;
        }
        // Коструктор с передоваемым именем 
        public FileLogger(string className, string filePath = "log.txt")
        {
            _className = className;
            _filePath = filePath;
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
            WriteFile(LogMessage);
        }



        public string FormatLogMessage( string message, LogLevel level )
        {
            string dateTime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            return $"{dateTime} | {_className} | {level} | {message}";
        }

        private void WriteFile( string logMessage )
        {
            try
            {
                // Создаем директорию 
                string directory = Path.GetDirectoryName(_filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Запись файла
                File.AppendAllText(_filePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
            }
        }
    }
}
