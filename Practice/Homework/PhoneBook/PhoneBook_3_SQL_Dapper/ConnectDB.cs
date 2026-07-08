using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneBook_3_SQL_Dapper
{
    internal class ConnectDB
    {

        string tract = "Data Source = PhoneBook.db";

        public ConnectDB()
        {
            Create_DB();

        }


        private void Create_DB()
        {
            using (var connect = new SqliteConnection(tract))
            {
                connect.Open();
                string createDB = @"
                    CREATE TABLE IF NOT EXISTS Abonent (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        Name TEXT NOT NULL, 
                        Number TEXT NOT NULL
                    )";

                connect.Execute(createDB);
            }
        }

        // получение индивидального абонента 
        public void AddAbonent(Abonent abonent)
        {
           
            using(var connect = new SqliteConnection(tract))
            {
                connect.Open();
                connect.Execute("INSERT INTO Abonent (Name, Number) VALUES (@Name, @Number)", abonent);

            }
        }
        // Удаление индивидального абонента 
        public void DelAbonent(string number)
        {
           
            using(var connect = new SqliteConnection(tract))
            {
                connect.Open();
                connect.Execute("DELETE FROM Abonent WHERE Number = @Number", new {Number = number });

            }
        }

        public void UpdateAbonent(string number, string newNumber, string newName)
        {

            using (var connect = new SqliteConnection(tract))
            {
                connect.Open();
                connect.Execute("UPDATE Abonent SET Name = @newName, Number = @newNumber WHERE Number = @oldNumber", 
                    new { newNumber = newNumber, newName = newName , oldNumber = number });

            }
        }


        // выбор всех абонентонв 
        public List<Abonent> GetAllAbonent()

        {
            List<Abonent> phone;
            using (var connect = new SqliteConnection(tract))
            {
                connect.Open();
                phone = connect.Query<Abonent>("SELECT * FROM Abonent").ToList();
                //IEnumerable<Abonent> abonentsDB = connect.Query<Abonent>("SELECT * FROM Abonent");
                //foreach (var abonentDB in abonentsDB)
                //{
                //    Console.WriteLine(abonentDB);
                //    phone.Add(abonentDB);    
                //}
            
            }    
            
            return phone;
        }
    }
}
