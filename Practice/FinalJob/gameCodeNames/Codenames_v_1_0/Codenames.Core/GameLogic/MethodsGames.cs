using CodenamesCore.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace CodenamesCore.GameLogic
{
    public class MethodsGames
    {
        /// <summary>
        /// Получение списка загадаанных слов
        /// </summary>
        /// <param name="getAllDiktWords">Словарь</param>
        /// <param name="sizeBattleHight"></param>
        /// <param name="sizeBattleWidht"></param>
        /// <returns></returns>
        public List<List<WordsGame>> GetAllDiktWords(List<string> getAllDiktWords, int sizeBattleHight = 5, int sizeBattleWidht = 5)
        {
            var battle = new List<List<WordsGame>>();
            int higth = sizeBattleHight;
            int widht = sizeBattleWidht;
            // идем по списку
            //var color = new RolesSpies();
            RolesSpies color;
            var numberColorAgent = AllNumberAgent(higth*widht);
            for (var  y = 0; y< higth; y++)
            {
                battle.Add(new List<WordsGame>());
                for (var x = 0; x < widht; x++)
                {
                    while (true) // добавить проверку позже
                    { 
                        color = numberColorAgent[Random.Shared.Next(numberColorAgent.Count)];
                        break;
                    }
                    
                    numberColorAgent.Remove(color);
                    string word = getAllDiktWords[Random.Shared.Next(getAllDiktWords.Count)];
                    var dict = new WordsGame(word, color);
                    getAllDiktWords.Remove(word);
                    battle[y].Add(dict);
                }
            }


            return battle;
        }
        /// <summary>
        /// Получение количеста и списка агентов с раздлелением по командам
        /// </summary>
        /// <param name="sizeNumber"> Размер таблицы</param>
        /// <returns>Агенты: red,blue,black,white(</returns>
        public List<RolesSpies> AllNumberAgent(int sizeNumber)
        {
            int corectorPart = 0;
            int black = sizeNumber % 7 == 0 ? 2 : 1;

            switch (sizeNumber)
            {
   
                case < 20:
                    corectorPart = 1;
                    break;
                
                case < 50:
                    corectorPart = 3;
                    break;
                default:
                    corectorPart = 3;
                    break;

                
            }
            List<RolesSpies> agetns = new List<RolesSpies>() { };
            int blue = sizeNumber / 5 + corectorPart;
            int red = blue;
            if (Random.Shared.Next(2) == 0) { blue++; } else { red++; }
            int white = sizeNumber - black - red - blue;
            for (var i = 0; i < red; i++) { agetns.Add(RolesSpies.red); }
            for (var i = 0; i < blue; i++) { agetns.Add(RolesSpies.blue); }
            for (var i = 0; i < black; i++) { agetns.Add(RolesSpies.black); }
            for (var i = 0; i < white; i++) { agetns.Add(RolesSpies.white); }


            //List<int> agetns = new List<int>() { red, blue, black, white };


            return agetns;
        }

        public bool CheckInputWords(List<List<WordsGame>> allDiktWords, string inputWord)
        {
            foreach (var listY in allDiktWords)
            {
                foreach (var word in listY)
                {
                    if (word.SecretWords.Keys.Contains(inputWord)) 
                    {  return true; }
                        
                }
            }
            
            return false;
        }

    }
}
