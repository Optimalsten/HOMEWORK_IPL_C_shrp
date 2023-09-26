// Задача 56: Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку
// с наименьшей суммой элементов.

// МЕТОД 1 - ЗАДАНИЯ с клав-ы целого числа (без контроля допустимости типа значения)
int SetNumber(string message)
{
    Console.Write($" Введите число {message}: \t");
    int num = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    return num;
}

// МЕТОД 2 - ВЫВОД НА ЭКРАН (матрицей) значений 2-мерного массива целых чисел
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int l = 0; l < matrix.GetLength(1); l++)
        {
            Console.Write($" {matrix[i, l]}\t");
        }
        Console.WriteLine();
    }
}

// МЕТОД 3 - ЗАДАНИЕ 2-мерного МАССИВА целых чисел, с помощью Генератора СЧ, в диап. [min, max]
int[,] GetMatrix(int rows, int columns, int min = 0, int max = 99)
{
    int[,] matrix = new int[rows, columns];
    Random rand = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = rand.Next(min, max + 1);
        }
    }
    return matrix;
}

// МЕТОД 4 - Поиск суммы квадратов 1-мерного МАССИВА 
int GetSumSqr1DimArr(int[] array)
{
    int count = 0;
    foreach (int item in array)
    {
        count += item * item;
    }
    return count;
}

// МЕТОД 5 - Поиск строки матрицы с наименьшей суммой квадратов
void SortRowsIncr2DimMatr(int[,] matrix, out int minSummSqrRow, out int rowMinSummSqr)
{
    int[] array = new int[matrix.GetLength(1)];
    int minSummSqrRow = 2147483647; // присвоение начального значения
    int rowMinSummSqr = 0; // присвоение начального значения
    int temp; // инициализация
    
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            array[j] = matrix[i, j];
        }
        
        temp = GetSumSqr1DimArr(int[] array);
        if (temp < minSummSqrRow)
        {
            minSummSqrRow = temp;
            rowMinSummSqr = i; // присвоение номера текущей строки (+1 = номер строки матрицы)
        }
    }
}

Console.Clear();
Console.WriteLine();
int rows = SetNumber("- количество строк (< или > количества столбцов)");
int columns = SetNumber("- количество столбцов (неравное количеству строк)");
if (rows == columns)
{
    Console.WriteLine($"\n Количество строк = количеству столбцов. Данные некорректны.");
}
else
{
    int[,] result = GetMatrix(rows, columns);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Исходная (генерированная Random) матрица:");
    PrintMatrix(result);
    Console.WriteLine();

    SortRowsIncr2DimMatr(result);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(" Итоговая матрица (элементы строк упорядочены по убыванию):");
    PrintMatrix(result);
    Console.WriteLine();    
}

// Задержка экрана
Console.ForegroundColor = ConsoleColor.White;
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();