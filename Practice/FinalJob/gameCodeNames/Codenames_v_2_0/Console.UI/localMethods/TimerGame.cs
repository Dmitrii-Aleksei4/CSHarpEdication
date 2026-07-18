using System;
using System.Threading;
using System.Threading.Tasks;
using Consol.UI;
using CodenamesCore.GameLogic;
using CodenamesCore.Model;

namespace Consol.UI
{
    public class TimerGame
    {
        private UI screen { get; set; }
        private MethodsGames methodsGames { get; set; }

        public TimerGame()
        {
            screen = new UI();
            methodsGames = new MethodsGames();
        }

        private CancellationTokenSource _cts;  // Источник токена отмены
        
        public async Task Start(int time, int curTimeX, int curTimeY, Action onComplete)
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
                    screen.InfoScreen($"Оставшееся время команды: {minuts}:{second}");
                    await Task.Delay(1000, _cts.Token);  // Передаем токен в Delay
                    
                }
                onComplete?.Invoke();

            }
            catch (OperationCanceledException)
            {
               // screen.InfoScreen("Таймер остановлен по запросу");
                _cts.Dispose();
                _cts = null;
            }
            finally
            {
                
                _cts = null;
            }
        }

        public async Task Stop()
        {
            if (_cts != null)
            {
               // Console.WriteLine("Запрос остановки таймера...");
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