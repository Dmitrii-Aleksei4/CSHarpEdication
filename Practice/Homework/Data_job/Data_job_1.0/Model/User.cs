using System;
using System.Collections.Generic;
using System.Text;

namespace Data_job_1._0.Model
{
    internal class User
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID {  get; set; }
        public string  Name { get; set; }
        /// <summary>
        /// Часовая ставка
        /// </summary>
        public double Pay_hour {  get; set; }
        /// <summary>
        /// Сколько часов отработал
        /// </summary>
        public double Hour_work {  get; set; }
        /// <summary>
        /// Сколько часов должен отработать
        /// </summary>
        public double Must_work { get; set; }

        public User(string name, double pay_hour, double hour_work, double must_work)
        {
            
            Name = name;
            Pay_hour = pay_hour;
            Hour_work = hour_work;
            Must_work = must_work;
        }
        public override string ToString()
        {
            return $"{Name} (ID: {ID}, Ставка: {Pay_hour} руб/час, Отработано: {Hour_work} ч, Должен Отработать {Must_work},  Заработал {Hour_work * Pay_hour}, Осталось заработать {Pay_hour * (Must_work - Hour_work)} )";
        }

    }
}
