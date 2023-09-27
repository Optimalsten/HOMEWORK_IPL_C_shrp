// Задача 58: Задайте две матрицы.
// Напишите программу, которая будет
// находить произведение двух матриц.

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

// МЕТОД 4 - Умножение Матрицы 1 (rows1 x cols1rows2) на Матрицу 2 (cols1rows2 x rows2 )
int[,] MatrixMultiplic(int[,] matrix1, int [,] matrix2)
{
    int[,] resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    int sumTemp = 0;
    int kSumEl = matrix1.GetLength(1); // кол-во слагаемых при опред.каждого элемента
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            sumTemp = 0;
            for (int k = 0; k < kSumEl; k++)
            {
                sumTemp += matrix1[i,k] * matrix2[k,j];
            }
            resultMatrix[i,j] = sumTemp;
        }
    }
    return resultMatrix;
}

Console.Clear();
Console.WriteLine();
int rows1 = SetNumber("- количество строк первой матрицы");
int cols1rows2 = SetNumber("\t- количество столбцов первой матрицы \n\t\t (= количеству строк второй матрицы)");
int columns2 = SetNumber("- количество столбцов второй матрицы");

Console.ForegroundColor = ConsoleColor.Green;
int[,] result1 = GetMatrix(rows1, cols1rows2);
Console.WriteLine(" 1-ая (генерированная Random) матрица размером" +
                 $" ({rows1} x {cols1rows2}) :");
PrintMatrix(result1);

int[,] result2 = GetMatrix(cols1rows2, columns2);
Console.WriteLine(" умножается на 2-ую (генерированную Random) матрицу размером" +
                 $" ({cols1rows2} x {columns2}) :");
PrintMatrix(result2);

Console.ForegroundColor = ConsoleColor.Yellow;
int[,] resultMultiplic = MatrixMultiplic(result1, result2);
Console.WriteLine(" Результатом умножения будет матрица размером" +
                 $" ({rows1} x {columns2}) :");
PrintMatrix(resultMultiplic);
Console.WriteLine();

// Задержка экрана
Console.ForegroundColor = ConsoleColor.White;
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();