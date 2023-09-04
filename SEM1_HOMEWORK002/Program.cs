// Задача 4: Напишите программу, которая принимает на вход три числа
// и выдаёт максимальное из этих чисел.
// 2   3   7   -> 7
// 44  5   78  -> 78
// 22  3   9   -> 22

int Max(int arg1, int arg2, int arg3)
{
    int result = arg1;
    if (arg2 > result) result = arg2;
    if (arg3 > result) result = arg3;
    return result;
}

Console.WriteLine("\nЗадайте три целых числа для поиска максимального из них.");

Console.Write("\nВведите первое число: ");
string strNum = Console.ReadLine();
int num1 = int.Parse(strNum);

Console.Write("Введите второе число: ");
strNum = Console.ReadLine();
int num2 = int.Parse(strNum);

Console.Write("Введите третье число: ");
strNum = Console.ReadLine();
int num3 = int.Parse(strNum);






Console.Write("\nДля продолжения нажмите любую клавишу..."); //  "\n - "возврат каретки"
Console.Read(); // Задержка экрана