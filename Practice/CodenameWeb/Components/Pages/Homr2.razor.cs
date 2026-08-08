using CodenamesCore.GameLogic;
using CodenamesCore.GameLogic;
using CodenamesCore.Model;
using CodenamesCore.Model;
using CodenameWeb.Models;
using Microsoft.JSInterop;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodenameWeb.Components.Pages
{
    public partial class Homr2
    {

        // ============================================================
        // 1. ВЫБОР ПОЛЯ
        // ============================================================
        private string selectedField = "5x5";

        private void SelectField5x5()
        {
            selectedField = "5x5";
            customRows = 5;
            customColumns = 5;
            NewKey();
        }
        private void SelectField5x6() 
        { 
            selectedField = "5x6";
            customRows = 5;
            customColumns = 6;
            NewKey();
            
        }


        private void SelectFieldCustom() 
        {
            selectedField = "Custom";
           // customRows = 5;
            //customColumns = 6;
            NewKey();
        } 
        




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

        private void ShowRules() 
        {
            GetRules();
            currentView = "Rules";
        }
        private void ShowAbout() => currentView = "About";
        private void ShowCaptainField()
        {
            // 1. Кодируем ключ (заменяем пробелы и буквы на безопасные значки)
            string encoded = Uri.EscapeDataString(key);

            // 3. Переходим на страницу Б и добавляем текст в адресную строку
            NavigationManager.NavigateTo($"/BattleCapitane?text={encoded}");
        }
        private void ShowGameField() 
        {
            // 1. Кодируем ключ (заменяем пробелы и буквы на безопасные значки)
            string encoded = Uri.EscapeDataString(key);

            // 3. Переходим на страницу Б и добавляем текст в адресную строку
            NavigationManager.NavigateTo($"/battleGames?text={encoded}");
        } 






        // Работа к Кэшем

        private string key;
        private string word = "Привет!";
        private string result = "";

        // ⭐ Ключ для запоминания
        private const string REMEMBERED_KEY = "remembered_key";
        private bool isLoading = true;

        // ⭐ При загрузке страницы - восстанавливаем ключ
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadRememberedKey();
                isLoading = false;
                StateHasChanged();
            }
        }

        // случайный ключ

        private async Task NewKey()
        {
            key = new Random().Next(9999).ToString();
            RememberKey();
            GetListWords();
            
        }


        // ЗАПОМНИТЬ КЛЮЧ
        private async Task RememberKey()
        {
            if (string.IsNullOrEmpty(key))
            {
                result = "⚠️ Введите ключ для запоминания!";
                return;
            }

            await Js.InvokeVoidAsync("localStorage.setItem", REMEMBERED_KEY, key);
            
        }

        // Загружаем запомненный ключ
        private async Task LoadRememberedKey()
        {
            try
            {
                string savedKey = await Js.InvokeAsync<string>("localStorage.getItem", REMEMBERED_KEY);

                if (!string.IsNullOrEmpty(savedKey))
                {
                    key = savedKey;
                    result = $"✅ Ключ восстановлен: {key}";

                    // Автоматически загружаем значение по этому ключу
                    await Load();
                }
                else
                {
                    result = "ℹ️ Нет сохраненного ключа. Используйте 'Запомнить ключ'";
                }
            }
            catch (Exception ex)
            {
                result = $"❌ Ошибка: {ex.Message}";
            }
        }

        // Загрузить
        private async Task Load()
        {
            if (string.IsNullOrEmpty(key))
            {
                result = "⚠️ Введите ключ!";
                return;
            }

            var value = await Js.InvokeAsync<string>("localStorage.getItem", key);

            if (!string.IsNullOrEmpty(value))
            {
                word = value;
                result = $"📂 Загружено: {key} = {value}";
            }
            else
            {
                result = $"❌ Ключ '{key}' не найден";
            }
        }

       
        // ===== ДАННЫЕ =====
        private List<List<Card>> Cards = new();
        private BattleGame battleGame;
        private MethodsDB methodsDB = new MethodsDB();
        private MethodsGames methodsGames  = new MethodsGames();

      
        // получение словаря
        private async Task GetListWords()
        {
            battleGame = methodsGames.GetAllDiktWords(methodsDB.GetAllDiktWords(), customRows, customColumns);
            Console.WriteLine($"Тип: {battleGame.GetType().Name}");
            word = JsonSerializer.Serialize(battleGame);
            await Js.InvokeVoidAsync("localStorage.setItem", key, word);
        }

        private string rules;
        private async Task GetRules()
        {

            rules = methodsDB.GetRulesGame();
        }

    }

}

