// Задача 64: Задайте значение N. Напишите программу,
// которая выведет все натуральные числа в промежутке от N до 1.
// Выполнить с помощью рекурсии.
// N = 5 -> "5, 4, 3, 2, 1"
// N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"

// МЕТОД 1 - ЗАДАНИЕ натурального N, с контролем допустимости типа значения, с рекурсией
int GetNumberContr(string message) // conrtNum - True (корректно)/False (некорректно)
{
    Console.Write($"\n Задайте число {message}: ");
    string numberStr = Console.ReadLine();

    if (int.TryParse(numberStr, out int numN))
    {
        if (numN > 0) // обработка неположительного значения
        {
            return numN;
        }
    }
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($" Заданное значение ({numberStr}) некорректно!");
    Console.ForegroundColor = ConsoleColor.White;
    return GetNumberContr(message);
}

// МЕТОД 2 - ВЫВОД НА ЭКРАН значений от N до 1 (с использ. рекурсии)
void PrintNewNumb(int numberN)
{
    if (numberN > 0)
    {
        Console.Write($" {numberN} ");
        PrintNewNumb(numberN - 1);
    }
}

Console.Clear();
Console.WriteLine();

int numberN = GetNumberContr("- N (целое, натуральное)");
Console.ForegroundColor = ConsoleColor.Green;
PrintNewNumb(numberN);
Console.ForegroundColor = ConsoleColor.White;

// Задержка экрана
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.White;
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();
