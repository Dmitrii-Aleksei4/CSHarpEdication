using CodenamesCore.GameLogic;
using CodenamesCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System;
using System.Threading.Tasks;

namespace Consol.UI
{
    public class Logic2
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
                (inputNumberMenu,inputInfoMenu) = methodsKeyBord.GetMaxKeyBord(5);
                switch (inputNumberMenu)
                {
                    case 404: // неверный ввод
                        {
                            ui.InfoScreen(inputInfoMenu, 0.5, false, true);
                            break;
                        }
                    case 1: // игровое поле 5х5
                        {
                            ui.InfoScreen(inputInfoMenu,0.5,false,true);

                            GameSettings(5,5);
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
                            GameSettings(2,3);
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
                (inputNumberMenu, inputInfoMenu) = methodsKeyBord.GetMaxKeyBord(5);
                switch (inputNumberMenu)
                {
                    case 404: // неверный ввод
                        {
                            ui.InfoScreen(inputInfoMenu,1,false,true);

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
                            Console.ReadKey();
                            ui.InfoScreen("", 0, false, true);
                            break;
                        }
                    case 3: // Игровое поле
                        {
                            ui.InfoScreen(inputInfoMenu, 1, false, true);
                            ui.UsersBattleScrin(battleGame);
                            ui.InfoScreen("Начнем игровую ссесию? y/n ?", 1, false, false);
                            (inputNumberMenu,inputInfoMenu)  = methodsKeyBord.GetYesNoKeyBord() ;
                            // буфер обмена информациооного сообщения
                            if (inputNumberMenu ==1) { StartGame(battleGame); }
                            
                            ui.InfoScreen("", 0, false, true);
                            break;
                        }
                    case 4: // Словарь
                        {
                            ui.InfoScreen(inputInfoMenu, 1, false, true);
                            ui.InfoScreen(methodsDB.GetRulesGame(), 1, false, false);
                            Console.ReadKey();
                            ui.InfoScreen("", 0, false, true);
                            break;
                        }
                    case 5: // выход
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
            timer.Start(10, curTimeX, curTimeY, "Оставшееся время на раздумие капитанов", ()=> 
            {
                
                GameStepTwo(battleGame); 
            });
            
            if (battleGame.RulesAgents[RolesSpies.red]> battleGame.RulesAgents[RolesSpies.blue])
            {
                
                battleGame.NameCommand[2] = battleGame.NameCommand[1];
                ui.InfoScreen($"По окончанию/досрочному завершению времени первые ходят {battleGame.NameCommand[2]} ");
            }
            else
            {
                battleGame.NameCommand[2]= battleGame.NameCommand[0];
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
                    ui.InfoScreen("", 0, true, true);
                    
                    
                    GameStepTwo(battleGame);
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
            string inputWords = "Введеные слова: ";
            TimerGame timer = new TimerGame();
            while (whileIndicator)
            {
                // блок вывода на экран 
                ui.InfoScreen("", 0, true, true);
                ui.UsersBattleScrin(battleGame);
                ui.InfoScreen($"Сейчас ходят {battleGame.NameCommand[2]}");
                ui.InfoScreen("Вводите слова по одному через Enter ");
                ui.InfoScreen(inputWords);
                int curTimeX = Console.CursorLeft;
                int curTimeY = Console.CursorTop;
                                
                
                if (timerIndicator == true)
                {
                    timerIndicator = false;
                    // координаты для таймера

                    //Купаск таймера 
                    
                    timer.Start(10, curTimeX, curTimeY, "Оставшееся время команды", () =>
                    {
                        whileIndicator = false;
                        timerIndicator = true;
                        battleGame.NameCommand[2] = battleGame.NameCommand[1] == battleGame.NameCommand[2] ? battleGame.NameCommand[0] : battleGame.NameCommand[1];
                        //TimeCaptians2(battleGame);
                        //GameStepTwo(battleGame);
                        
                    });
                    
                }
                Console.SetCursorPosition(curTimeX, curTimeY+1);
                var input = methodsKeyBord.GetInputAnswer();
                Console.SetCursorPosition(curTimeX, curTimeY+2);
                ui.InfoScreen("");
                Console.SetCursorPosition(curTimeX, curTimeY+3);

                // запись количества проходов 
                int repeatIndicator = 0;

                for (int y = 0; y < battleGame.ListWordsGame.Count; y++)
                {
                    for (int x = 0; x < battleGame.ListWordsGame[y].Count; x++)
                    {
                        
                        // сравниваем каждую ячейку слова
                        if (battleGame.ListWordsGame[y][x].SecretWords.Keys.FirstOrDefault().ToLower() == input)
                        {
                            // делаем видимый цвет ячейки
                            battleGame.ListWordsGame[y][x].VisibilityColor = true;

                          
                            // сверяем цвет ячейки с цветом команды RED ( используя ключ открываем словарь чтобы узнать цвет)
                            if (battleGame.ListWordsGame[y][x].SecretWords[char.ToUpper(input[0]) + input.Substring(1).ToLower()] == RolesSpies.red)

                            {
                                // если одинаковый игра продолжается
                                // вычитаем из списка команд 1 агента красной команды
                                battleGame.RulesAgents[RolesSpies.red]--;

                                if (battleGame.RulesAgents[RolesSpies.red] == 0)
                                {
                                    CheckVictory(battleGame, "Победил");
                                    timer.Stop();
                                    whileIndicator = false;
                                    //прекращение обхода оси X
                                    break;
                                }
                                // если цвет слова и команды  не одинаковый ход прервывается 
                                if (battleGame.NameCommand[2] != battleGame.NameCommand[1])
                                {
                                    ui.InfoScreen("Переход хода ", 2);
                                    timer.Stop();
                                    timerIndicator = true;
                                    battleGame.NameCommand[2] = battleGame.NameCommand[1];
                                    TimeCaptians2(battleGame);
                                }
                            }   


                            if (battleGame.ListWordsGame[y][x].SecretWords[char.ToUpper(input[0]) + input.Substring(1).ToLower()] == RolesSpies.blue)
                            {
                                battleGame.RulesAgents[RolesSpies.blue]--;

                                if (battleGame.RulesAgents[RolesSpies.blue] == 0)
                                {
                                    CheckVictory(battleGame, "Победил");
                                    timer.Stop();
                                    whileIndicator = false;
                                    //прекращение обхода оси X
                                    break;
                                }
                                // если цвет слова и команды  не одинаковый ход прервывается 
                                if (battleGame.NameCommand[2] != battleGame.NameCommand[0])
                                {
                                    ui.InfoScreen("Переход хода ", 2);
                                    timer.Stop();
                                    timerIndicator = true;
                                    battleGame.NameCommand[2] = battleGame.NameCommand[0];
                                    TimeCaptians2(battleGame);
                                }

                            }




                            // если черный цвет игра проиграна 
                            if (battleGame.ListWordsGame[y][x].SecretWords[char.ToUpper(input[0]) + input.Substring(1).ToLower()] == RolesSpies.black)
                            {
                                CheckVictory(battleGame, "ПРОИГРАЛ");
                                timer.Stop();
                                whileIndicator = false;
                                //прекращение обхода оси X
                                break;
                            }

                            
                            
                           


                        }
                        else
                        {
                            repeatIndicator++;
                        }
                    }
                    if (repeatIndicator == battleGame.ListWordsGame.Count * battleGame.ListWordsGame[y].Count) 
                    { ui.InfoScreen("Нет такого слова");
                        Thread.Sleep(2000);

                    }
                    // прекращение цикла фор по оси Y
                    if (!whileIndicator) { break; }
                }
                //пополняем списко слов
                inputWords += input + ", ";
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
                ui.InfoScreen($"Сейчас Думаю капитаны {battleGame.NameCommand[2]}");
                // координаты курсора для таймера 
                int curTimeX = Console.CursorLeft;
                int curTimeY = Console.CursorTop;


                if (timerIndicator == true)
                {
                    timerIndicator = false;
                   
                    //Купаск таймера 

                    timer.Start(10, curTimeX, curTimeY, "Оставшееся время на раздумие капитана", () =>
                    {
                        whileIndicator = false;
                        timerIndicator = true;
                        return;
                        //battleGame.NameCommand[2] = battleGame.NameCommand[1] == battleGame.NameCommand[2] ? battleGame.NameCommand[0] : battleGame.NameCommand[1];
                        
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
                        GameStepTwo(battleGame);
                        whileIndicator = false;

                        break;
                    }

                }



            }

        }

        public void TimeCaptians2(BattleGame battleGame)
        {
            bool timerIndicator = true;
            bool whileIndicator = true;
            TimerGame timer = new TimerGame();
            bool timerExpired = false; // <-- Флаг истечения таймера

            while (whileIndicator)
            {
                ui.InfoScreen("", 0, true, true);
                ui.UsersBattleScrin(battleGame);
                ui.InfoScreen($"Сейчас Думаю капитаны {battleGame.NameCommand[2]}");

                int curTimeX = Console.CursorLeft;
                int curTimeY = Console.CursorTop;

                if (timerIndicator == true)
                {
                    timerIndicator = false;
                    timerExpired = false; // Сбрасываем флаг

                    timer.Start(10, curTimeX, curTimeY, "Оставшееся время на раздумие капитана", () =>
                    {
                        timerExpired = true; // <-- Таймер истёк
                        whileIndicator = false;
                        timerIndicator = true;
                    });
                }

                // ВНУТРЕННИЙ ЦИКЛ
                while (whileIndicator)
                {
                    // ПРОВЕРКА: если таймер истёк - ВЫХОДИМ
                    if (timerExpired)
                    {
                        ui.InfoScreen("Время вышло!", 0, true, true);
                        return; // <-- Выход из метода
                    }

                    ui.InfoScreen("Готовы капитан готов начать ? y/n ?", 1, false, false);

                    // ПРОВЕРКА ПЕРЕД ОЖИДАНИЕМ ВВОДА
                    if (timerExpired)
                    {
                        return;
                    }

                    (int inputNumberMenu, string inputInfoMenu) = methodsKeyBord.GetYesNoKeyBord();

                    if (inputNumberMenu == 0)
                    {
                        ui.InfoScreen("Капитаны думаю дальше", 0, false, false);
                    }
                    else
                    {
                        timer.Stop();
                        ui.InfoScreen("", 0, true, true);
                        GameStepTwo(battleGame);
                        whileIndicator = false;
                        break;
                    }
                }
            }
        }





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
            ui.InfoScreen($"{battleGame.NameCommand[2]} - {info}",5);
        }


        /// <summary>
        /// Конструктор логики
        /// </summary>
        public Logic2()
        {
            methodsGames = new MethodsGames();
            ui = new UI();
            methodsDB = new MethodsDB();
            methodsKeyBord = new MethodsKeyBord();
        }
    }
}
