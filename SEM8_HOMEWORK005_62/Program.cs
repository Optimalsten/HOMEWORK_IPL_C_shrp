// Задача 62: Заполните спирально массив 4 на 4.
//     1   2   3   4
//     12  13  14  5
//     11  16  15  6
//     10  9   8   7

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

// МЕТОД 3 - ЗАДАНИЕ 2-мерного МАССИВА целых чисел, спиральное заполнение
int[,] GetMatrixSpir(int rows, int columns, int firstEl = 1, int stepEl = 1)
{
    int[,] matrix = new int[rows, columns];

    int iBegin = 0, iFinish = 0, jBegin = 0, jFinish = 0; // индексы - "для расчета координаты заполняемого прямоугольника"
    int iTemp = 0; // индекс строки текущего элемента массива
    int jTemp = 0; // индекс столбца текущего элемента массива
    int numbTemp = 1; // "порядковый" номер текущего элемента массива
    int valueTemp = firstEl; // величина, присаиваемая текущему элементу массива

    while (numbTemp <= rows * columns)
    {
        matrix[iTemp, jTemp] = valueTemp;
        if (iTemp == iBegin && jTemp < columns - jFinish -1) // если...
        {
            ++jTemp; //...идем вправо
        }
        else if ((jTemp == columns - jFinish -1) && (iTemp < rows - iFinish - 1)) // если...
        {
            ++iTemp; //...идем вниз
        }
        else if ((iTemp == rows - iFinish - 1) && (jTemp > jBegin)) // если...
        {
            --jTemp; //... идем влево
        }
        else  // иначе
        {
            --iTemp; //... идем вверх
        }

        if ((iTemp == iBegin + 1) && (jTemp == jBegin) && (jBegin != columns - jFinish - 1))
        {
            // прямоуг-к пройден, корректир.индексов - "для расчета координат следующего прямоуг-ка"
            ++iBegin;
            ++iFinish;
            ++jBegin;
            ++jFinish;
        }
        ++numbTemp; // определение "порядкового" номера следующего элемента массива
        valueTemp += stepEl; // определение величины следующего элемента массива
    }
    return matrix;
}

Console.Clear();
Console.WriteLine();
int rows = SetNumber("- количество строк");
int columns = SetNumber("- количество столбцов");
int firstEl = SetNumber("- значение элемента массива с индексами (0, 0)");
int stepEl = SetNumber("- значение 'шага' между элементами массива");

int[,] result = GetMatrixSpir(rows, columns, firstEl, stepEl);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\n Результат - массив размером ({rows} х {columns}):");
PrintMatrix(result);
Console.WriteLine();

// Задержка экрана
Console.ForegroundColor = ConsoleColor.White;
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();
