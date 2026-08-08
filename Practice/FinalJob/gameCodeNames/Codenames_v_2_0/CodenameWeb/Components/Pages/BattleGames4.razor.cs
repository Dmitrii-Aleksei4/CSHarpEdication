using CodenamesCore.GameLogic;
using CodenamesCore.Model;
using CodenameWeb.Models;

namespace CodenameWeb.Components.Pages
{
    public partial class BattleGames4
    {
        private MethodsGames methodsGames;
        private MethodsDB methodsDB;
        private MethodsKeyBord methodsKeyBord;

        private BattleGame battleGame;

        private string infoscrean;

        private bool showEndScrean;

        // таймера
        private int Seconds = 0;
        private bool IsRunning = false;
        private CancellationTokenSource? cts;
        // таймер конец


        // ===== ДАННЫЕ =====
        private List<List<Card>> Cards = new();

        protected override void OnInitialized()
        {
            Cards = new List<List<Card>>();
            battleGame = methodsGames.GetAllDiktWords(methodsDB.GetAllDiktWords(), 5, 5);

            // ВАШ ЦИКЛ ИЗ BATTLEGAME
            for (int y = 0; y < battleGame.ListWordsGame.Count; y++)
            {
                // ===== ВАЖНО: создаём новый список для каждой строки =====
                var row = new List<Card>();

                for (int x = 0; x < battleGame.ListWordsGame[y].Count; x++)
                {
                    var word = battleGame.ListWordsGame[y][x].DispleyScren();
                    var color = battleGame.ListWordsGame[y][x].SecretWords.FirstOrDefault().Value;

                    // ПРЕОБРАЗУЕМ ЦВЕТ В CSS-КЛАСС
                    string colorClass = color switch
                    {
                        RolesSpies.blue => "blue",
                        RolesSpies.red => "red",
                        RolesSpies.black => "black",
                        _ => "burlywood"
                    };

                    // Добавляем в строку
                    row.Add(new Card
                    {
                        Text = word,
                        ColorClass = colorClass
                    });
                }

                // ===== ВАЖНО: добавляем строку в Cards =====
                Cards.Add(row);
            }
        }

        // ===== ЛОГИКА =====
        private async Task StartHold(Card card)
        {
            if (card.IsFlipped || card.IsHolding) return;

            card.IsHolding = true;
            card.Progress = 100; // Устанавливаем 100% для анимации
            await InvokeAsync(StateHasChanged);

            // Только таймер переворота
            card.HoldTimer = new System.Timers.Timer(2000);
            card.HoldTimer.Elapsed += (s, e) =>
            {
                card.IsFlipped = true;
                card.IsHolding = false;
                card.HoldTimer?.Stop();
                card.HoldTimer?.Dispose();
                InvokeAsync(StateHasChanged);
                CheckAnswerWorks(card);
                
            };
            card.HoldTimer.Start();
        }

        private async Task CancelHold(Card card)
        {
            if (card.IsFlipped)
            {
                card.IsHolding = false;
                card.HoldTimer?.Stop();
                card.HoldTimer?.Dispose();
                card.ProgressTimer?.Stop();
                card.ProgressTimer?.Dispose();
                await InvokeAsync(StateHasChanged);
                return;
            }

            card.HoldTimer?.Stop();
            card.HoldTimer?.Dispose();
            card.ProgressTimer?.Stop();
            card.ProgressTimer?.Dispose();
            card.IsHolding = false;
            card.Progress = 0;
            await InvokeAsync(StateHasChanged);
        }

        public BattleGames4()
        {
            methodsGames = new MethodsGames();

            methodsDB = new MethodsDB();
            methodsKeyBord = new MethodsKeyBord();
        }


        public void CheckAnswerWorks(Card card)
        {
            if (card.ColorClass == "red")
            {
                battleGame.RulesAgents[RolesSpies.red]--;
            }
            if (card.ColorClass == "blue")
            {
                battleGame.RulesAgents[RolesSpies.blue]--;
            }


            if (battleGame.RulesAgents[RolesSpies.red] == 0 || battleGame.RulesAgents[RolesSpies.blue] == 0)
            {
                showEndScrean = true;
                infoscrean = "Вы выйграли";
                Stop();
            }
            if (card.ColorClass == "black")
            {
                showEndScrean = true;
                infoscrean = "Вы програли";
                Stop();
            }

        }

        private void ResetGame()
        {

            showEndScrean = false;
        }


        //таймер
        private async Task Start()
        {
            if (IsRunning) return;

            IsRunning = true;
            cts = new CancellationTokenSource();

            try
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    await Task.Delay(1000, cts.Token); // Каждую секунду
                    Seconds++;
                    await InvokeAsync(StateHasChanged);
                }
            }
            catch (TaskCanceledException)
            {
                // Остановлено
            }
            finally
            {
                IsRunning = false;
                await InvokeAsync(StateHasChanged);
            }
        }

        private void Stop()
        {
            cts?.Cancel();
            cts?.Dispose();
            cts = null;
        }

        private void Reset()
        {
            cts?.Cancel();
            cts?.Dispose();
            cts = null;
            IsRunning = false;
            Seconds = 0;
            StateHasChanged();
        }

        public void Dispose()
        {
            cts?.Cancel();
            cts?.Dispose();
        }
    }
}
