// Задача 54: Задайте двумерный массив.
// Напишите программу, которая упорядочит по убыванию
// элементы каждой строки двумерного массива.

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

// МЕТОД 4 - СОРТИРОВКА 1-мерного МАССИВА целых чисел методом выбора максимума
void SortChoice1DimArr(int[] array)
{
    for (int j = 0; j < array.Length; j++)
    {
        int indexMax = j;
        for (int k = j; k < array.Length; k++)
        {
            if (array[k] > array[indexMax])
                indexMax = k;
        }
        if (array[indexMax] == array[j])
            continue; // переход к следующей итерации цикла

        int temp = array[j];
        array[j] = array[indexMax];
        array[indexMax] = temp;
    }
}

// МЕТОД 5 - СОРТИРОВКА СТРОК 2-мерного МАССИВА целых чисел по возрастанию
void SortRowsIncr2DimMatr(int[,] matrix)
{
    int[] array = new int[matrix.GetLength(1)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            array[j] = matrix[i, j];
        }
        SortChoice1DimArr(array);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = array[j];
        }
    }
}
Console.Clear();
Console.WriteLine();
int rows = SetNumber("- количество строк");
int columns = SetNumber("- количество столбцов");

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

// Задержка экрана
Console.ForegroundColor = ConsoleColor.White;
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();
