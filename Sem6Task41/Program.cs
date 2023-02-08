﻿/*
 Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3
* Пользователь вводит число нажатий, затем программа следит за нажатиями с клавиатуры и выдает сколько чисел больше 0 было введено.
*/

int keysAmount = TakeIntData("Введите количество нажатий: "); // забираем инфомацию о количестве нажатий
int i = 0; // переменная - счетчик
ConsoleKeyInfo key; // переменная для считывания нажатой клавиши
string str = ""; // строка в которую записывается результат нажатий клавиш

Console.Clear(); // очищаем консоль...
Console.WriteLine("Вводите числа, разделяя их пробелами:"); //... и записываем в неё что мы ждем от пользователя

while (i < keysAmount) // цикл пока пользователь не нажмет нужное количество клавиш
{
    key = Console.ReadKey(true); // считываем нажатую клавишу, не выводя нажатие в консоль
    Console.Clear(); // очищаем консоль...
    Console.WriteLine("Вводите числа, разделяя их пробелами:"); // ...и восстанавливаем её структуру
    str = str + key.KeyChar; // дописываем в строку символ нажатой клавиши
    Console.WriteLine(str); // выводим получившуюся строку
    Console.WriteLine("Количество чисел больше 0: " + CountAboveZero(str)); // считаем числа больше 0 и выводим информацию об этом
    i++;
}


int TakeIntData(string msg) //метод считывающий целое из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return int.Parse(Console.ReadLine() ?? "0");
}

int CountAboveZero(string str) // Метод считающий количество чисел в строке больше 0
{
    string[] parts = str.Split(" ", StringSplitOptions.RemoveEmptyEntries); // разбиваем строку по пробелу
    int partsAmount = parts.Length; // вычисляем длинну полученного массива
    int val = 0; // переменная для преобразования string в int в случае успеха
    int result = 0; // результат работы метода
    int i = 0; // переменная - счетчик

    while (i < partsAmount) // цикл внутри массива полученного от разбиения строки
    {
        if (int.TryParse(parts[i], out val)) // пробуем преобразовать элемент массива в целое число, если получилось
        {                                      // то запоминаем значение в переменную val
            if (val > 0) result++;    // если число больше нуля, то увеличиваем result на 1
        }
        i++;
    }

    return result; // возвращаем результат
}