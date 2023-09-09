// Задача 23: Напишите программу, которая
// принимает на вход число (N)
// и выдаёт таблицу кубов чисел от 1 до N.
// 3 -> 1, 4, 9.
// 5 -> 1, 8, 27, 64, 125.

using System;

public class Answer
{
    // static void ShowCube(int N)
    // {
    //     // Введите свое решение ниже
    //     int numN = 1;
    //     while (numN <= N)
    //     {
    //         Console.WriteLine(numN * numN * numN);
    //         numN++;
    //     }
    // }
    static void ShowCube(int N)
    {
        for (int i = 1; i <= N; i++)
        {
            Console.WriteLine(Cube(i));
        }
    }

    public static int Cube(int number)
    {
        return number * number * number;
    }

    // Не удаляйте и не меняйте метод Main! 
    static public void Main(string[] args)
    {
        int N;

        if (args.Length >= 1)
        {
            N = int.Parse(args[0]);
        }
        else
        {
            // Здесь вы можете поменять значения для отправки кода на Выполнение
            N = 6;
        }

        // Не удаляйте строки ниже
        ShowCube(N);
    }
}