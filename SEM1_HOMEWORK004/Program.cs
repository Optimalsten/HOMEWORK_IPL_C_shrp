// Задача 8: Напишите программу, которая на вход принимает число (N),
// а на выходе показывает все чётные числа от 1 до N.
// 5 -> 2, 4
// 8 -> 2, 4, 6, 8

Console.WriteLine("\nЗадайте целое положительное число (N) \n- для вывода всех четных чисел от 1 до N.");
Console.Write("\nВведите число: ");

string strNum = Console.ReadLine();
int num = int.Parse(strNum);

if (num < 1)
{
    Console.WriteLine("\nВы задали некорректное число = " + num + ",\nкоторое меньше 1.");
}
else
{
    int num0 = 1;

    while (num0 <= num)
    {
        if (num0 % 2 == 0)
        {
            Console.Write($"{num0}, ");
        }
        num0++;
    }
}

Console.Write("\nДля продолжения нажмите любую клавишу..."); //  "\n - "возврат каретки"
Console.Read(); // Задержка экрана
