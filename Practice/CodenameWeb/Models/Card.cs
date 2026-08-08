namespace CodenameWeb.Models
{
    public class Card
    {
        
        public string Text { get; set; } = "";           // Текст на карточке
        public string ColorClass { get; set; } = "";     // CSS-класс цвета (blue, red, green)
        public bool IsFlipped { get; set; } = false;     // Перевёрнута ли карточка?
        public bool IsHolding { get; set; } = false;     // Удерживается ли сейчас?
        public double Progress { get; set; } = 0;        // Прогресс удержания 0-100%
        public System.Timers.Timer? HoldTimer { get; set; }     // Таймер на 2 секунды
        public System.Timers.Timer? ProgressTimer { get; set; } // Таймер для прогресс-бара

    }
}
