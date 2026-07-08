using System.Numerics;

namespace TicAndTac6
{
    ///================================
    // Игрок(и) // модель (данные)
    ///================================
    ///


    class HistotySteps
    {
        public List<string> History { get; set; } = new List<string>();

        public void Reset()
        {
            History = new List<string>();
        }
    }


    class Players
    {
        private int _count = 0;
        public string Name { get; set; }
        public string GameX_O { get; set; }
        public int Vin_Ai { get; set; }
        public int Loss_Ai { get; set; }
        public int Vin_Hum { get; set; }
        public int Loss_Hum { get; set; }
        public ConsoleColor Color { get; set; }

        public Players(string name)
        {
            Name = name;
        }
        public Players()
        {

        }
    }

    // Игровое поле  // модель (данные)
    public class Battles
    {
        private int CountDraw;
        //Объяление поля
        private string[,] Start_battle { get; } // стартовое поле
        public string[,] Game_battle { get; set; }// дубликат для работы с полем



        // Конструктор
        public Battles()
        {

            Start_battle = new string[,]{{"1,1","1,2","1,3"},
                                          {"2,1","2,2","2,3"},
                                          {"3,1","3,2","3,3"}};


            Reset_Battle();
        }

        public void Reset_Battle()
        {
            Game_battle = (string[,])Start_battle.Clone();
            CountDraw = 0;
        }

