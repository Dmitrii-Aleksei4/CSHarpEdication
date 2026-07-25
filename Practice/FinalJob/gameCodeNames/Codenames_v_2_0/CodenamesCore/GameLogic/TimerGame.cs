using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodenamesCore.GameLogic
{
    public class TimerGame2
    {
        private CancellationTokenSource _cts;  // Источник токена отмены
        
        public async Task Start(int time, int curTimeX, int curTimeY)
        {
            // Создаем новый источник отмены при каждом запуске
            _cts = new CancellationTokenSource();
            int second, minuts;
            try
            {
                for (int i = time; i > -1; i--)
                {
                    // Проверяем, не запрошена ли отмена
                    _cts.Token.ThrowIfCancellationRequested();
                    Console.SetCursorPosition(curTimeX, curTimeY);
                    minuts = i / 60; second = i % 60;
                    Console.WriteLine($"в {minuts}:{second}");
                    await Task.Delay(1000, _cts.Token);  // Передаем токен в Delay
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Таймер остановлен по запросу");
            }
            finally
            {
                _cts.Dispose();
                _cts = null;
            }
        }

        public async Task Stop()
        {
            if (_cts != null)
            {
                Console.WriteLine("Запрос остановки таймера...");
                _cts.Cancel();  // Отменяем операцию

                // Небольшая задержка, чтобы дать время на обработку отмены
                await Task.Delay(100);
            }
            else
            {
              //  Console.WriteLine("Таймер не запущен");
            }
        }
    }
}