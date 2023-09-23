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
    if (!contrNumb)
    {
        Console.WriteLine($"\n Заданные значения (которые должны быть числами) некорректны.\n");
    }
    else
    {
        // ВЫВОД на экран "заданного" массива
        PrintScrDbl(arr);

        // ОПРЕДЕЛЕНИЕ и ВЫВОД на экран РЕЗУЛЬТАТА
        Console.WriteLine($"\n Среди заданных количество чисел больше 0\t= {GetNumGreater0(arr)}.\n");
    }
}

// Задержка экрана
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();





Start();

void Start()
{

    while (true)
    {
        Console.ReadKey();
        Console.Clear();

        System.Console.WriteLine("34) Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.");
        System.Console.WriteLine("36) Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.");
        System.Console.WriteLine("38) Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.");
        System.Console.WriteLine("0) End");

        int numTask = SetNumber("task");
        const int num = 36;
        
        switch (numTask)
        {
            case 0: return; break;

            case 34:
                Console.Clear();
                int[] startArray = GetArray(12, 100, 999);
                Console.WriteLine(String.Join(" ", startArray));
                Console.WriteLine($"Количество четных элементов в массиве = {GetEvenCount(startArray)}");
                break;
            case num:
                Console.Clear();
                startArray = GetArray(6, 0, 99);
                Console.WriteLine(String.Join(" ", startArray));
                Console.WriteLine($"Сумма элементов на нечетных позициях = {GetSumOdd(startArray)}");

                break;


            case 38:
                Console.Clear();
                double[] startArrayDouble = GetArrayDouble(6, 0, 999);
                Console.WriteLine(String.Join(" ", startArrayDouble));
                Console.WriteLine($"Разница = {GetDifference(startArrayDouble)}");
                break;
            default: System.Console.WriteLine("error"); break;
        }
    }
}

int SetNumber(string numberName)
{
    Console.Write($"Enter number {numberName}: ");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}

int[] GetArray(int size, int minValue, int maxValue)
{
    int[] res = new int[size];
    Random rand = new Random();
    for (int i = 0; i < size; i++)
    {
        res[i] = rand.Next(minValue, maxValue + 1);
    }
    return res;
}

double[] GetArrayDouble(int size, int minValue, int maxValue)
{
    double[] res = new double[size];

    var randon = new Random();

    for (int i = 0; i < size; i++)
    {
        res[i] = Math.Round((randon.Next(minValue, maxValue) + randon.NextDouble()), 2); // 45 + 0.456854368
    }
    return res;
}

//Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу,
// которая покажет количество чётных чисел в массиве.


int GetEvenCount(int[] array)
{
    int count = 0;
    //[4,5,6,14]
    foreach (int item in array)
    {
        if (item % 2 == 0) count++;
    }

    return count;
}


//Задайте одномерный массив, заполненный случайными числами. 
//Найдите сумму элементов, стоящих на нечётных позициях.
int GetSumOdd(int[] array)
{
    int sum = 0;
    // for (int i = 0; i < array.Length; i++)
    // {
    //     if (i % 2 == 1) sum += array[i];
    // }

    for (int i = 1; i < array.Length; i += 2)
    {
        sum += array[i];
    }

    return sum;
}

//Задайте массив вещественных чисел. 
//Найдите разницу между максимальным и минимальным элементов массива.
double GetDifference(double[] array)
{
    double min = array[0];
    double max = array[0];
    // double min = 0;
    // double max = 0;
    foreach (double item in array)
    {
        if (min > item) min = item;
        if (max < item) max = item;
    }
    return max - min;
}




int GetNumber(string message)
{
    Console.Write($"Введите число {message}: ");
    int num = int.Parse(Console.ReadLine());
    return num;
}

// int decNumber = GetNumber("dec");
// int otherSystem = GetNumber("System");
// System.Console.WriteLine(DecToNum(decNumber, otherSystem));

string DecToNum(int decNumber, int otherSystem = 2)
{
    if (otherSystem > 16 || otherSystem < 2)
        return "Такой системы исчисления не существует((!!!";


    string res = "";
    string nums = "0123456789ABCDEF";
    while (decNumber > 0)
    {
        res = nums[decNumber % otherSystem] + res;// res = "0" + "" ="0"  // res = "1"+ "0"
        decNumber /= otherSystem;//d=535
    }
    return res;
}

20:40
