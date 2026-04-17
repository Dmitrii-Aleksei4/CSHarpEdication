//Напишите программу, которая вычисляет длину катетов и гипотенузы. Все
//известные значения храните в переменных, а результаты вычислений выведите
//в консоль:
//a.Известны два катета - найти гипотенузу
//b. Известен один катет и гипотенуза - найти второй катет


int kat = 3;
int kat2 = 4;
int gip = 10;
//                число/степень 
double rez = Math.Pow(2,4);
double ddd = Math.Sqrt(16);
float vuvod = kat;
Console.WriteLine($"a.Гипотенуза = {Math.Sqrt(Math.Pow(kat,2) + Math.Pow(kat2, 2)) }");
Console.WriteLine($"б.Катет  = {Math.Round(Math.Sqrt(Math.Pow(gip,2) - Math.Pow(kat2, 2)),1) }");