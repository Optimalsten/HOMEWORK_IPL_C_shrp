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
double[,] GetNumDblArr(int sizeRow, int sizeCol, out bool contrNumber)
{
    double[,] arrayDbl = new double[sizeRow, sizeCol];
    contrNumber = true; // интегратор контроля допустимости введеных значений True/False
    bool contrTem = true;
    Console.WriteLine($"\n Задайте последовательно {sizeRow * sizeCol} вещественных числа" +
    " - коэффициенты k и b линейных уравнений вида y = kx + b.");
    for (int i = 0; i < sizeRow; i++)
    {
        Console.WriteLine($"\n Введите коэф-ты k (1-ый) и b (2-ой) для {i + 1}-го уравнения.");
        for (int j = 0; j < sizeCol; j++)
        {
            arrayDbl[i, j] = GetNumbDblContr($"- значение {j + 1}-го коэф-та = ", out contrTem);
        }
        // В случае некорректного ввода array[i,j] будет = 0
        contrNumber = contrNumber && contrTem;
    }
    return arrayDbl;
}
// МЕТОД 3 - РЕШЕНИЕ СИСТЕМЫ 2-ух линейных уравнений
void CalcSysLinEq(double[,] arr, out double xPoint, out double yPoint)
{
    xPoint = Math.Round((arr[1, 1] - arr[0, 1]) / (arr[0, 0] - arr[1, 0]), 2);
    yPoint = Math.Round((arr[1, 0] * arr[0, 1] - arr[0, 0] * arr[1, 1]) / (arr[1, 0] - arr[0, 0]), 2);
}

// МЕТОД 4 - вывод на экран линейного уравнения
void PrintScrDbl(int numEquat, double Row, double Col)
{
    Console.Write($"\n {numEquat}-ое уравнение: у = {Row} x + {Col} \n");
}


// ЗАДАНИЯ с клав-ы коэф-тов "k" и "b" двух линейных уравнений типа y = kx + b,
int sizeRow = 2;
int sizeCol = 2;
double[,] arr = GetNumDblArr(sizeRow, sizeCol, out bool contrNumb);
if (!contrNumb)
{
    Console.WriteLine($"\n Заданные значения (которые должны быть числами) некорректны.\n");
}
else
{
    // ВЫВОД на экран "заданных" уравнений
    for (int i = 0; i < sizeRow; i++)
    {
        PrintScrDbl(i + 1, arr[i, 0], arr[i, 1]);
    }
    // ОПРЕДЕЛЕНИЕ и ВЫВОД на экран РЕЗУЛЬТАТА
    if (arr[0, 0] == arr[1, 0] && arr[0, 1] == arr[1, 1])
    {
        Console.WriteLine($"\n Заданные Вами прямые совпадают.\n");
    }
    else if ((arr[0, 0] == arr[1, 0]) && !(arr[0, 1] == arr[1, 1]))
    {
        Console.WriteLine($"\n Заданные Вами прямые параллельны и не пересекаются.\n");
    }
    else
    {
        double xPoint;
        double yPoint;
        CalcSysLinEq(arr, out xPoint, out yPoint);
        Console.WriteLine($"\n Заданные Вами прямые пересекаются в точке ({xPoint}, {yPoint}).\n");
    }
}

// Задержка экрана
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();