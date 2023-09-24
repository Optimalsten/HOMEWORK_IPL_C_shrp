// Задача 52: Задайте двумерный массив из целых чисел.
// Найдите среднее арифметическое элементов в каждом
// столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое
// каждого столбца: 4,6; 5,6; 3,6; 3.

// Метод PrintArray должен выводить на экран
// сгенерированную методом CreateIncreasingMatrix матрицу.
void PrintArray(int[,] matrix)
{
    // Введите свое решение ниже
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int l = 0; l < matrix.GetLength(1); l++)
        {
            Console.Write($"{matrix[i, l]}\t");
            // Console.Write($"{matrix[i, l]}"+"\t");
        }
        Console.WriteLine();
    }
}

// Метод CreateIncreasingMatrix должен создавать матрицу заданной размерности,
// с каждым новым элементом увеличивающимся на опрделенное число.
// Метод принимает на вход три числа (n - количество строк матрицы, m - количество столбцов матрицы,
// k - число, на которое увеличивается каждый новый элемент)
// и возвращает матрицу, удовлетворяющую этим условиям.
int[,] CreateIncreasingMatrix(int n, int m, int k)
{
    // Введите свое решение ниже
    int[,] matrix = new int[n, m];
    int k0 = 1;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            matrix[i, j] = k0;
            k0 += k;
        }
    }
    return matrix;
}

// Метод PrintListAvr принимает одномерный массив,
// возвращенный методом FindAverageInColumns
// и выводит этот список на экран в формате
// "The averages in columns are: x.x0 x.x0 x.x0 ...",
// где x.x0 - это значения средних значений столбцов,
// округленные до двух знаков после запятой, разделенные знаком табуляции.
void PrintListAvr(double[] list)
{
    // Введите свое решение ниже
    Console.WriteLine("The averages in columns are: ");
    for (int l = 0; l < list.Length; l++)
    {
        Console.Write($"{list[l]:f2}\t");
        // Console.Write($"{list[l]: f2}"+"\t");
    }
    Console.WriteLine();
}

// Метод FindAverageInColumns принимает целочисленную матрицу типа int[,]
// и возвращает одномерный массив типа double.
// Этот метод вычисляет среднее значение чисел в каждом столбце матрицы
// и сохраняет результаты в виде списка.
double[] FindAverageInColumns(int[,] matrix)
{
    // Введите свое решение ниже
    double[] averInCol = new double[matrix.GetLength(1)];
    double sumTemp;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        sumTemp = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sumTemp += matrix[i, j];
        }
        averInCol[j] = Math.Round((sumTemp / matrix.GetLength(0)), 2);
    }
    return averInCol;
}

// Здесь вы можете поменять значения для отправки кода на Выполнение
int n, m, k;
n = 4;
m = 5;
k = 3;
// Не удаляйте строки ниже
//
int[,] result = CreateIncreasingMatrix(n, m, k);
//
PrintArray(result);
//
PrintListAvr(FindAverageInColumns(result));
