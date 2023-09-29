// Задача 2: Напишите программу, которая на вход принимает два числа и выдаёт,
// какое число большее, а какое меньшее.
// a = 5;  b = 7   -> max = 7
// a = 2;  b = 10  -> max = 10
// a = -9; b = -3  -> max = -3

Console.WriteLine("\nЗадайте два целых числа для сравнения, какое число большее, а какое меньшее.");
Console.Write("\nВведите первое число: ");
string strNum = Console.ReadLine();
int num1 = int.Parse(strNum);

Console.Write("Введите второе число: ");
strNum = Console.ReadLine();
int num2 = int.Parse(strNum);

if (num1 > num2)
{
    Console.WriteLine("\nЧисло " + num1 + " больше, чем число " + num2 + ".\n" + "max = " + num1 + ".");
}
else if (num2 > num1)
{
    Console.WriteLine("Число " + num1 + " меньше, чем число " + num2 + ".\n" + "max = " + num2 + ".");
}
else
{
    Console.WriteLine("Число " + num1 + " равно числу " + num2 + ".\n" + "max = " + num1 + ".");
}
Console.Write("\nДля продолжения нажмите любую клавишу...");
Console.Read(); // Задержка экрана


// СОРТИРОВКА ИЗ ЛЕКЦИЙ
// void SelectMinSort(int[] array)
// {
//     for (int i = 0; i < array.Length - 1; i++)
//     {
//         int minPosition = i;
//         for (int j = i + 1; j < array.Length; j++)
//         {
//             if (array[j] < array[minPosition]) minPosition = j;
//         }
//         int temporary = array[i];
//         array[i] = array[minPosition];
//         array[minPosition] = temporary;
//     }
// }

// void SelectMaxSort(int[] array)
// {
//     for (int i = 0; i < array.Length - 1; i++)
//     {
//         int maxPosition = i;
//         for (int j = i + 1; j < array.Length; j++)
//         {
//             if (array[j] > array[maxPosition]) maxPosition = j;
//         }
//         int temporary = array[i];
//         array[i] = array[maxPosition];
//         array[maxPosition] = temporary;
//     }
// }
