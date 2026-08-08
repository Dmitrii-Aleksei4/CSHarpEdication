using CodenamesCore.GameLogic;
using CodenamesCore.Model;
using CodenameWeb.Models;
namespace CodenameWeb.Components.Pages
{
    public partial class BattleGames3
    {
        private MethodsGames methodsGames;
        private MethodsDB methodsDB;
        private MethodsKeyBord methodsKeyBord;

        private BattleGame battleGame;





        // ===== ДАННЫЕ =====
        private List<Card> Cards = new();

        protected override void OnInitialized()
        {
            Cards = new List<Card>();
            battleGame = methodsGames.GetAllDiktWords(methodsDB.GetAllDiktWords(), 5, 5);

            // ВАШ ЦИКЛ ИЗ BATTLEGAME
            for (int y = 0; y < battleGame.ListWordsGame.Count; y++)
            {
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
                        _ => "white"  // или любой другой цвет по умолчанию
                    };

                    Cards.Add(new Card
                    {
                        Text = word,
                        ColorClass = colorClass
                    });
                }
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

        public BattleGames3()
        {
            methodsGames = new MethodsGames();

            methodsDB = new MethodsDB();
            methodsKeyBord = new MethodsKeyBord();
        }
    }
}
