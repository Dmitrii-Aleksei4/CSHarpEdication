using System;
using System.Collections.Generic;
using System.Text;

namespace CodenamesCore.Model
{
    public class WordsGame
    {
        #region Поля и свойства
        // поле слов и цвета 
        public Dictionary<string, RolesSpies>? SecretWords { get; set; }
        // поле видимости
        public bool VisibilityColor {  get; set; }
        #endregion

        public string DispleyScren()
        {
            var word = SecretWords.FirstOrDefault();
            return word.Key;
        }



        #region Конструктор
        public WordsGame(string srt, RolesSpies rolesSpies)
        {
            SecretWords = new Dictionary<string, RolesSpies>
            {
                { srt, rolesSpies }
            };
            VisibilityColor = false;

    }
        #endregion
    }
}


