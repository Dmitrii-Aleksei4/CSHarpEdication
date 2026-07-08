using Data_job_1._0.DataBase;
using Data_job_1._0.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_job_1._0.Services
{
    internal class ServicesDB
    {
        private readonly AppDbContext _context;

        public ServicesDB()
        {
            _context = new AppDbContext();
            _context.Database.EnsureCreated(); // Создает БД и таблицу
        }
        /// <summary>
        /// Добавление Работника
        /// </summary>
        /// <param name="users"></param>
        public void AddUser(User users)
        {
            _context.Users.Add(users);
            _context.SaveChanges();
        }
        /// <summary>
        /// получение всех пользователей
        /// </summary>
        /// <returns>Выводи спискок</returns>
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        /// <summary>
        /// Поиск по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User? GetUser(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }


        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) 
            {
                return false;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        
        }

        public bool UpdateUser(User user)
        {


            // Находим пользователя в базе данных
            var existingUser = _context.Users.Find(user.ID);


            // Обновляем данные
            existingUser.Name = user.Name;
            existingUser.Pay_hour = user.Pay_hour;
            existingUser.Hour_work = user.Hour_work;
            existingUser.Must_work = user.Must_work;

            // Сохраняем изменения
            _context.SaveChanges();
            return true;

        }
     }
}
