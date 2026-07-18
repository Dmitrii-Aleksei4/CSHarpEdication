using CodenamesCore.GameLogic;
using CodenamesCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

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
                (inputNumberMenu,inputInfoMenu) = methodsKeyBord.GetMaxKeyBord(5);
                switch (inputNumberMenu)
                {
                    case 404: // неверный ввод
                        {
                            ui.InfoScreen(inputInfoMenu, 1, false, true);
                            break;
                        }
                    case 1: // игровое поле 5х5
                        {
                            ui.InfoScreen(inputInfoMenu,1,false,true);

                            GameSettings(5,5);
                            break;
                        }
                    case 2:// игровое поле 5х6
                        {
                            ui.InfoScreen(inputInfoMenu, 1, false, true);
                            GameSettings(5, 6);
                            break;
                        }
                    case 3: // получение словаря
                        {
                            ui.InfoScreen(inputInfoMenu, 1, false, true);
                            ui.ChoiseSettingBattleScrin();
                            break;
                        }
                    case 4: // получение правил
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
                            ui.InfoScreen("Начнем игровую ссесию", 1, false, true);
                            (inputNumberMenu,inputInfoMenu)  = methodsKeyBord.GetYesNoKeyBord() ;
                            // буфер обмена информациооного сообщения
                            if (inputNumberMenu ==1) { StartGame(); }
                            Console.ReadKey();
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

        public void StartGame()
        {

        }


        public Logic()
        {
            methodsGames = new MethodsGames();
            ui = new UI();
            methodsDB = new MethodsDB();
            methodsKeyBord = new MethodsKeyBord();
        }
    }
}
