using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CodenamesCore.GameLogic
{
    public class MethodsKeyBord
    {
        /// <summary>
        /// Отрабатываем нажатие клавишь
        /// </summary>
        /// <param name="maxKey"></param>
        /// <returns></returns>
        public (int, string) GetMaxKeyBord(int maxKey)
        {

            ConsoleKeyInfo inputKey = Console.ReadKey(true);
            string? info = null;
            int inputNumber;
            // провека на символ 
            if (!char.IsDigit(inputKey.KeyChar))
            {
                info = $"Ошибка: Введите цифру от 1 до {maxKey}";
                return (404, info);
            }

            inputNumber = int.Parse(inputKey.KeyChar.ToString());
            
            // провека на вхождение в пределы заданного меню 
            if (inputNumber < 0 && inputNumber <= maxKey)
            {
                info = $"Ошибка: число должно быть от 1 до {maxKey}";
                return (404, info);
            }
            // Все верно 
            info = $"Выбрано: {inputNumber}";
            return (inputNumber, info);

        }
        public (int, string) GetYesNoKeyBord()
        {
            ConsoleKeyInfo inputKey = Console.ReadKey(true);
            string info;
            
            if ((inputKey.KeyChar.ToString().ToLower() == "y") || (inputKey.KeyChar.ToString().ToLower() == "н"))
            {
                info = $"Игра начитается";
                return (1, info);
            }
            if ((inputKey.KeyChar.ToString().ToLower() == "n") || (inputKey.KeyChar.ToString().ToLower() == "т"))
            {
                info = $"Игра отменена";
                return (0, info);
            }
            else
            {
                info = $"Веден не верный символ:";
                return (404, info);
            }
        }

        public string GetInputAnswer()
        {
            string input = Console.ReadLine().Trim().ToLower() ;

            return input;

        }
    }
}
