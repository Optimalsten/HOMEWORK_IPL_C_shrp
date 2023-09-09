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
      // Введите свое решение ниже
      // контроль на 5-значность заданного числа и обращение к методу DefPalndr
      bool resIns = false;
      if (number < 10000 || number > 99999)
      {
        System.Console.WriteLine("Число не пятизначное");
      }
      else
      {
        resIns = DefPalndr(number);
      }
      return resIns;
    }
    private static bool DefPalndr(int number)
    // определение палиндромности 5-значного числа
    {
        // выделение из числа цифр по разрядам в массив,
        int[] nW = new int[5];
        int digNum = 1;
        // заполнение массива цифр исходного числа (0-вой - единицы, 1-ый - десятки...)
        for (int i = 0; i < 5; i++)
        {
            nW[i] = (number / digNum) % 10;
            digNum = digNum * 10;
        }
        // формирование обратного числа
        int retNum = 0;
        for (int i = 0; i < 5; i++)
        {
            digNum = digNum / 10;
            retNum = retNum + nW[i] * digNum;
        }
        // сравнение исходного и обратного числа, вывод (возврат bool- переменной)
        if (number == retNum)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }
 
  // Не удаляйте и не меняйте метод Main! 
      static public void Main(string[] args) {
        int number;

        if (args.Length >= 1) {
            number = int.Parse(args[0]);
        } else {
           // Здесь вы можете поменять значения для отправки кода на Выполнение
            number = 234322;
        }

        // Не удаляйте строки ниже
        bool result = IsPalindrome(number);
        System.Console.WriteLine($"{result}");
    }
}