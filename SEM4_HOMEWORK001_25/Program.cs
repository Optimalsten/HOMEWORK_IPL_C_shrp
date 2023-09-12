// Задача 25: Напишите цикл, который принимает на вход два числа (A и B)
// и возводит число A в натуральную степень B.
// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16

string GetStr(string message)
{
    Console.Write($"Введите число {message}");
    string numberStr = Console.ReadLine();
    return numberStr;
}

Console.WriteLine("\nЗадайте два числа (А, В)" +
"\nдля возведения числа А в натуральную степень В.\n");

string numStrA = GetStr("A, которое будет возводиться в степень. А = ");
string numStrB = GetStr($"B (натуральное) - степень, в которую будет возводиться число {numStrA}. B = ");

bool contrA = double.TryParse(numStrA, out double numA);
bool contrB = int.TryParse(numStrB, out int numB);

bool control = contrA && contrB && numB > 0;

switch (control.ToString()) // проверка допустимых значений А и В
{
    case "False":     // одно или оба значения (заданные для А и В) - некорректны
        if (!contrA) // в numStrA - не действительное число, numA == 0
        {
            Console.WriteLine($"\nВведенное значение A некорректно.");
        }
        if (!contrB || numB <= 0) // в numStrB - ненатуральное число, numB == 0
        {
            Console.WriteLine($"\nВведенное значение B некорректно");
        }
        break;

    case "True":     // оба значения (заданные для А и В) - корректны
        double result = Math.Pow(numA, numB);
        Console.WriteLine($"\nРезультат равен {result:F3}.");
        break;
}

// Задержка экрана
Console.WriteLine("\nДля продолжения нажмите любую клавишу..."); //  "\n - "возврат каретки"
Console.Read();
