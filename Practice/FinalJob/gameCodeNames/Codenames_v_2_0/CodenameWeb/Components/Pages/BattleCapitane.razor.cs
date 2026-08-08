using CodenamesCore.GameLogic;
using CodenamesCore.Model;



namespace CodenameWeb.Components.Pages
{
    public partial class BattleCapitane
    {

        
        private MethodsGames methodsGames;
        private MethodsDB methodsDB;
        private MethodsKeyBord methodsKeyBord;

        private BattleGame battleGame;
        protected override void OnInitialized()
        {

            battleGame = methodsGames.GetAllDiktWords(methodsDB.GetAllDiktWords(), 5, 5);

        }



        public BattleCapitane()
        {
            methodsGames = new MethodsGames();

            methodsDB = new MethodsDB();
            methodsKeyBord = new MethodsKeyBord();
        }
    }
}
