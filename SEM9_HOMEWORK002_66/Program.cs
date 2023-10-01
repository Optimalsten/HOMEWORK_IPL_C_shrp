// Задача 66: Задайте значения M и N.
// Напишите программу, которая найдёт сумму натуральных элементов
// в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

// МЕТОД 1 - ЗАДАНИЕ натурального, с контролем допустимости типа значения, с рекурсией
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

// МЕТОД 2 - ВЫВОД НА ЭКРАН значений от M до N (с использ. рекурсии)
void PrintNewNumb(int numberM, int numberN)
{
    if (numberM <= numberN)
    {
        Console.Write($" {numberM}\t");
        PrintNewNumb(numberM + 1, numberN);
    }
}

// МЕТОД 3 - Сумма натуральных чисел от M до N (включительно, с использ. рекурсии)
int SummBetwMN(int M, int N)
{
    int sumTemp = 0;
    if (M <= N)
    {
        sumTemp = M + SummBetwMN(M + 1, N);
    }
    return sumTemp;
}

Console.Clear();
Console.WriteLine();

int numberM = GetNumberContr("- M (целое, натуральное)");
int numberN = GetNumberContr($"- N (целое, натуральное, которое больше или равно {numberM})");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($" Задан ряд натуральных чисел от {numberM} до {numberN}:\n");
PrintNewNumb(numberM, numberN);
Console.Write($"\n\n Сумма указанных натуральных чисел равна: ");
Console.WriteLine(SummBetwMN(numberM, numberN));
Console.ForegroundColor = ConsoleColor.White; 

// Задержка экрана
Console.ForegroundColor = ConsoleColor.White;
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();
