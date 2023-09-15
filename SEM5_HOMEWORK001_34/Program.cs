// Задача 34: Задайте массив,
// заполненный случайными положительными трёхзначными числами.
// Напишите программу,
// которая покажет количество чётных чисел в массиве.
// [345, 897, 568, 234] -> 2

// МЕТОД ЗАДАНИЯ с клав-ы РАЗМЕРА МАССИВА, с контролем допустимости типа значения
int GetNumberContr(string message, out bool contrNum)  // conrtNum - True (корректно)/False (некорректно)
{
    // Console.Write("\n Задайте натуральное (положительное целое)" +
    // "\n число элементов массива: N = ");
    
    Console.Write($"\n Задайте число {message}");

    string numberStr = Console.ReadLine();
    contrNum = int.TryParse(numberStr, out int numN);
    return numN;
}

// МЕТОД ЗАДАНИЯ (ввода) МАССИВА целых чисел, с помощью Генератора СЧ, в диап. [min, max]
int[] GetArray(int size, int min, int max)
{
    int[] array = new int[size];
    Random rand = new Random();

    for (int i = 0; i < size; i++)
    {
        array[i] = rand.Next(min, max + 1);
    }
    return array;
}

// МЕТОД ВЫВОДА НА ЭКРАН (в строку) значений массива
void Print(int[] arr)
{
    Console.WriteLine();
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($" {arr[i]} ");
    }
    Console.WriteLine();
}

// МЕТОД ПОДСЧЕТА КОЛИЧЕСТВА ЧЕТНЫХ ЧИСЕЛ В МАССИВЕ
int GetCountEven(int[] arr)
{
    int countN = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] % 2 == 0)
        {
            countN++;
        }
    }
    return countN;
}

int sizeArr = GetNumberContr("элементов массива - натуральное (целое, положительное) N: ",
                             out bool contrN);
if (!contrN || sizeArr <= 0)
{
    Console.WriteLine($"\n Заданное значение N некорректно.\n");
}
else
{
    int[] arr = GetArray(sizeArr, 100, 999);
    Print(arr);
    Console.WriteLine($"\n Количество четных чисел в массиве равно {GetCountEven(arr)}.\n"); 
}

// Задержка экрана
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();

