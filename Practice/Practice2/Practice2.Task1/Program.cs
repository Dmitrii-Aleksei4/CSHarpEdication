//a
for (int i = 0; i < 7; i++) Console.WriteLine(i);
//b
int x = 0;
while (x < 5)
{
    Console.WriteLine(x);
    x++;
}
//c
do
{
    Console.WriteLine(x);
    x--;
}
while (x > 0);
//d
string srt_start = null, str;

Console.WriteLine("Введите фразу цикл Фор");
for (int i = 0; i < 3; i++)
{
    str = Console.ReadLine();
    srt_start += str + " ";
    Console.WriteLine(srt_start);
}

//e
Console.WriteLine("Введите фразу цикл Вайле");
srt_start = null;
while (x < 3)
{
    str = Console.ReadLine();
    srt_start += str + " ";
    Console.WriteLine(srt_start);
    x++;
}
//f 
Console.WriteLine("Введите фразу цикл DO Вайле");
do
{
    str = Console.ReadLine();
    srt_start += str + " ";
    Console.WriteLine(srt_start);
    x--;
}
while (x > 0);