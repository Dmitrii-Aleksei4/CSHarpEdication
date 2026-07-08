Console.WriteLine("Hello, World!");
//a 
Console.WriteLine("Сколько раз рисовать *");
int a = Convert.ToInt32(Console.ReadLine());
int b = 0;
string star = "", star_end = "", new_start_end;
while (b < a)
{
    star += "b";
    Console.WriteLine(star);
    star_end += " ";



    b++;


}

b = a;

while (b > 0)
{


    new_start_end = star_end.Remove(0, 1) + "b";
    Console.WriteLine(new_start_end);
    b--;
    star_end = new_start_end;
}

// c

Console.WriteLine("Сколько раз рисовать *");
a = Convert.ToInt32(Console.ReadLine());
b = 0;
Console.WriteLine("Введите символ");
string chars = Console.ReadLine();
star = ""; star_end = "";
while (b < a)
{
    star += chars;
    Console.WriteLine(star);
    star_end += " ";



    b++;


}

b = a;

while (b > 0)
{


    new_start_end = star_end.Remove(0, 1) + chars;
    Console.WriteLine(new_start_end);
    b--;
    star_end = new_start_end;
}