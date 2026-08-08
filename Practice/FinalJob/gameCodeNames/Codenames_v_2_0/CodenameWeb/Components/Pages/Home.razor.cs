namespace CodenameWeb.Components.Pages
{
    public partial class Home
    {

        // ============================================================
        // 1. ВЫБОР ПОЛЯ
        // ============================================================
        private string selectedField = "5x5";

        private void SelectField5x5() => selectedField = "5x5";
        private void SelectField5x6() => selectedField = "5x6";
        private void SelectFieldCustom() => selectedField = "Custom";

        // ============================================================
        // 2. КАСТОМНЫЕ РАЗМЕРЫ
        // ============================================================
        private int customRows = 5;
        private int customColumns = 6;

        // ============================================================
        // 3. ТАЙМЕРЫ (ЗНАЧЕНИЯ ПО УМОЛЧАНИЮ)
        // ============================================================
        private int firstCaptainTimer = 120; // 2 минуты
        private int captainTimer = 60;       // 1 минута
        private int teamTimer = 60;          // 1 минута

        // ============================================================
        // 4. СЛОВАРИ
        // ============================================================
        private string selectedDictionary = "ru";

        private void RefreshField()
        {
            // Здесь будет логика генерации нового поля
            Console.WriteLine($"Поле обновлено! Словарь: {selectedDictionary}, Размер: {selectedField}");
        }

        // ============================================================
        // 5. УПРАВЛЕНИЕ ОКНОМ ВЫВОДА
        // ============================================================
        private string currentView = "Welcome";

        private void ShowRules() => currentView = "Rules";
        private void ShowAbout() => currentView = "About";
        private void ShowCaptainField() => currentView = "CaptainField";
        private void ShowGameField() => currentView = "GameField";
    }
}

