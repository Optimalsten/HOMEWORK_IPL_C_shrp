// Задача 41: Пользователь вводит с клавиатуры M чисел.
// Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2         -> 2
// -1, -7, 567, 89, 223    -> 3

// МЕТОД 1 - ЗАДАНИЯ с клав-ы целого числа, с контролем допустимости типа значения
int GetNumbIntContr(string message, out bool contrNum) // conrtNum - True (корректно)/False (некорректно)
{
    Console.Write($"\n Задайте число {message}");

    string numberStr = Console.ReadLine();
    contrNum = int.TryParse(numberStr, out int numM); // numM = 0 (если некорректно)
    return numM;
}

// МЕТОД 2 - ЗАДАНИЯ с клав-ы вещественного числа, с контролем допустимости типа значения
double GetNumbDblContr(string message, out bool contrNum) // conrtNum - True (корректно)/False (некорректно)
{
    Console.Write($" Задайте число {message}");

    string numberStr = Console.ReadLine();
    contrNum = double.TryParse(numberStr, out double numDblN); // numN = 0 (если некорректно)
    return numDblN;
}

// МЕТОД 3 - ЗАДАНИЯ с клав-ы массива вещественного числа,
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

// МЕТОД 4 - определение в получаемом массиве вещественных чисел количества чисел > 0.
int GetNumGreater0(double[] arr)
{
    int counter = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] > 0)
        {
            counter++;
        }
    }
    return counter;
}


// МЕТОД 5 - вывод на экран результатов задания массива вещественных чисел с клавиатуры
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

// ЗАДАНИЕ с клав-ы РАЗМЕРА МАССИВА, с контролем допустимости задан.данных, вкл.тип значения
int sizeArr = GetNumbIntContr("- количество вводимых далее чисел (целое, положительное) \t N: ",
                             out bool contrN);
if (!contrN || sizeArr <= 0)
{
    Console.WriteLine($"\n Заданное значение N некорректно.\n");
}
else
{
    // ЗАДАНИЕ с клав-ы массива вещественного числа, конвертация с контролем допустим.типа значения
    double[] arr = GetNumDblArr(sizeArr, out bool contrNumb);
    // bool tempor = contrNumb;
    
    if (!contrNumb)
    {
        Console.WriteLine($"\n Заданные значения (которые должны быть числами) некорректны.\n");
    }
    else
    {
        // ВЫВОД на экран "сгенерированного" массива
        PrintScrDbl(arr);

        // ОПРЕДЕЛЕНИЕ и ВЫВОД на экран РЕЗУЛЬТАТА
        Console.WriteLine($"\n Среди заданных количество чисел больше 0\t= {GetNumGreater0(arr)}.\n");
    }
}

// Задержка экрана
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();
