using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook_3_SQL_Dapper
{
    // книга
    internal class Books
    {
        private static Books PhoneBook;
        private  List<Abonent> abbonent;
        private ConnectDB connectDB;

        private Books(ConnectDB connect_DB) 
        {
            connectDB = connect_DB;
            abbonent = AllAbonent();

        }
        
        public static Books GetPhoneBook(ConnectDB connect_DB)
        {
            if (PhoneBook == null)
                PhoneBook = new Books(connect_DB);
            return PhoneBook;
            


        }

        public void AddAbonent(string number, string name)
        {
            //var em = new Abonent( "dds", 444);
            
            abbonent.Add(new Abonent(number,name));
            
            //PhoneBook.abbonent.Add(new Abonent( "dds", 443));

        }
        
        public List<Abonent> AllAbonent()
        {


            abbonent = connectDB.GetAllAbonent();
           
            return abbonent;
        }
        public bool CheckNumber(string number)
        {
            foreach (var abonent in abbonent) 
            {
                if (abonent.Number == number) { return true; }
            }
            return false;
        }

        public string GetNameAbonent(string number) 
        {
            
            foreach (var abonent in abbonent)
            {
                if (abonent.Number == number) { return abonent.Name; }
            }
            return null;
        }

        public void DelAbonent(string number)
        {
            for(var i = 0;  i < abbonent.Count; i++)
            {
                if (abbonent[i].Number == number) abbonent.RemoveAt(i);
            }
        }
        
        public void UpdateAbonent(string number, string newNumber, string newName)
        {
            for (var i = 0; i < abbonent.Count; i++)
            {
                if (abbonent[i].Number == number)
                {
                    abbonent[i].Number = newNumber;
                    abbonent[i].Name = newName;
                }
            }
        }

    }

}
