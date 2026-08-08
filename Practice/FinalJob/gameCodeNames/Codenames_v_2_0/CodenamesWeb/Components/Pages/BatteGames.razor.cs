using CodenamesCore.GameLogic;
using CodenamesCore.Model;

namespace CodenamesWeb.Components.Pages
{
    public partial class BatteGames
    {

        private string cne = "3";
        private MethodsGames methodsGames;
        private MethodsDB methodsDB;
        private MethodsKeyBord methodsKeyBord;

        private BattleGame battleGame;

        //что делать при отрытии окна
        protected override void OnInitialized()
        {
            
            battleGame = methodsGames.GetAllDiktWords(methodsDB.GetAllDiktWords(), 5, 5);

        }



        public BatteGames()
        {
            methodsGames = new MethodsGames();
            
            methodsDB = new MethodsDB();
            methodsKeyBord = new MethodsKeyBord();
        }
    }
}
