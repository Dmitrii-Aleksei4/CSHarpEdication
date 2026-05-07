using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook_4_SQL_Dapper
{
    internal class Abonent
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Number {  get; set; }

        public Abonent() { }
        public Abonent (string name, string number, int id = 0)
        {
            this.Name = name;
            this.Number = number;
            this.Id = id;
        }


    }
}
