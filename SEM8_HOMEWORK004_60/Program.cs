// Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить
// массив, добавляя индексы каждого элемента.

// МЕТОД 1 - ЗАДАНИЯ с клав-ы целого числа (без контроля допустимости типа значения)
using System.Diagnostics.Contracts;
using System.Globalization;

int SetNumber(string message)
{
    Console.Write($" Введите число {message}: \t");
    int num = Convert.ToInt32(Console.ReadLine());
    // Console.WriteLine();
    return num;
}

// МЕТОД 2 - ВЫВОД НА ЭКРАН значений 3-мерного массива целых чисел (с указанием индексов)
void PrintMatrix3(int[,,] matrix)
{
    for (int l = 0; l < matrix.GetLength(2); l++)
    {
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($" {matrix[i, j, l]}({i},{j},{l}) \t");
            }
            Console.WriteLine();
        }
    }
}

// МЕТОД 3 - ЗАДАНИЕ 3-мерного МАССИВА неповтор.2-значных целых чисел, ГСЧ в диап. [min, max]
int[,,] GetMatrix3(int rows, int columns, int depths, int min = 10, int max = 99)
{
    int[,,] matrix = new int[rows, columns, depths];
    Random rand = new Random();
    int temp = 0;
    bool controleRepead = false;
    for (int l = 0; l < matrix.GetLength(2); l++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                while (!controleRepead)
                {
                    temp = rand.Next(min, max + 1);
                    controleRepead = GetRepeadSearch(matrix, temp, i, j, l);
                }
                matrix[i, j, l] = temp;
                controleRepead = false;
            }
        }
    }
    return matrix;
}

// МЕТОД 4 - ПРОВЕРКА НА ПОВТОР нового числа в сгенерированной ранее части Массива
bool GetRepeadSearch(int[,,] arr, int newTemp, int iTemp, int jTemp, int lTemp)
{
    for (int l = 0; l < lTemp + 1; l++)
    {
        for (int i = 0; i < iTemp + 1; i++)
        {
            for (int j = 0; j < jTemp + 1; j++)
            {
                if (arr[i, j, l] == newTemp) return false;
            }
        }
    }
    return true;
}

Console.Clear();
Console.WriteLine();
Console.WriteLine(" Введите три числа (i, j, l) - размерность 3-хмерного Массива - так," +
                  $"\n чтобы произведение (i * j * l) было < 90, а каждое из значений" +
                  $"\n i (кол-во строк), j (кол-во столбцов), l (кол-во плоскостей) было > 2.");
Console.WriteLine();                  
int rows = SetNumber($"- количество строк массива (целое < 23)\t\t\t");
int columns = SetNumber($"- количество столбцов массива (целое < {90 / (rows * 2) + 1})\t\t");
int depths = SetNumber($"- количество плоскостей массива/'глубина' (целое < {90 / (rows*columns) +1})\t");
if (rows * columns * depths > 90 || rows < 2 || columns < 2 || depths < 2)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\n Заданные значения i, j, k некорректны.\n");
}
else
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    int[,,] result = GetMatrix3(rows, columns, depths);
    Console.WriteLine($"\n 3-ехмерный массив (сгенерированный Random) размером" +
                      $" ({rows} x {columns} x {depths}) :");
    PrintMatrix3(result);
}

// Задержка экрана
Console.ForegroundColor = ConsoleColor.White;
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();


