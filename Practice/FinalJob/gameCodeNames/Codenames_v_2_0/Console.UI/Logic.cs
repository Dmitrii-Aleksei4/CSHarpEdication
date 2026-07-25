using CodenamesCore.GameLogic;
using CodenamesCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Consol.UI
{
    public class Logic
    {
        private MethodsGames methodsGames;
        private UI ui;
        private MethodsDB methodsDB;
        private MethodsKeyBord methodsKeyBord;


        public void Run()
        {
            // буфер обмена  номер меню
            int inputNumberMenu;
            // буфер обмена информациооного сообщения
            string inputInfoMenu;
            // получения словаря
            //var battleGame = methodsGames.GetAllDiktWords(methodsDB.GetAllDiktWords());

            while (true)
            {
                //стартовый экран 
                ui.StartScrin();
                // получение номер меню и информациооного сообщения
                (inputNumberMenu, inputInfoMenu) = methodsKeyBord.GetMaxKeyBord(5);
                switch (inputNumberMenu)
                {
                    case 404: // неверный ввод
                        {
                            ui.InfoScreen(inputInfoMenu, 0.5, false, true);
                            break;
                        }
                    case 1: // игровое поле 5х5
                        {
                            ui.InfoScreen(inputInfoMenu, 0.5, false, true);

                            GameSettings(5, 5);
                            break;
                        }
                    case 2:// игровое поле 5х6
                        {
                            ui.InfoScreen(inputInfoMenu, 0.5, false, true);
                            GameSettings(5, 6);
                            break;
                        }
                    case 3: // Свое игровое поле
                        {
                            ui.InfoScreen(inputInfoMenu, 0.5, false, true);
                            //ui.ChoiseSettingBattleScrin();
                            GameSettings(2, 3);
                            break;
                        }
                    case 4: // получение правил
                        {
                            ui.InfoScreen(inputInfoMenu, 0.5, false, true);
                            ui.InfoScreen(methodsDB.GetRulesGame(), 1, false, false);
                            Console.ReadKey();
                            ui.InfoScreen("", 0, false, true);
                            break;
                        }
                    case 5: // выход
                        {

                            ui.InfoScreen(inputInfoMenu, 0.5, false, true);
                            ui.InfoScreen("Спасибо что поиграли в нашу игру", 2, false, true);
                            Environment.Exit(0);
                            break;
                        }
                }
            }

        }

        public void GameSettings(int y, int x)
        {
            // получения словаря
            var battleGame = methodsGames.GetAllDiktWords(methodsDB.GetAllDiktWords(), y, x);
            // буфер обмена  номер меню
            int inputNumberMenu;
            // буфер обмена информациооного сообщения
            string inputInfoMenu;
            // получения словаря
            while (true)
            {
                //стартовый экран 

                ui.ChoiseSettingBattleScrin();
                // получение номер меню и информациооного сообщения
                (inputNumberMenu, inputInfoMenu) = methodsKeyBord.GetMaxKeyBord(6);
                switch (inputNumberMenu)
                {
                    case 404: // неверный ввод
                        {
                            ui.InfoScreen(inputInfoMenu, 1, false, true);

                            break;
                        }
                    case 1: // Настройка таймеров
                        {
                            ui.InfoScreen("Пока не готово", 1, false, true);
                            break;
                        }
                    case 2:// Поле для капитанов
                        {
                            ui.InfoScreen(inputInfoMenu, 1, false, true);
                            ui.CapitansBattleScrin(battleGame);
                            ui.InfoScreen("Для возврата в предудущее меню, нажмите любую клавишу", 0, false, false);
                            
                            Console.ReadKey();
                            ui.InfoScreen("", 0, false, true);
                            break;
                        }
                    case 3: // Игровое поле
                        {
                            ui.InfoScreen(inputInfoMenu, 1, false, true);
                            ui.UsersBattleScrin(battleGame);
                            ui.InfoScreen("Начнем игровую ссесию? y/n ?", 1, false, false);
                            (inputNumberMenu, inputInfoMenu) = methodsKeyBord.GetYesNoKeyBord();
                            // буфер обмена информациооного сообщения
                            if (inputNumberMenu == 1) { StartGame(battleGame); }

                            ui.InfoScreen("", 0, false, true);
                            break;
                        }


                    case 4: // Обновление игрового поля
                        {
                            ui.InfoScreen("Игровое поле обновлено!!!", 1, false, true);
                            battleGame = methodsGames.GetAllDiktWords(methodsDB.GetAllDiktWords(), y, x);
                            break;
                        }

                    case 5: // Словарь
                        {
                            ui.InfoScreen(inputInfoMenu, 1, false, true);
                            ui.InfoScreen(string.Join(", " ,methodsDB.GetAllDiktWords()), 1, false, false);
                            Console.ReadKey();
                            ui.InfoScreen("", 0, false, true);
                            break;
                        }
                    case 6: // выход
                        {

                            ui.InfoScreen(inputInfoMenu, 1, false, true);
                            //ui.InfoScreen("Спасибо что поиграли в нашу игру", 2, false, true);
                            Run();
                            break;
                        }

                }
            }
        }

        public void StartGame(BattleGame battleGame)
        {
            ui.InfoScreen("Время для раздумия капитанов пошло");

            int curTimeX = Console.CursorLeft;
            int curTimeY = Console.CursorTop;

            //Купаск таймера 
            TimerGame timer = new TimerGame();
            timer.Start(battleGame.Timer.CapStepOne, curTimeX, curTimeY, "Оставшееся время на раздумие капитанов", () =>
            {
                // запускаем осной потом игры по одно из условий не выполниться 
                ui.InfoScreen("", 0, true, true);
                while (battleGame.RulesAgents[RolesSpies.red] != 0 && battleGame.RulesAgents[RolesSpies.blue] != 0 && battleGame.RulesAgents[RolesSpies.black] != 0)
                {
                    GameStepTwo(battleGame);
                    if (battleGame.RulesAgents[RolesSpies.red] != 0 && battleGame.RulesAgents[RolesSpies.blue] != 0 && battleGame.RulesAgents[RolesSpies.black] != 0)
                    {
                        break;
                    }

                    TimeCaptians(battleGame);

                }
                
            });

            if (battleGame.RulesAgents[RolesSpies.red] > battleGame.RulesAgents[RolesSpies.blue])
            {

                battleGame.NameCommand[2] = battleGame.NameCommand[1];
                ui.InfoScreen($"По окончанию/досрочному завершению времени первые ходят {battleGame.NameCommand[2]} ");
            }
            else
            {
                battleGame.NameCommand[2] = battleGame.NameCommand[0];
                ui.InfoScreen($"По окончанию/досрочному завершению времени первые ходят {battleGame.NameCommand[2]} ");
            }

            while (true)
            {
                ui.InfoScreen("Готовы капитан готов начать ? y/n ?", 1, false, false);
                (int inputNumberMenu, string inputInfoMenu) = methodsKeyBord.GetYesNoKeyBord();
                // буфер обмена информациооного сообщения
                if (inputNumberMenu == 0)
                { ui.InfoScreen("Капитаны думаю дальше", 0, false, false); }
                else
                {
                    timer.Stop();
                    // запускаем осной потом игры по одно из условий не выполниться 
                    ui.InfoScreen("", 0, true, true);
                    while (battleGame.RulesAgents[RolesSpies.red] != 0 && battleGame.RulesAgents[RolesSpies.blue] != 0 && battleGame.RulesAgents[RolesSpies.black] != 0)
                    {
                        GameStepTwo(battleGame);
                        if(battleGame.RulesAgents[RolesSpies.red] == 0 || battleGame.RulesAgents[RolesSpies.blue] == 0 || battleGame.RulesAgents[RolesSpies.black] == 0)
                        {
                            break;
                        }
                        
                        TimeCaptians(battleGame);

                    }
                    break;
                }

            }

        }
        /// <summary>
        /// обработчик ходом игроков
        /// </summary>
        /// <param name="battleGame"></param>
        public void GameStepTwo(BattleGame battleGame)
        {

            // показатель что таймер запущен 
            bool timerIndicator = true;
            //сброс цикца
            bool whileIndicator = true;
            // набор использованных слов
            List<string> inputListWords = new List<string> { };
            //string inputWords = $"Введеные слова: {string.Join(", ",inputListWords)}";
            TimerGame timer = new TimerGame();
            while (whileIndicator)
            {
                // блок вывода на экран 
                ui.InfoScreen("", 0, true, true);
                ui.UsersBattleScrin(battleGame);
                ui.whoseMoveColorScreen("Сейчас ходит ", battleGame.NameCommand[2]);
                //33ui.InfoScreen($"Сейчас ходят {battleGame.NameCommand[2]}");
                ui.InfoScreen("Вводите слова по одному через Enter ");
                ui.InfoScreen($"Введеные слова: {string.Join(", ", inputListWords)}");
                // координаты для таймера
                int curTimeX = Console.CursorLeft;
                int curTimeY = Console.CursorTop;


                if (timerIndicator == true)
                {
                    timerIndicator = false;

                    //Запуск таймера 
                    timer.Start(battleGame.Timer.ComandsThinls, curTimeX, curTimeY, "Оставшееся время команды", () =>
                    {
                        whileIndicator = false;
                        timerIndicator = true;
                        battleGame.NameCommand[2] = battleGame.NameCommand[1] == battleGame.NameCommand[2] ? battleGame.NameCommand[0] : battleGame.NameCommand[1];
                        return;
                       

                    });

                }
                Console.SetCursorPosition(curTimeX, curTimeY + 1);
                var input = methodsKeyBord.GetInputAnswer();
                Console.SetCursorPosition(curTimeX, curTimeY + 2);
                ui.InfoScreen("");
                Console.SetCursorPosition(curTimeX, curTimeY + 3);

                // запись количества проходов 
                int repeatIndicator = 0;

                for (int y = 0; y < battleGame.ListWordsGame.Count; y++)
                {
                    for (int x = 0; x < battleGame.ListWordsGame[y].Count; x++)
                    {

                        // сравниваем каждую ячейку слова
                        if (battleGame.ListWordsGame[y][x].SecretWords.Keys.FirstOrDefault().ToLower() == input) 
                        {
                            // делаем видимый цвет ячейки (
                            if(!battleGame.ListWordsGame[y][x].VisibilityColor)
                            {
                                battleGame.ListWordsGame[y][x].VisibilityColor = true;
                            }
                            else
                            {
                                continue;
                            }                            


                            // сверяем цвет ячейки с цветом команды RED ( используя ключ открываем словарь чтобы узнать цвет)
                            if (battleGame.ListWordsGame[y][x].SecretWords[char.ToUpper(input[0]) + input.Substring(1).ToLower()] == RolesSpies.red)

                            {
                                // если одинаковый игра продолжается
                                // вычитаем из списка команд 1 агента красной команды
                                battleGame.RulesAgents[RolesSpies.red]--;

                                if (battleGame.RulesAgents[RolesSpies.red] == 0)
                                {
                                    timer.Stop();
                                    whileIndicator = false;
                                    // ПРОВЕРКА НА ПОБЕДУ ПРОТИВОПОЛОЖНОЙ КОМАНДЫ 
                                    if (battleGame.NameCommand[2] != battleGame.NameCommand[1])
                                    {
                                        battleGame.NameCommand[2] = battleGame.NameCommand[1];
                                        CheckVictory(battleGame, "Победил");
                                    }


                                    CheckVictory(battleGame, "Победил");
                                    
                                    return;
                                 
                                }
                                // если цвет слова и команды  не одинаковый ход прервывается 
                                if (battleGame.NameCommand[2] != battleGame.NameCommand[1])
                                {
                                    timer.Stop();
                                    ui.InfoScreen("Переход хода ", 2);
                                    timerIndicator = true;
                                    battleGame.NameCommand[2] = battleGame.NameCommand[1];
                                    return;
                                    
                                }
                            }

                            // сверяем цвет ячейки с цветом команды BLUE ( используя ключ открываем словарь чтобы узнать цвет)
                            if (battleGame.ListWordsGame[y][x].SecretWords[char.ToUpper(input[0]) + input.Substring(1).ToLower()] == RolesSpies.blue)
                            {
                                battleGame.RulesAgents[RolesSpies.blue]--;

                                if (battleGame.RulesAgents[RolesSpies.blue] == 0)
                                {
                                    timer.Stop();
                                    whileIndicator = false;
                                    // ПРОВЕРКА НА ПОБЕДУ ПРОТИВОПОЛОЖНОЙ КОМАНДЫ 
                                    if (battleGame.NameCommand[2] != battleGame.NameCommand[0])
                                    {
                                        battleGame.NameCommand[2] = battleGame.NameCommand[0];
                                        CheckVictory(battleGame, "Победил");
                                    }

                                    CheckVictory(battleGame, "Победил");
                                    return;
                                   
                                }
                                // если цвет слова и команды  не одинаковый ход прервывается 
                                if (battleGame.NameCommand[2] != battleGame.NameCommand[0])
                                {
                                    timer.Stop();
                                    ui.InfoScreen("Переход хода ", 2);
                                    timerIndicator = true;
                                    battleGame.NameCommand[2] = battleGame.NameCommand[0];
                                    return;
                                    
                                }

                            }



                            // если черный цвет игра проиграна 
                            if (battleGame.ListWordsGame[y][x].SecretWords[char.ToUpper(input[0]) + input.Substring(1).ToLower()] == RolesSpies.black)
                            {
                                timer.Stop();
                                battleGame.RulesAgents[RolesSpies.black] = 0;
                                CheckVictory(battleGame, "ПРОИГРАЛ");
                                whileIndicator = false;
                                //прекращение обхода оси X
                                return;
                                
                            }

                        }
                        else
                        {
                            repeatIndicator++;
                        }
                    }
                    /*if (repeatIndicator == battleGame.ListWordsGame.Count * battleGame.ListWordsGame[y].Count)
                    {
                        inputListWords.Add(input + "(Нет такого слова)");
                     

                    } */
                    // прекращение цикла фор по оси Y
                    if (!whileIndicator) { break; }
                }
                //пополняем списко слов
                if (repeatIndicator == battleGame.ListWordsGame.Count * battleGame.ListWordsGame[0].Count)
                {
                    inputListWords.Add(input + "(Нет такого слова)");
                }
                else
                {
                    inputListWords.Add(input);

                }

                //   Console.ReadKey();

            }
        }

        /// <summary>
        /// Обработка раздумий капитанов
        /// </summary>
        /// <param name="battleGame"></param>
        public void TimeCaptians(BattleGame battleGame)

        {


            // показатель что таймер запущен 
            bool timerIndicator = true;

            //сброс цикца
            bool whileIndicator = true;



            TimerGame timer = new TimerGame();
            while (whileIndicator)
            {
                // блок вывода на экран 
                ui.InfoScreen("", 0, true, true);
                ui.UsersBattleScrin(battleGame);
                ui.whoseMoveColorScreen("Сейчас думает капитан ", battleGame.NameCommand[2]);
              
                // координаты курсора для таймера 
                int curTimeX = Console.CursorLeft;
                int curTimeY = Console.CursorTop;


                if (timerIndicator == true)
                {
                    timerIndicator = false;

                    //Купаск таймера 

                    timer.Start(battleGame.Timer.CaptainThinks, curTimeX, curTimeY, "Оставшееся время на раздумие капитана", () =>
                    {
                        whileIndicator = false;
                        timerIndicator = true;
                        return;
                       
                    });

                }
                while (whileIndicator)
                {
                    ui.InfoScreen("Готовы капитан готов начать ? y/n ?", 1, false, false);
                    (int inputNumberMenu, string inputInfoMenu) = methodsKeyBord.GetYesNoKeyBord();
                    // буфер обмена информациооного сообщения
                    if (inputNumberMenu == 0)
                    { ui.InfoScreen("Капитаны думаю дальше", 0, false, false); }
                    else
                    {
                        timer.Stop();
                        ui.InfoScreen("", 0, true, true);
                        
                        whileIndicator = false;
                        return;
                        
                    }

                }



            }

        }

        /*
        public void CheckColorWords(BattleGame battleGame, int y, int x,TimerGame timer,string input, RolesSpies Color)
        {

            // сверяем цвет ячейки с цветом команды RED ( используя ключ открываем словарь чтобы узнать цвет)
            if (battleGame.ListWordsGame[y][x].SecretWords[char.ToUpper(input[0]) + input.Substring(1).ToLower()] == RolesSpies.red)

            {
                // если одинаковый игра продолжается
                // вычитаем из списка команд 1 агента красной команды
                battleGame.RulesAgents[RolesSpies.red]--;

                if (battleGame.RulesAgents[RolesSpies.red] == 0)
                {
                    timer.Stop();
                    whileIndicator = false;
                    // ПРОВЕРКА НА ПОБЕДУ ПРОТИВОПОЛОЖНОЙ КОМАНДЫ 
                    if (battleGame.NameCommand[2] != battleGame.NameCommand[1])
                    {
                        battleGame.NameCommand[2] = battleGame.NameCommand[1];
                        CheckVictory(battleGame, "Победил");
                    }


                    CheckVictory(battleGame, "Победил");

                    return;

                }
                // если цвет слова и команды  не одинаковый ход прервывается 
                if (battleGame.NameCommand[2] != battleGame.NameCommand[1])
                {
                    timer.Stop();
                    ui.InfoScreen("Переход хода ", 2);
                    timerIndicator = true;
                    battleGame.NameCommand[2] = battleGame.NameCommand[1];
                    return;

                }
            }
        }
        */


        /// <summary>
        /// Обявление победителя
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="whileIndicator"></param>
        public void CheckVictory(BattleGame battleGame, string info)
        {
            ui.InfoScreen("", 0, false, true);
            ui.UsersBattleScrin(battleGame);
            ui.InfoScreen($"{battleGame.NameCommand[2]} - {info}", 5);
        }


        /// <summary>
        /// Конструктор логики
        /// </summary>
        public Logic()
        {
            methodsGames = new MethodsGames();
            ui = new UI();
            methodsDB = new MethodsDB();
            methodsKeyBord = new MethodsKeyBord();
        }
    }
}
