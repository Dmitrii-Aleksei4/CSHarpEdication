Console.WriteLine("Hello, World!");
Console.WriteLine("Введите первое целое число A");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите второе целое число B");
int  b = Convert.ToInt32(Console.ReadLine());
if  (a == b) Console.WriteLine("a=b");
if  (a > b) Console.WriteLine("a>b");
if  (a < b) Console.WriteLine("a<b");

Console.ReadKey();