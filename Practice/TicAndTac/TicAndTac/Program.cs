using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicAndTac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Игра в крестики нолики");
            // Ввводные в игру 
            int playerVinX = 0, playerVinO = 0;
            int koorX, koorY;
            string playerX = "X", playerO = "O";
            
            string answerStart,koordinatX_O = "   ", answerX_Y = " ";

            string[,] battle_start = { { "1,1", "1,2", "1,3"},
                                       { "2,1", "2,2", "2,3"},
                                       { "3,1", "3,2", "3,3"} };

            string[,] battle = new string[,] { };
            
            
            

            while (true)
            {
                //Вопрос перед началом игры
                Console.WriteLine($"Cчет в игре Крестики - {playerVinX}, Нолики - {playerVinO} \n");

                Console.WriteLine("Начать игру: yes / no ?");

                // слонирование исходного массива
                battle = (string[,])battle_start.Clone();
                answerStart = Console.ReadLine().ToLower().Trim();
                switch (answerStart)
                {
                    case "no":
                        Console.WriteLine($"Выход из игры");
                        // задержка на 3 секунды
                        Thread.Sleep(2000);
                        // выход
                        Environment.Exit(0);
                        break;

                    case "yes":
                        WriteBattle(battle);
                        Console.WriteLine("Кто ходит первый X или O, exit ?");
                        do
                        {
                            answerX_Y = Console.ReadLine().ToUpper().Trim();

                            if (answerX_Y == "EXIT")
                            {
                                Console.WriteLine($"Выход из игры");
                                // задержка на 3 секунды
                                Thread.Sleep(2000);
                                // выход
                                Environment.Exit(0);
                            }
                            else if (answerX_Y != playerO && answerX_Y != playerX)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Введен не верный символ");
                                
                                Console.WriteLine();
                            }


                        } 
                        while (answerX_Y != playerO && answerX_Y != playerX);

                            while (true)

                        {
                            Console.WriteLine($"Введите координаты {answerX_Y} в формате \n" +
                                          "номер строки, номер столбика.\n" +
                                          "Пример: 1,3 или 2,2");
                            koordinatX_O = Console.ReadLine().Trim();
                            if (koordinatX_O.Length  != 3) { Console.WriteLine("Мало или много символов"); continue; }
                            if (koordinatX_O[0] != '1' && koordinatX_O[0] != '2' && koordinatX_O[0] != '3') 
                                { Console.WriteLine("Неверные первые координаты"); continue; }
                            if (koordinatX_O[1] != ',') 
                                { Console.WriteLine("Неверные разделитель координат"); continue; }
                            if (koordinatX_O[2] != '1' && koordinatX_O[2] != '2' && koordinatX_O[2] != '3') 
                                { Console.WriteLine("Неверные вторые координаты"); continue; }

                            // переводим координаты из чар в int
                            koorX = (koordinatX_O[0] - '0') - 1;
                            koorY = (koordinatX_O[2] - '0') - 1;
                            if (battle[koorX, koorY] != " X " && battle[koorX, koorY] != " O ")
                            {
                                battle[koorX, koorY] = $" {answerX_Y} ";
                                WriteBattle(battle);
                                if (CheckVictori(battle, $" {answerX_Y} "))
                                {
                                    Console.WriteLine("ПОБЕДА " + answerX_Y);
                                    if (answerX_Y == "X") 
                                    {
                                        ++playerVinX; 
                                    }
                                    else
                                    {
                                        ++playerVinO;
                                    }
                                    break;
                                } 
                                if (answerX_Y == "X") 
                                    { answerX_Y = "O"; }
                                else 
                                    { answerX_Y = "X"; }
                                continue;

                            }
                            else
                            {
                                Console.WriteLine("Данные координаты уже заняты, попробуйте еще");
                                continue;
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Не верно введенный ответ");
                        Console.WriteLine();
                        break;

                }
            }


            
            
            
            
            void WriteBattle(string[,] battle)
                // отрисоавапни поле
            {
                Console.Clear();
                Console.WriteLine($"Cчет в игре Крестики - {playerVinX}, Нолики - {playerVinO}");   
                for (int i = 0; i < battle.GetLength(0); i++)
                { 
                    Console.Write($"{battle[i,0]} | {battle[i, 1]} | {battle[i, 2]}\n");
                    Console.WriteLine("---------------");
                }
                
            }


            bool CheckVictori (string[,] battle, string x_o)
                // проверка выйгрышка
            {
                bool strokaVin = false;

                for (int i = 0; i< 3; i++)
                {
                    if (battle[0,i] == x_o && battle[1, i] == x_o && battle[2, i] == x_o)
                    {
                        strokaVin = true;
                    }    
                    if (battle[i,0] == x_o && battle[i, 1] == x_o && battle[i, 2] == x_o)
                    {
                        strokaVin = true;
                    }    

                }

                if(battle[0, 0] == x_o && battle[1, 1] == x_o && battle[2, 2] == x_o) 
                {
                    strokaVin = true;
                }
                else if (battle[2, 0] == x_o && battle[1, 1] == x_o && battle[0, 2] == x_o)
                {
                    strokaVin = true;
                }
                
                return strokaVin;
            }




        }
    }
}
