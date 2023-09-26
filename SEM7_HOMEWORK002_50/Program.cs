// Задача 50: Напишите программу, которая на вход
// принимает позиции элемента в двумерном массиве, и
// возвращает значение этого элемента или же указание,
// что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 1 7 -> такого числа в массиве нет

// Метод PrintArray должен выводить на экран
// сгенерированную методом CreateIncreasingMatrix матрицу.
void PrintArray (int [,] matrix)
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
    int k0 = 1 - k;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            k0 += k;            
            matrix[i,j] = k0;
        }
    }
    return matrix;
}
  
// Метод FindNumberByPosition принимает на вход сгенрированную матрицу
// и числа x и y - позиции элемента в матрице.
// Если указанные координаты находятся за пределами границ массива,
// метод должен вернуть массив с нулевым значением.
// Если координаты находятся в пределах границ,
// метод должен вернуть массив с двумя значениями:
// значением числа в указанной позиции, а второй элемент должен быть равен 0,
// чтобы показать, что операция прошла успешно без ошибок.
int[] FindNumberByPosition (int [,] matrix, int rowPosition, int columnPosition)
{
    // Введите свое решение ниже
    int quantity;
    if ((rowPosition > matrix.GetLength(0)) || (columnPosition > matrix.GetLength(1)))
    {
        quantity = 1;
        // массив будет из одного элемента
    }
    else
    {
        quantity = 2;
        // массив будет из двух элементов
    }
    int[] arrResultFind = new int[quantity]; // массив будет из одного или двух элементов
    switch (quantity)
    {
        case 1:
            // arrResultFind[0] = 0; // можно не присваивать, т.к. изначально нулевое значение
            break;
        case 2:
            // т.к. X и Y - номера строк и столбцов Матрицы (матем.) и начинаются с единицы...
            arrResultFind[0] = matrix[rowPosition - 1, columnPosition - 1];
            // arrResultFind[1] = 0; // ПРИЗНАК УСПЕХА - можно не присваивать, т.к. изначально нулевое значение
            break;
        default: System.Console.WriteLine("error"); break;
    }
    return arrResultFind;
// РЕШЕНИЕ С ПЛОЩАДКИ - С ОШИБКОЙ (для х=1 и y=1 ответ будет неверный)
    // int [] number={0,-1};
    // if ((rowPosition-1) > 0 && (rowPosition-1)<=matrix.GetLength(0)
    //    && (columnPosition-1) > 0 && (columnPosition-1)<=matrix.GetLength(1) )
    // {
    //     number[1]=0;
    //     number[0]=matrix[rowPosition-1,columnPosition-1];
    //     return number;
    // }
    // return number;
}

// Метод PrintCheckIfError должен принимать результат метода FindNumberByPosition
// и числа x и y - позиции элемента в матрице.
// Метод должен проверить, был ли найден элемент в матрице по указанным координатам (x и y),
// используя результаты из метода FindNumberByPosition.
// Если такого элемента нет, вывести на экран "There is no such index".
// Если элемент есть, вывести на экран "The number in [{x}, {y}] is {значение}".

// РЕШЕНИЕ С ПЛОЩАДКИ - патерна? (указаны параметры метода X и Y - переменные с большой буквы)

void PrintCheckIfError (int[] results, int x, int y)
{
  // Введите свое решение ниже
    if (results.Length == 1)
    {
        Console.WriteLine("There is no such index");
    }
    else if ((results.Length == 2) && (results[1] == 0))
    {
        Console.WriteLine($"The number in [{x}, {y}] is {results[0]}");        
    }
    else
    {
        Console.WriteLine("Unknown situation");        
    }
}
// 
int n, m, k, x, y;
n = 4;
m = 5;
k = 3;
x = 1;
y = 1;
// 
// Не удаляйте строки ниже
// 
int[,] result = CreateIncreasingMatrix(n, m, k);
// 
PrintArray(result);
// 
PrintCheckIfError(FindNumberByPosition(result, x, y), x, y);
