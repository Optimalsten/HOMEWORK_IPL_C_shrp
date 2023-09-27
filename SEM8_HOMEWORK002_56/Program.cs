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
        Console.WriteLine($"\t\t строка под индексом j = {i}\t");
        // Console.WriteLine();
    }
}

// МЕТОД 3 - ЗАДАНИЕ 2-мерного МАССИВА целых чисел, с помощью Генератора СЧ, в диап. [min, max]
int[,] GetMatrix(int rows, int columns, int min = 0, int max = 9)
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

// МЕТОД 5 - Поиск строки 2-хмерного массива с наименьшей суммой квадратов
void SortRowsIncr2DimMatr(int[,] matrix, out int minSummSqrRow, out int rowMinSummSqr)
{
    minSummSqrRow = 2147483647; // присвоение начального значения переменной суммы квадратов
    rowMinSummSqr = 0; // присвоение начального значения переменной номера строки
    int[] array = new int[matrix.GetLength(1)];
    int temp; // инициализация
    
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            array[j] = matrix[i, j];
        }
        
        temp = GetSumSqr1DimArr(array);
        if (temp < minSummSqrRow)
        {
            minSummSqrRow = temp;
            rowMinSummSqr = i; // присвоение номера текущей строки
        }
    }
}

Console.Clear();
Console.WriteLine();
int rows = SetNumber("- количество строк массива (< или > количества столбцов)");
int columns = SetNumber("- количество столбцов массива (не равное количеству строк)");
if (rows == columns)
{
    Console.WriteLine($"\n Количество строк = количеству столбцов. Данные некорректны.");
}
else
{
    int[,] result = GetMatrix(rows, columns);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Исходный (генерированный Random) массив:");
    PrintMatrix(result);
    Console.WriteLine();

    int minSummSqrRow; // присвоение начального значения
    int rowMinSummSqr; // присвоение начального значения
    SortRowsIncr2DimMatr(result, out minSummSqrRow, out rowMinSummSqr);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"\n Наименьшую сумму квадратов элементов (Sum = {minSummSqrRow})" +
                      $" имеет строка массива под индексом j = {rowMinSummSqr}.");
    Console.WriteLine();    
}

// Задержка экрана
Console.ForegroundColor = ConsoleColor.White;
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();