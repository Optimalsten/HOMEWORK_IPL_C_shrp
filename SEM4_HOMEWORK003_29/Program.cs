// Задача 29: Напишите программу, которая задаёт массив из 8 элементов
// и выводит их на экран.
// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
// 6, 1, 33 -> [6, 1, 33]

bool GetNumArr(int size, out int[] arrayNN) // ввод элементов массива, конверт.(контроль допустим.)
{
    int[] arrayNN = new int[size];
    bool contrNum = true;
    
    Console.WriteLine($"\nЗадайте массив NN[] из {size} элементов (целых чисел)" +
    "\n для последующего вывода массива на экран.");
    
    for (int i = 0; i < size;  i++)
    {
        Console.WriteLine($"Задайте значение {i}-го элемента массива. NN[{i}] = ");
        string numberStr = Console.ReadLine();

        //contrNum = int.TryParse(numberStr, out int numN);
        contrNum = contrNum & int.TryParse(numberStr, out int numN);
        arrayNN[i] = numN; // В случае некорректного ввода array[i] будет = 0
    }
    return contrNum;
}

void Print(int[]arr)
{
    int length = arr.Length;
    for (int i = 0; i < length; i++)
    {
        Console.Write($"{arr[i]} ");
    }
}

int sizeArr = 8;
int[] arrayNN = new int[sizeArr];
bool contrN = GetNumArr(sizeArr, out int[] arrayNN);
if (!contrN)
{
    Console.WriteLine($"\nНе все заданные элементы массива целых чисел корректны.");
}
else
{
    Print(arrayNN);
}

// Задержка экрана
Console.WriteLine("\nДля продолжения нажмите любую клавишу..."); //  "\n - "возврат каретки"
Console.Read();