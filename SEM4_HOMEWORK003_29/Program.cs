// Задача 29: Напишите программу, которая задаёт массив из 8 элементов
// и выводит их на экран.
// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
// 6, 1, 33 -> [6, 1, 33]

int[] GetNumArr(int size, out bool contrNum) // ввод элементов массива, конверт.(контроль допустим.)
{
    int[] arrayNN = new int[size];
    string numberStr;
    contrNum = true; // интегратор контроля допустимости введеных значений True/False
    bool contrTem; // переменная контроля допустимости текущего введенного значения
           
    Console.WriteLine($"\nЗадайте массив NN[] из {size} элементов (целых чисел)" +
    "\nдля последующего вывода массива на экран.\n");
    
    for (int i = 0; i < size;  i++)
    {
        Console.Write($"Задайте значение {i}-го элемента массива. NN[{i}] = ");
        numberStr = Console.ReadLine();

        contrTem = int.TryParse(numberStr, out int numN);
        contrNum = contrNum && contrTem;
        
        arrayNN[i] = numN; // В случае некорректного ввода array[i] будет = 0
    }
    return arrayNN;
}

void PrintScr(int[]arr) // вывод на экран результатов задания массива с клавиатуры
{
    int length = arr.Length;
    Console.Write($"\nЗадан массив целых чисел NN[] из {length} элемента(ов):\n[  ");
    for (int i = 0; i < length; i++)
    {
        Console.Write($"{arr[i]}  ");
    }
    Console.Write($"]");
}

int sizeArr = 8;
int[] arrayNN = new int[sizeArr];
arrayNN = GetNumArr(sizeArr, out bool contrN); // элементы с некоррект.данными = 0
if (!contrN)  // если при вводе значений элементов массива были некорректные данные
{
    Console.WriteLine($"\nНе все заданные элементы массива целых чисел корректны.");
}
else // если все значения элементов массива были введены корректно - то вывод на экран
{
    PrintScr(arrayNN);
}

// Задержка экрана
Console.WriteLine("\n\nДля продолжения нажмите любую клавишу..."); //  "\n - "возврат каретки"
Console.Read();
