using System;
using System.Collections.Generic;
using System.Text;
using Data_job_1._0.Model;
using Microsoft.EntityFrameworkCore;


namespace Data_job_1._0.DataBase
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Путь к файлу БД (создастся в папке с проектом)
            optionsBuilder.UseSqlite("Data Source=myapp.db");
        }
    }
}
