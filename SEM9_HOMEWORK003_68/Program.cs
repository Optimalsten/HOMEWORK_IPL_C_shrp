// Задача 68: Напишите программу вычисления функции Аккермана
// с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29

// МЕТОД 1 - ЗАДАНИЕ натурального, с контролем допустимости типа значения и величины, с рекурсией
int GetNumberContr(string message, int maxNumN) // conrtNum - True (корректно)/False (некорректно)
{
    Console.Write($" Задайте число {message}: ");
    string numberStr = Console.ReadLine();

    if (int.TryParse(numberStr, out int numN))
    {
        if ((numN >= 0) && (numN <= maxNumN)) // обработка корректного значения
        {
            return numN;
        }
    }
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($" Заданное значение ({numberStr}) некорректно!");
    Console.ForegroundColor = ConsoleColor.White;
    return GetNumberContr(message, maxNumN);
}

// МЕТОД 2 - Определение функции Аккермана с параметрами (m, n) , с использ. рекурсии
int FunAkkerman(int m, int n)
{
    if (m == 0)
    {
        return n + 1;
    }
    else
    {
        if ((m != 0) && (n == 0))
        {
            return FunAkkerman(m-1, 1);
        }
        else
        {
            return FunAkkerman(m-1, FunAkkerman(m, n - 1));
        }
    }
}

Console.Clear();
Console.WriteLine();

int numberM = GetNumberContr("- M (целое, натуральное, не более 3)", 3);
int numberN = GetNumberContr($"- N (целое, натуральное, не более 11)", 11);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\n Заданы параметры для функции Аккермана: m = {numberM}, n = {numberN}.");
Console.Write($" Функция Аккермана для указанных параметров равна: ");
Console.WriteLine(FunAkkerman(numberM, numberN));
Console.ForegroundColor = ConsoleColor.White; 

// Задержка экрана
Console.ForegroundColor = ConsoleColor.White;
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();