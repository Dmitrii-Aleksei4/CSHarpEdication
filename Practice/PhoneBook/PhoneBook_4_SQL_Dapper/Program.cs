using Dapper;
using Microsoft.Data.Sqlite;

namespace PhoneBook_4_SQL_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Logic();
            game.Run();
        }
    }
}
