// Задача 43. Напишите программу,
// которая найдёт точку пересечения двух прямых,
// заданных уравнениями y = k1 * x + b1,   y = k2 * x + b2;
// значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9  --> (-0,5; -0,5)
// проверяем k1 == k2:
//      если верно,
//         то проверяем b1 == b2:
//              если верно, то "заданые прямые совпадают"
//         иначе (при b1 !== b2):
//              "прямые параллельны и не имеют точек пересечения"
//      если нет,
//         x = (b2 - b1) / (k1 - k2);
//         y = (k2 * b1 - k1 * b2) / (k2 - k1);
//

// МЕТОД 1 - ЗАДАНИЯ с клав-ы вещественного числа, с контролем допустимости типа значения
double GetNumbDblContr(string message, out bool contrNum) // conrtNum - True (корректно)/False (некорректно)
{
    Console.Write($" Задайте число {message}");

    string numberStr = Console.ReadLine();
    contrNum = double.TryParse(numberStr, out double numDblN); // numN = 0 (если некорректно)
    return numDblN;
}

// МЕТОД 2 - ЗАДАНИЯ с клав-ы коэф-тов "k" и "b" для линейного уравнения типа y = kx + b,
// конвертация с контролем допустим.типа значения
double[] GetNumDblArr(int size, out bool contrNumber)
{
    double[] arrayDbl = new double[size];
    // string numberStr;
    contrNumber = true; // интегратор контроля допустимости введеных значений True/False
    // bool contrTem; // переменная контроля допустимости текущего введенного значения
           
    Console.WriteLine($"\n Задайте последовательно {size} вещественных чисел.");
    for (int i = 0; i < size;  i++)
    {
        arrayDbl[i] = GetNumbDblContr($"- значение {i+1}-го числа = ", out bool contrTem);
        // В случае некорректного ввода array[i] будет = 0
        contrNumber = contrNumber && contrTem;
    }
    return arrayDbl;
}

// МЕТОД 4 - вывод на экран результатов задания коэф-тов линейного уравнения с клавиатуры
void PrintScrDbl(double[] arrDbl)
{
    int length = arrDbl.Length;
    Console.Write($"\n Задано {length} вещественных чисел:\n [");
    for (int i = 0; i < length; i++)
    {
        Console.Write($" {arrDbl[i]} ");
    }
    Console.Write($"]");
}
