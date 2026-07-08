using Data_job_1._0.Model;
using Data_job_1._0.Services;
using Data_job_1._0.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_job_1._0.Logis
{
    internal class ProgLog
    {

        private readonly ServicesDB _jobDB;
        private readonly Screen _screen;
        private readonly ServicesProgram _servicesProgram;

        public ProgLog()
        {
            _jobDB = new ServicesDB();
            _screen = new Screen();
            _servicesProgram = new ServicesProgram();
        }

        public void StartScreen()
        {

            while (true)
            {
                _screen.StartScreen();

                var check_choice = _servicesProgram.CheckingInputChoise(4);

                switch (check_choice)
                {
                    case "1":
                        var users = _jobDB.GetAllUsers();
                        _screen.OutputWorker(users);
                        _screen.MessageSceen("Для возврата нажните любую кнопку");
                        Console.ReadKey();
                        break;
                    case "2":
                        _screen.InputID();

                        var UserID = _servicesProgram.CheckingInputID();
                        var user = _jobDB.GetUser(UserID);
                        if (user == null)
                        {
                            _screen.MessageSceen("Нет такого ID", 0.2);
                            Console.ReadKey();
                        }
                        else
                        {
                            _screen.OutputOneWorker(user);
                            Console.ReadKey();
                        }

                        break;
                    case "3":

                        bool munuCreat_del_update = true;
                        while (munuCreat_del_update)
                        {

                            users = _jobDB.GetAllUsers();
                            _screen.OutputWorker(users);
                            _screen.Creat_del_update();
                            check_choice = _servicesProgram.CheckingInputChoise(4);
                            switch (check_choice)
                            {
                                case "1":

                                    _screen.MessageSceen("Введите Имя нового работника", 0);
                                    var Name = _servicesProgram.inputRemoveUser();
                                    _screen.MessageSceen("Введите Какая часовая ставка", 0);
                                    var Pay_hour = _servicesProgram.inputAddUser();
                                    _screen.MessageSceen("Введите Сколько часов отработал", 0);
                                    var Hour_work = _servicesProgram.inputAddUser();
                                    _screen.MessageSceen("Введите Сколько часов должен отработать", 0);
                                    var Must_work = _servicesProgram.inputAddUserMust_work(Hour_work);
                                    User uz = new User(Name, Pay_hour, Hour_work, Must_work);
                                    _jobDB.AddUser(uz);
                                    _screen.MessageSceen("Пользователь добавлен", 1);
                                    break;

                                case "2":
                                    _screen.InputID();
                                    UserID = _servicesProgram.CheckingInputID();
                                    if (_jobDB.DeleteUser(UserID))
                                    {
                                        _screen.MessageSceen("Работник Удален",1);
                                    }
                                    else
                                    {
                                        _screen.MessageSceen("По данну ID, работник не найден",1);
                                    }
                                    break;

                                case "3":

                                    _screen.InputID();
                                    UserID = _servicesProgram.CheckingInputID();
                                    user = _jobDB.GetUser(UserID);
                                    if (user == null) { _screen.MessageSceen("Нет такого ID", 2); continue; }

                                    bool menuUppend_Users = true;
                                    while (menuUppend_Users) 
                                    {
                                        _screen.ClearS();
                                        _screen.Uppend_Users(user);
                                        check_choice = _servicesProgram.CheckingInputChoise(5);
                                        switch (check_choice)
                                        {
                                            case "1":
                                                _screen.MessageSceen("Введите Измененое работника", 0);
                                                Name = _servicesProgram.inputRemoveUser();
                                                user.Name = Name;
                                                _jobDB.UpdateUser(user);
                                                break;
                                            case "2":
                                                _screen.MessageSceen("Введите Новую часовую ставка", 0);
                                                Pay_hour = _servicesProgram.inputAddUser();
                                                user.Pay_hour = Pay_hour;
                                                _jobDB.UpdateUser(user);
                                                break;
                                            case "3":
                                                _screen.MessageSceen("Введите измененные отработанные часы", 0);
                                                Hour_work = _servicesProgram.inputAddUser();
                                                user.Hour_work = Hour_work;
                                                _jobDB.UpdateUser(user);
                                                break;
                                            case "4":
                                                _screen.MessageSceen("Введите изменения в сколько должен отработать", 0);
                                                Must_work = _servicesProgram.inputAddUserMust_work(user.Hour_work);
                                                user.Must_work = Must_work;
                                                _jobDB.UpdateUser(user);
                                                break;


                                            case "5":
                                                menuUppend_Users = false;
                                                break;

                                        }




                                    }

                                    break;



                                case "4":
                                    munuCreat_del_update = false;
                                    _screen.MessageSceen("🔙 Возврат в главное меню...", 1);
                                    break;
                            }

                        }
                        break;
                    case "4":

                        _screen.MessageSceen("Cпасибо что воспользовались моей программой", 1.5);
                        Environment.Exit(0);


                        break;

                }
            }

        }
        


        public void Run()
        {
            StartScreen();
        } 

        
    }
    
}
