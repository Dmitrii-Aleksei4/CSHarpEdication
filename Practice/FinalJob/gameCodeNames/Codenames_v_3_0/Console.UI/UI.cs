using CodenamesCore.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Consol.UI
{
    internal class UI
    {
        /// <summary>
        /// Стартовый экран
        /// </summary>
        public void StartScrin()
        {
            Console.WriteLine("Введите цифры из меню");
            Console.WriteLine("1.Игровое поле на 5х5");
            Console.WriteLine("2.Игровое поле на 5х6");
            Console.WriteLine("3.Игровое поле на 2х3");
            Console.WriteLine("4.Правла");

            Console.WriteLine("5.Выход");

        }
        /// <summary>
        /// Пред игровое поле
        /// </summary>
        public void ChoiseSettingBattleScrin()
        {
            Console.WriteLine("Введите цифры из меню");
            Console.WriteLine("1.Настройка таймера");
            Console.WriteLine("2.Поле для капитанов");
            Console.WriteLine("3.Поле для участников");
            Console.WriteLine("4.Обновить");
            Console.WriteLine("5.Словарь");
            Console.WriteLine("6.Назад");
        }
        /// <summary>
        /// Поле Капитанов 
        /// </summary>
        /// <param name="wordsCapitanGame"></param>
        public void CapitansBattleScrin(BattleGame wordsCapitanGame)
        {
            UsersBattleScrin(wordsCapitanGame, true);

        }
        /// <summary>
        /// Игровое поле
        /// </summary>
        /// <param name="wordsCapitanGame"></param>
        /// <param name="allVisibility"></param>
        public void UsersBattleScrin(BattleGame wordsCapitanGame, bool allVisibility=false)
        {
            for (int y = 0; y < wordsCapitanGame.ListWordsGame.Count; y++)
            {
                for (int x = 0; x < wordsCapitanGame.ListWordsGame[y].Count; x++)
                {
                    if (allVisibility == true) 
                    {
                        var color = wordsCapitanGame.ListWordsGame[y][x].SecretWords.FirstOrDefault().Value;
                        Console.BackgroundColor = color switch
                        {
                            RolesSpies.blue => ConsoleColor.Blue,
                            RolesSpies.red => ConsoleColor.Red,
                            RolesSpies.black => ConsoleColor.Cyan,
                            _ => ConsoleColor.White
                        };
                    }
                    else
                    {
                        if (wordsCapitanGame.ListWordsGame[y][x].VisibilityColor == true) 
                        {
                            var color = wordsCapitanGame.ListWordsGame[y][x].SecretWords.FirstOrDefault().Value;
                            Console.BackgroundColor = color switch
                            {
                                RolesSpies.blue => ConsoleColor.Blue,
                                RolesSpies.red => ConsoleColor.Red,
                                RolesSpies.black => ConsoleColor.Cyan,
                                _ => ConsoleColor.White
                            };
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                    }

                    Console.Write($"{wordsCapitanGame.ListWordsGame[y][x].DispleyScren(),10} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write($"{wordsCapitanGame.NameCommand[0]} - {wordsCapitanGame.RulesAgents[RolesSpies.blue].ToString(),15}");
            Console.BackgroundColor = ConsoleColor.Red;

            Console.WriteLine($"{wordsCapitanGame.NameCommand[1]}- {wordsCapitanGame.RulesAgents[RolesSpies.red].ToString(),15}");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// Показ всего словаря
        /// </summary>
        /// <param name="listWords"></param>
        public void AllDictScrein(List <string> listWords)
        {
            foreach(var i in listWords)
            {
                Console.Write($"{i}, ");
            }
        }


        public void whoseMoveColorScreen(string info, string capitans)
        {
            Console.Write(info + " ");
            if (capitans == "Красные")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(capitans);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(capitans);
            }
            Console.BackgroundColor = ConsoleColor.Black;

        }

        /// <summary>
        /// Информационный экран 
        /// </summary>
        /// <param name="info"> Информация</param>
        /// <param name="daley"></param>
        /// <param name="clearStart"></param>
        /// <param name="clearEnd"></param>
        public void InfoScreen(string info, double daley = 0, bool clearStart = false, bool clearEnd = false)
        {
            if (clearStart) { Console.Clear(); }
            Console.WriteLine(info);
            Thread.Sleep((int)(daley*1000));
            if(clearEnd) { Console.Clear(); }
        }
    }
}
