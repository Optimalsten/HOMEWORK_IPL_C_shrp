// Задача 21: Напишите программу, которая
// принимает на вход координаты двух точек
// и находит расстояние между ними в 3D пространстве.
// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

int GetNumber(string message)
{
    Console.Write($"Введите координату {message}: ");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}

Console.WriteLine("\nВведите координаты двух точек (X, Y, Z)" +
"\nдля определения растояния между ними в 3-хмерном пространстве.\n");
int numX1 = GetNumber("X (для 1-ой точки)");
int numY1 = GetNumber("Y (для 1-ой точки)");
int numZ1 = GetNumber("Z (для 1-ой точки)");
int numX2 = GetNumber("X (для 2-ой точки)");
int numY2 = GetNumber("Y (для 2-ой точки)");
int numZ2 = GetNumber("Z (для 2-ой точки)");

double numX = Math.Pow((numX2 - numX1), 2);
double numY = Math.Pow((numY2 - numY1), 2);
double numZ = Math.Pow((numZ2 - numZ1), 2);

double result = Math.Sqrt(numX + numY + numZ);

Console.WriteLine($"\nРезультат равен {result:F2}.");

// Задержка экрана
Console.WriteLine("\nДля продолжения нажмите любую клавишу..."); //  "\n - "возврат каретки"
Console.Read();

