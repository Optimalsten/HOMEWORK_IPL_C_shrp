// Задача 27: Напишите программу, которая принимает на вход число
// и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12

int GetStr(out bool contrNum) // ввод c клавиатуры, конвертация (контроль допустимости)
{
    Console.Write("\nЗадайте натуральное (положительное целое)" +
    "\n число N для определения количества цифр в нем. N = ");
    
    string numberStr = Console.ReadLine();
    contrNum = int.TryParse(numberStr, out int numN);

    return numN;
}

int Getcount(int num) // суммирование всех цифр натурального числа
{
    int count = 0;
    for (; 0 < num; num /= 10)
    {
        count = count + num % 10;
    }
    return count;
}

int numberN = GetStr(out bool contrN);
if (!contrN || numberN <= 0)
{
    Console.WriteLine($"\nЗаданное значение N некорректно.");
}
else
{
    Console.WriteLine($"\nСумма цифр числа {numberN} равна {Getcount(numberN)}.");
}

// Задержка экрана
Console.WriteLine("\nДля продолжения нажмите любую клавишу..."); //  "\n - "возврат каретки"
Console.Read();
