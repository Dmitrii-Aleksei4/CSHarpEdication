using Practice5.Task2._1;
namespace Practice5.Task2;

internal class Program
{
    static void Main(string[] args)
    {

        // ===== ConsoleLogger =====
        Console.WriteLine("=== ConsoleLogger ===");
        ILogger consoleLogger = new ConsoleLogger("MyApp");

        consoleLogger.Trace("Начало работы приложения");
        consoleLogger.Info("Пользователь вошел в систему");
        consoleLogger.Debug("Загружено 10 записей");
        consoleLogger.Warning("Подключение к БД медленное");
        consoleLogger.Error("Ошибка при сохранении данных");
        consoleLogger.Fatal("Критическая ошибка! Приложение завершается");

        Console.WriteLine("\n=== FileLogger ===");

        // ===== FileLogger =====
        ILogger fileLogger = new FileLogger("MyApp", "logs/app.log");

        fileLogger.Trace("Начало работы приложения");
        fileLogger.Info("Пользователь вошел в систему");
        fileLogger.Debug("Загружено 10 записей");
        fileLogger.Warning("Подключение к БД медленное");
        fileLogger.Error("Ошибка при сохранении данных");
        fileLogger.Fatal("Критическая ошибка! Приложение завершается");
        Console.WriteLine("\nЛоги записаны в файл: logs/app.log");

        // ===== Использование Log с указанием уровня =====
        Console.WriteLine("\n=== Log с указанием уровня ===");
        ILogger logger = new ConsoleLogger("TestApp");

        logger.Log("Это сообщение с уровнем Info", LogLevel.Info);
        logger.Log("Это сообщение с уровнем Error", LogLevel.Error);
        logger.Log("Это сообщение с уровнем Warning", LogLevel.Warning);

        Console.ReadKey();
        


        Console.ReadKey();
    }
}
