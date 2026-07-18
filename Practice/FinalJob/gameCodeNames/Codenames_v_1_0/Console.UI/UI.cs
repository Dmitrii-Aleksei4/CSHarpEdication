using System;
using System.Collections.Generic;
using System.Text;
using CodenamesCore.Model;

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
            Console.WriteLine("1.Игра 5х5");
            Console.WriteLine("2.Игра 5х6");
            Console.WriteLine("3.Словарь");
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
            Console.WriteLine("4.Поле для участников");
            Console.WriteLine("5.Назад");
        }
        /// <summary>
        /// Поле Капитанов 
        /// </summary>
        /// <param name="wordsCapitanGame"></param>
        public void CapitansBattleScrin(List<List<WordsGame>> wordsCapitanGame)
        {
            UsersBattleScrin(wordsCapitanGame, true);

        }
        /// <summary>
        /// Игровое поле
        /// </summary>
        /// <param name="wordsCapitanGame"></param>
        /// <param name="allVisibility"></param>
        public void UsersBattleScrin(List<List<WordsGame>> wordsCapitanGame, bool allVisibility=false)
        {
            for (int y = 0; y < wordsCapitanGame.Count; y++)
            {
                for (int x = 0; x < wordsCapitanGame[y].Count; x++)
                {
                    if (allVisibility == true) 
                    {
                        var color = wordsCapitanGame[y][x].SecretWords.FirstOrDefault().Value;
                        Console.BackgroundColor = color switch
                        {
                            RolesSpies.blue => ConsoleColor.Blue,
                            RolesSpies.red => ConsoleColor.Red,
                            RolesSpies.black => ConsoleColor.Black,
                            _ => ConsoleColor.White
                        };
                    }
                    else
                    {
                        if (wordsCapitanGame[y][x].VisibilityColor == true) 
                        {
                            var color = wordsCapitanGame[y][x].SecretWords.FirstOrDefault().Value;
                            Console.BackgroundColor = color switch
                            {
                                RolesSpies.blue => ConsoleColor.Blue,
                                RolesSpies.red => ConsoleColor.Red,
                                RolesSpies.black => ConsoleColor.Black,
                                _ => ConsoleColor.White
                            };
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                    }

                    Console.Write($"{wordsCapitanGame[y][x].DispleyScren(),10} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }

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

        /// <summary>
        /// Информационный экран 
        /// </summary>
        /// <param name="info"> Информация</param>
        /// <param name="daley"></param>
        /// <param name="clearStart"></param>
        /// <param name="clearEnd"></param>
        public void InfoScreen(string info, int daley = 0, bool clearStart = false, bool clearEnd = false)
        {
            if (clearStart) { Console.Clear(); }
            Console.WriteLine(info);
            Thread.Sleep(1000 * daley);
            if(clearEnd) { Console.Clear(); }
        }
    }
}
