using Data_job_1._0.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Data_job_1._0.Services
{
    internal class ServicesProgram

    {

        private readonly Screen _screen; // Предполагаем, что у вас есть класс Screen в UI

        public ServicesProgram()
        {
            _screen = new Screen(); // ✅ Создаем экземпляр внутри
        }

        public string CheckingInputChoise(int maxInput, int minInput = 1)
        {
            while (true) 
            {
                var check_choice = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(check_choice))
                {
                    _screen.MessageSceen("Поле ввода пустое");
                    continue;
                }
                
                if (!int.TryParse(check_choice, out int rez))
                {
                    _screen.MessageSceen ("Не является числом или целым числом");
                    continue;
                }

                
                if (rez > maxInput)
                {
                    _screen.MessageSceen("Введен болшем чем есть в меню");
                    continue;
                }
                return check_choice;
            
            
            }
        }

        public int CheckingInputID()
        {
            while (true) 
            {
                var input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    _screen.MessageSceen("Поле ввода пустое");
                    continue;
                }

                if (!int.TryParse(input, out var rez))
                {
                    _screen.MessageSceen( "Не является числом");
                    continue;
                }
                
                if (rez < 0)
                {
                    _screen.MessageSceen( "ID Не может быть отрицательным");
                    continue;
                }
                
                return rez;
            }
            
        }
        public double inputAddUser()
        {
            while (true)
            {
                var input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input)) 
                {
                    _screen.MessageSceen("Поле ввода пустое");
                    continue;
                }

                if (!double.TryParse(input, out double rez))
                {

                    _screen.MessageSceen("Не является числом");
                    continue;
                }
                if (rez < 0)
                {
                    _screen.MessageSceen("Число не может быть отрицательным");
                    continue;
                    
                }
                return rez;

            }
        }

        public double inputAddUserMust_work(double Hour_work)
        {
            while (true)
            {
                var rez = inputAddUser();

                if (rez < Hour_work)
                {
                    _screen.MessageSceen("Часы максимальной работы не должны превышать часов уже отработаных");
                    continue;
                }

                return rez;
            }


        }

        public string inputRemoveUser()
        {
            while (true)
            {
                var inputName = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(inputName))
                {
                    _screen.MessageSceen("Поле имени пустое");
                    continue;
                }

                if (Regex.IsMatch(inputName, @"\d"))
                {
                    _screen.MessageSceen("Имя имеет в себе цифры");
                    continue;
                }
                else
                {
                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                    return textInfo.ToTitleCase(inputName);

                }
            }

        }



    }
}
