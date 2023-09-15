// Задача 38: Задайте массив вещественных чисел.
// Найдите разницу между максимальным и минимальным элементами массива.
// [3 7 22 2 78] -> 76

// МЕТОД ЗАДАНИЯ с клав-ы целого числа, с контролем допустимости типа значения
int GetNumbIntContr(string message, out bool contrNum) // conrtNum - True (корректно)/False (некорректно)
{
    Console.Write($"\n Задайте число {message}");

    string numberStr = Console.ReadLine();
    contrNum = int.TryParse(numberStr, out int numN); // numN = 0 (если некорректно)
    return numN;
}

// МЕТОД ЗАДАНИЯ с клав-ы вещественного числа, с контролем допустимости типа значения
double GetNumbDblContr(string message, out bool contrNum) // conrtNum - True (корректно)/False (некорректно)
{
    Console.Write($"\n Задайте число {message}");

    string numberStr = Console.ReadLine();
    contrNum = double.TryParse(numberStr, out double numDblN); // numN = 0 (если некорректно)
    return numDblN;
}

// МЕТОД ЗАДАНИЯ (ввода) МАССИВА вещественных чисел, с помощью Генератора СЧ, в диап. [min, max]
double[] GetArray(int size, double min, double max)
{
    double[] array = new double[size];
    Random rand = new Random();
    
    for (int i = 0; i < size; i++)
    {
        array[i] = rand.NextDouble() * (max - min) + min;
    }
    return array;
}

// МЕТОД ВЫВОДА НА ЭКРАН (в строку) значений массива вещественных чисел
void Print(double[] arr)
{
    Console.WriteLine();
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($" {arr[i]:F3} ");
    }
    Console.WriteLine();
}

// МЕТОД определения РАЗНОСТИ между максимальным и минимальным значениями элементов массива.
double GetDifferArr(double[] arr) //
{
    double minArr = arr[0];
    double maxArr = arr[0];

    for (int i = 1; i < arr.Length; i++)
    {
        if (minArr > arr[i])
        {
            minArr = arr[i];            
        }
        else if (maxArr < arr[i])
        {
            maxArr = arr[i];
        }
    }
    return maxArr - minArr;
}

// ЗАДАНИЕ с клав-ы РАЗМЕРА МАССИВА, с контролем допустимости задан.данных, вкл.тип значения
int sizeArr = GetNumbIntContr("элементов массива - натуральное (целое, положительное) \t N: ",
                             out bool contrN);
if (!contrN || sizeArr <= 0)
{
    Console.WriteLine($"\n Заданное значение N некорректно.\n");
}
else
{
    // ЗАДАНИЕ с клав-ы ГРАНИЦ МАССИВА, с контролем допустимости заданных данных
    double minArr = GetNumbDblContr("вещественное (нижняя граница массива) \t\t\t minN: ",
                                out contrN);
    bool tempor = contrN;
    double maxArr = GetNumbDblContr($"вещественное (верхняя граница массива >= {minArr}) \t\t maxN: ",
                                out contrN);
    if (!tempor || !contrN || maxArr < minArr)
    {
        Console.WriteLine($"\n Заданные границы массива minN и/или maxN некорректны.\n");
    }
    else
    {

        // ЗАДАНИЕ МАССИВА веществ.чисел, с помощью ГСЧ, в диап. [minArr, maxArr]        
        double[] arr = GetArray(sizeArr, minArr, maxArr);

        // ВЫВОД на экран "сгенерированного" массива
        Print(arr);

        // ОПРЕДЕЛЕНИЕ и ВЫВОД на экран РЕЗУЛЬТАТА
        Console.WriteLine($"\n Разница между максимальным и минимальным элементами массива" 
                        + $" равна \t {GetDifferArr(arr):F3}.\n");
    }
}

// Задержка экрана
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();