        // провека ячейки на занятость
        public bool CheckCell(int y, int x)
        {
            if (Game_battle[y, x] == " X " || Game_battle[y, x] == " O ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //провека выйгрыша игрока
        public bool CheckVin(string x_o)
        {
            x_o = $" {x_o} ";

            for (int i = 0; i < 3; i++)
            {
                if (Game_battle[0, i] == x_o && Game_battle[1, i] == x_o && Game_battle[2, i] == x_o)
                {
                    return true;
                }
                if (Game_battle[i, 0] == x_o && Game_battle[i, 1] == x_o && Game_battle[i, 2] == x_o)
                {
                    return true;
                }

            }

            if (Game_battle[0, 0] == x_o && Game_battle[1, 1] == x_o && Game_battle[2, 2] == x_o)
            {
                return true;
            }
            else if (Game_battle[2, 0] == x_o && Game_battle[1, 1] == x_o && Game_battle[0, 2] == x_o)
            {
                return true;
            }
            CountDraw++;
            return false;

        }
        //провека ничьей 
        public bool CheckDraw()
        {
            if (CountDraw == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void UpdateGameBattle(int y, int x, string GameX_O)
        {
            Game_battle[y, x] = $" {GameX_O} ";
        }

    }

    ///================================
    // ПРЕДСТАВЛЕНИЯ VIEW  - Отвечает за ввод и вывод
    ///================================
    class Screens
    {
        // Стартовый экран
        public void ShowStartScreen()
        {
            Console.Clear();   // очищаем экран
            Console.WriteLine("     Добро пожаловать!");
            Console.WriteLine("    Крестики и Нолики \n");
            Console.WriteLine("Выберите режим игры:\n");
            Console.WriteLine(" 1. Один игрок (против ПК)");
            Console.WriteLine(" 2. Два игрока");
            Console.WriteLine(" 3. Выход\n");
            Console.WriteLine(new string('-', 26));
        }
        // Получение ответа от стартового экрана
        public int GetStartScreenChoice()
        {
            while (true)
            {
                Console.Write("Ваш выбор (1-3): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)
                    return choice;  // вернули правильное число

                Console.WriteLine("Неверный ввод! Введите 1, 2 или 3.");
            }
        }
        // Экран первого вызова (Заглушка)
        public void ShowOnePleyerScreen2()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("В разработке");
            Thread.Sleep(2000);

        }
        public (string, string, ConsoleColor) ShowOnePleyerScreen(Players players1)
        {
            string name, symbol;
            ConsoleColor color;
            Console.Clear();
            Console.WriteLine("Ведите имя первого игрока. По умолчания(Игрок 1)");
            name = Console.ReadLine().Trim();
            name = name == "" ? players1.Name : name;
            while (true)
            {

                Console.WriteLine("Ведите символ игрока Х или O");
                symbol = Console.ReadLine().Trim().ToUpper();
                if (symbol == "X" || symbol == "O")
                {
                    color = symbol == "X" ? ConsoleColor.Red : ConsoleColor.Blue;
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный символ!! Введите на ангилйском X или O");
                }

            }
            return (name, symbol, color);
        }
        // экран второго вызова
        public (string, string, ConsoleColor) ShowTwoPlayersScreen(Players players1, Players players2)
        {

            string name, symbol;
            ConsoleColor color;
            Console.Clear();
            Console.WriteLine("Ведите имя первого игрока. По умолчания(Игрок 1/2)");
            name = Console.ReadLine().Trim();
            name = name == "" ? players1.Name : name;
            while (true)
            {
                if (players1.GameX_O == null)
                {
                    Console.WriteLine("Ведите символ игрока Х или O");
                    symbol = Console.ReadLine().Trim().ToUpper();
                    if (symbol == "X" || symbol == "O")
                    {
                        color = symbol == "X" ? ConsoleColor.Red : ConsoleColor.Blue;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверный символ!! Введите на ангилйском X или O");
                    }
                }
                else
                {

                    name = name == players1.Name ? "Игрок 2" : name;
                    symbol = players1.GameX_O == "X" ? "O" : "X";
                    color = symbol == "X" ? ConsoleColor.Red : ConsoleColor.Blue;
                    break;
                }

            }
            return (name, symbol, color);
        }

        // Экран третьего вызова

        public void FinallScreen()
        {
            Console.Clear();
            Console.WriteLine("Спасибо что поиграли с нами");
            Thread.Sleep(2000);
        }


        //Экран поля битвы
        public void ShowBattleScreen(string[,] battle, Players player1, Players player2, List<string> history)
        {
            Console.Clear();

            Console.SetCursorPosition(1, 1);
            Console.BackgroundColor = player1.Color;
            Console.Write($"Игрок {player1.Name,7} ходит {player1.GameX_O} счет {player1.Vin_Hum}");

            Console.SetCursorPosition(1, 2);
            Console.BackgroundColor = player2.Color;
            Console.Write($"Игрок {player2.Name,7} ходит {player2.GameX_O} счет {player2.Vin_Hum}");
            Console.BackgroundColor = ConsoleColor.Black;

            int coordX = 35, coordY = 1;

            for (int y = 0; y < battle.GetLength(0); y++)
            {
                Console.SetCursorPosition(coordX, coordY + y);
                for (int x = 0; x < battle.GetLength(1); x++)
                {
                    if (battle[y, x] == $" {player1.GameX_O} ")
                    {
                        Console.BackgroundColor = player1.Color;

                    }
                    else if (battle[y, x] == $" {player2.GameX_O} ")
                    {
                        Console.BackgroundColor = player2.Color;

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.Write($"{battle[y, x]}");
                    if (x < 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("|");
                    }
                }

                Console.SetCursorPosition(coordX, coordY + y + 1);
                if (y < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("-----------");
                }
                coordY++;

            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(48, 1);
            Console.WriteLine("История ходов");

            for (int i = 0; i < history.Count(); i++)
            {
                Console.SetCursorPosition(50, i + 2);
                Console.WriteLine($"{i + 1}. {history[i]}");


            }


            Console.SetCursorPosition(0, 7);
        }

        // Кто ходит первым 
        public string WhoGoesFirst()
        {
            Console.Clear();
            string answer;
            Console.WriteLine("Кто бодит первым ? X или O");

            while (true)
            {
                answer = Console.ReadLine().Trim().ToUpper();
                if (answer == "X" || answer == "O")
                {
                    return answer;
                }
                else
                {
                    Console.WriteLine("Ответ не ясный, введите символо Х или O на английском языке");
                }
            }
        }
        public (int, int) GetСoordSymbols(Players player)
        {
            while (true)
            {
                string[] lenMas = ["1", "2", "3"];
                string coordSymbol;

                Console.WriteLine($"Введите координаты {player.Name} в формате \n" +
                              "номер строки, номер столбика.\n" +
                              "Пример: 13 или 22");
                coordSymbol = Console.ReadLine().Trim().ToLower();

                if (coordSymbol.Length != 2)
                { Console.WriteLine("Мало или много символов"); continue; }

                if (!lenMas.Contains(coordSymbol[0].ToString()))
                { Console.WriteLine("Неверные первые координаты"); continue; }

                if (!lenMas.Contains(coordSymbol[1].ToString()))
                { Console.WriteLine("Неверные вторые координаты"); continue; }

                // переводим координаты из чар в int
                return ((coordSymbol[0] - '0') - 1, (coordSymbol[1] - '0') - 1);


            }
        }

        public void ShowMesseng(string messeng)
        {
            Console.WriteLine(messeng);
        }

        public void ShowReplayRound()
        {
            string answer;
            Console.WriteLine(" Играем повторно? y/n, exit?");
        }

        public string GetReplayRound()
        {

            while (true)
            {
                Console.WriteLine("Ваш выбор: y , n, exti");
                string answer = Console.ReadLine().ToLower().Trim();
                if (answer == "n" || answer == "y" || answer == "exit")
                {
                    return answer;
                }
                Console.WriteLine("Неверный ввод. Введите y, n или  exti?");
            }
        }
    }





    ///================================
    // ЛОГИКА
    ///================================

    class Game
    {
        Screens Screen;

        Players WhoPlayers;
        Players[] Player;
        Battles Battle;
        HistotySteps HistotyStep;
        public Game()
        {
            Screen = new Screens();
            WhoPlayers = new Players();

            Player = new Players[] { new Players("Игрок 1"), new Players("Игрок 2") };
            Battle = new Battles();

            HistotyStep = new HistotySteps();
        }

        public void Run()
        {
            Screen.ShowStartScreen();
            int choiseStartScreen = Screen.GetStartScreenChoice();

            switch (choiseStartScreen)
            {
                case 1:
                    InitOnePlayers();
                    break;
                case 2:
                    InitTwoPlayers();
                    break;
                case 3:
                    Screen.FinallScreen();
                    break;

            }

        }



        public void InitOnePlayers()
        {
            (Player[0].Name, Player[0].GameX_O, Player[0].Color) = Screen.ShowOnePleyerScreen(Player[0]);
            Player[1].Name = "T-1000";
            Player[1].GameX_O = Player[0].GameX_O == "X" ? "O" : "X";
            Player[1].Color = Player[0].Color == ConsoleColor.Red ? ConsoleColor.Blue : ConsoleColor.Red;
            //Screen.ShowLevel();
            GameRoundOnePlayer(1);
        }


        public void GameRoundOnePlayer(int stepII)
        {
            HistotyStep.Reset();
            Battle.Reset_Battle();
            string WhoGoesFirst = Screen.WhoGoesFirst();// кто первый ходит крестик или нолик
            WhoPlayers = WhoGoesFirst == Player[0].GameX_O ? Player[0] : Player[1];
            while (true)// обход 
            {
                int y, x;
                Screen.ShowBattleScreen(Battle.Game_battle, Player[0], Player[1], HistotyStep.History);
                if (WhoPlayers == Player[1])
                {
                    y = Random.Shared.Next(0, 3);
                    x = Random.Shared.Next(0, 3);
                }
                else
                {
                    (y, x) = Screen.GetСoordSymbols(WhoPlayers);
                }

                if (Battle.CheckCell(y, x))
                {
                    if (WhoPlayers != Player[1])
                    {
                        Screen.ShowMesseng("Клетка занята");
                        Thread.Sleep(2000);
                    }

                    continue;
                }
                // ставим символ
                Battle.UpdateGameBattle(y, x, WhoPlayers.GameX_O);

                // запись в журнал
                HistotyStep.History.Add($"{WhoPlayers.Name,7} ({WhoPlayers.GameX_O}) коорд: {y + 1},{x + 1}");

                Screen.ShowBattleScreen(Battle.Game_battle, Player[0], Player[1], HistotyStep.History);

                // провека на победу
                if (Battle.CheckVin(WhoPlayers.GameX_O))
                {
                    WhoPlayers.Vin_Hum++;
                    Screen.ShowMesseng($"Победа {WhoPlayers.Name}");
                    break;
                }
                //провека ничьей 
                if (Battle.CheckDraw())
                {
                    Screen.ShowMesseng($" НИЧЬЯ ");
                    break;
                }

                WhoPlayers = WhoPlayers == Player[0] ? Player[1] : Player[0];


            }
            Screen.ShowReplayRound();
            string answerReplayRound = Screen.GetReplayRound();

            switch (answerReplayRound)
            {
                case "y":
                    GameRoundOnePlayer(1);
                    break;


                case "n":
                    Run();
                    break;

                case "exit":
                    Screen.FinallScreen();
                    break;

            }


        }
        public void InitTwoPlayers()
        {
            (Player[0].Name, Player[0].GameX_O, Player[0].Color) = Screen.ShowTwoPlayersScreen(Player[0], Player[1]);
            (Player[1].Name, Player[1].GameX_O, Player[1].Color) = Screen.ShowTwoPlayersScreen(Player[0], Player[1]);
            GameRoundTwoPlayer();

        }

        public void GameRoundTwoPlayer()
        {
            HistotyStep.Reset();
            Battle.Reset_Battle();
            string WhoGoesFirst = Screen.WhoGoesFirst();// кто первый ходит крестик или нолик
            WhoPlayers = WhoGoesFirst == Player[0].GameX_O ? Player[0] : Player[1];

            while (true)// обход 
            {

                Screen.ShowBattleScreen(Battle.Game_battle, Player[0], Player[1], HistotyStep.History);
                var (y, x) = Screen.GetСoordSymbols(WhoPlayers);

                if (Battle.CheckCell(y, x))
                {

                    Screen.ShowMesseng("Клетка занята");
                    Thread.Sleep(2000);
                    continue;
                }
                // ставим символ
                Battle.UpdateGameBattle(y, x, WhoPlayers.GameX_O);

                // запись в журнал
                HistotyStep.History.Add($"{WhoPlayers.Name,7} ({WhoPlayers.GameX_O}) коорд: {y + 1},{x + 1}");

                Screen.ShowBattleScreen(Battle.Game_battle, Player[0], Player[1], HistotyStep.History);

                // провека на победу
                if (Battle.CheckVin(WhoPlayers.GameX_O))
                {
                    WhoPlayers.Vin_Hum++;
                    Screen.ShowMesseng($"Победа {WhoPlayers.Name}");
                    break;
                }
                //провека ничьей 
                if (Battle.CheckDraw())
                {
                    Screen.ShowMesseng($" НИЧЬЯ ");
                    break;
                }

                WhoPlayers = WhoPlayers == Player[0] ? Player[1] : Player[0];


            }
            Screen.ShowReplayRound();
            string answerReplayRound = Screen.GetReplayRound();

            switch (answerReplayRound)
            {
                case "y":
                    GameRoundTwoPlayer();
                    break;


                case "n":
                    Run();
                    break;

                case "exit":
                    Screen.FinallScreen();
                    break;

            }



        }

    }



    ///================================
    // ТОЧКА ВХОДА
    ///================================

    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();


        }
    }
}
