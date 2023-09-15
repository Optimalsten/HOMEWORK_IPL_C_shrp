// Задача 36: Задайте одномерный массив,
// заполненный случайными числами. Найдите сумму элементов,
// стоящих на нечётных позициях (индекс которых нечетный).
// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0

// МЕТОД ЗАДАНИЯ с клав-ы РАЗМЕРА МАССИВА, с контролем допустимости типа значения
int GetNumberContr(string message, out bool contrNum) // conrtNum - True (корректно)/False (некорректно)
{
    Console.Write($"\n Задайте число {message}");

    string numberStr = Console.ReadLine();
    contrNum = int.TryParse(numberStr, out int numN); // numN = 0 (если некорректно)
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
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($"{arr[i]} ");
    }
    Console.WriteLine();
}

// МЕТОД СУММИРОВАНИЯ элементов массива, индекс которых нечетный.
int GetCountEven(int[] arr) //
{
    int countN = 0;
    for (int i = 1; i < arr.Length; i += 2)
    {
        countN += arr[i];
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
    int minArr = GetNumberContr("целое (нижняя граница массива) minN: ",
                                out contrN);
    bool tempor = contrN;
    int maxArr = GetNumberContr($"целое (верхняя граница массива >= {minArr}) maxN: ",
                                out contrN);
    if (!tempor || !contrN || maxArr < minArr)
    {
        Console.WriteLine($"\n Заданные границы массива minN и/или maxN некорректны.\n");
    }
    else
    {
        int[] arr = GetArray(sizeArr, minArr, maxArr);
        Print(arr);
        Console.WriteLine($"\nСумма элементов массива, индекс которых нечетный," 
                        + $"\nравна {GetCountEven(arr)}.\n");
    }
}

// Задержка экрана
Console.Write("\nДля продолжения нажмите любую клавишу..."); //  "\n - "возврат каретки"
Console.Read();
