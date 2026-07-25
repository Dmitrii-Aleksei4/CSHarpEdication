using System;
using System.Collections.Generic;
using System.Text;

namespace CodenamesCore.Model
{
    public class BattleGame
    {
        public List<List<WordsGame>> ListWordsGame {  get; set; }
        public Dictionary<RolesSpies,int> RulesAgents {  get; set; }

        public List<string> NameCommand { get; set; }
        
        public Timer Timer { get; set; }
        
        public BattleGame(List<List<WordsGame>> listWordsGame, Dictionary<RolesSpies, int> rulesAgents) 
        {

            ListWordsGame = listWordsGame;
            RulesAgents = rulesAgents;
            NameCommand = new List<string>() { "Синие", "Красные","" };
            Timer = new Timer();
        }
    }

}
