using Data_job_1._0.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Data_job_1._0.UI
{
    internal class Screen
    {
        public void StartScreen()
        {
            ClearS();
            Console.WriteLine("===Привествующий экран===");
            Console.WriteLine("Выберите что вы ходите делать");
            Console.WriteLine("1. Вывод всех Работников");
            Console.WriteLine("2. Вывод Индивидуального Работника");
            Console.WriteLine("3. Редактирование Работников");
            Console.WriteLine("4. Выход");
        }
        /// <summary>
        /// Все Работники фирмы
        /// </summary>
        /// <param name="Users"></param>
        public void OutputWorker(List<User> Users)
        {
            ClearS();
            Console.WriteLine("===ВСЕ РАБОТНИКИ ФИРМЫ===");
            foreach (User user in Users)
            {
                
                Console.WriteLine(user);
            }
            Console.WriteLine("---------------------------------------------------");
            
            
        }
        /// <summary>
        /// Один работник пофрмы по ID
        /// </summary>
        /// <param name="user"></param>
        public void OutputOneWorker(User user)
        {
            
            Console.WriteLine("===ВЫБРАННЫЙ РАБОТНИК РАБОТНИКИ ФИРМЫ===");
            Console.WriteLine(user);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Для возврата нажните любую кнопку");
        }

        public void InputID()
        {
            
            Console.WriteLine("===ВЫБРАННЫЙ РАБОТНИК РАБОТНИКИ ФИРМЫ===");
            Console.WriteLine("Введите ID работника");
        }

        public void Creat_del_update()
        {
            
            Console.WriteLine("===Редактирование списка Работников===");
            Console.WriteLine("Выберите что вы ходите делать");
            Console.WriteLine("1. Добавить Работника");
            Console.WriteLine("2. Удалить Работника по ID");
            Console.WriteLine("3. Обновить Работника по ID");
            Console.WriteLine("4. В предыдущее меню");
            
        }

        public void Uppend_Users(User user)
        {
            Console.WriteLine($"===Редактирование Работника {user.ID}. {user.Name} ===");
            Console.WriteLine("Выберите что вы ходите делать");
            Console.WriteLine($"1. Изменит имя {user.Name} на - ... ");
            Console.WriteLine($"2. Изменить ставку за час {user.Pay_hour} на - ... ");
            Console.WriteLine($"3. Изменить отработанные часы {user.Hour_work} на - ... ");
            Console.WriteLine($"4. Изменить сколько должен отработать {user.Must_work} на - ... ");
            Console.WriteLine("5.  В предыдущее меню");
        }



        /// <summary>
        /// Вывод ошибки
        /// </summary>
        /// <param name="Message">Текст ошибки</param>
        /// <param name="delay">задержка в секундах</param>


        public void MessageSceen(String Message, double delay = 0 )
        {
            Console.WriteLine(Message);
            if (delay > 1) 
            { 
                Thread.Sleep((int)(delay * 1000));
            }
            
        }

        public void ClearS()
        {
            Console.Clear();
        }

    }
}
