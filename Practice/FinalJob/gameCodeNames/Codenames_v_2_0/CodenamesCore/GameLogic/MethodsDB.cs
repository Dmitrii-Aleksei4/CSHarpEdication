using CodenamesCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodenamesCore.GameLogic
{
    public class MethodsDB
    {

        public List<string> GetAllDiktWords()
        {
            List<string> Words = new List<string>()
            {
                "Персик",
                "Пирог",
                "Манго",
                "Банан",
                "Сахар",
                "Вилка",
                "Таблетка",
                "Смекалка",
                "Ванна",
                "Книга",
                "Стол",
                "Стул",
                "Окно",
                "Дверь",
                "Зеркало",
                "Лампа",
                "Ковер",
                "Часы",
                "Телефон",
                "Ноутбук",
                "Мышь",
                "Клавиатура",
                "Монитор",
                "Наушники",
                "Кофе",
                "Чай",
                "Молоко",
                "Хлеб",
                "Сыр",
                "Колбаса",
                "Помидор",
                "Огурец",
                "Морковь",
                "Картофель",
                "Лук",
                "Чеснок",
                "Перец",
                "Соль",
                "Масло",
                "Мед"
            };

            return Words;
        }
    
        public string GetRulesGame()
        {
            return $"Тут описаны все правила на игру";
        }
    }
}
