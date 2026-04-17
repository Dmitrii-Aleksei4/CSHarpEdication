using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

float a, b, f;
string ai, bi, fi;
bool aBool;


Console.WriteLine("Введите А, а не должно быть = 0");
while (true)
{
    ai = Console.ReadLine();
    if (ai != "0")
    {

        a = Convert.ToSingle(ai);
        Console.WriteLine(a);

        break;
    }
    else
    {
        Console.WriteLine("Введен 0");
    }
}


Console.WriteLine("Введите B");
bi = Console.ReadLine();
b = float.Parse(bi);

Console.WriteLine("Введите F");
fi = Console.ReadLine();
f = float.Parse(fi);



float answer = (a + b - f / a) + a + f * a * a - (a + b);
Console.WriteLine("Ответ " + answer);