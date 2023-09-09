// Задача 19: Напишите программу, которая
// принимает на вход пятизначное число и проверяет,
// является ли оно палиндромом.

// Внутри класса Answer напишите метод IsPalindrome,
// который принимает на вход пятизначное число number и проверяет, является ли оно палиндромом.
// Метод должен проверить является ли число пятизначным,
// в противном случае - вывести Число не пятизначное и False в следующей строке.
// Для остальных чисел вернуть True или False.
// 14212 -> False
// 12821 -> True
// 234322 -> Число не пятизначное
//                      False
using System;

public class Answer
{
    static bool IsPalindrome(int number){
        if (number < 10000 || number >= 100000){
            Console.WriteLine("Число не пятизначное");
            return false;
        }
        // СУПЕР - ПОЛУЧЕНИЕ "ОБРАТНОГО" ЧИСЛА (независимо от количества разрядов) !!!
        int reverse = 0;
        int temp = number;
        while (temp > 0){
            reverse = reverse * 10 + temp % 10;
            temp /= 10;
        }
        return reverse == number;
    }

      static public void Main(string[] args) {
        int number;

        if (args.Length >= 1) {
            number = int.Parse(args[0]);
        } else {
            number = 13731;
        }

        bool result = IsPalindrome(number);
        System.Console.WriteLine($"{result}");
    }
}
