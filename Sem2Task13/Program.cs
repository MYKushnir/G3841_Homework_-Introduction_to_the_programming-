﻿// Напишите программу, которая выводит третью цифру
// заданного числа или сообщает, что третьей цифры нет.
int num = TakeData ("Введите число:");

if (num<100) {Console.WriteLine("У введенного числа нет третьей цифры!");}
else{
    int numOfDigits=(int)Math.Log10(num) + 1; // вычисляем количество цифр в числе через логарифм
    num=num/(int)Math.Pow(10,numOfDigits-3);  // "отрезаем" последние цифры от числа, оставив первые три
    Console.WriteLine("Третья цифра введенного числа: "+(num%10)); // Выводим результат как остаток от целочисленного деления на 10
}



int TakeData (string msg) { //метод считывающий целое число из консоли, выводя в неё сообщение
    Console.Write(msg);
    return int.Parse(Console.ReadLine()??"0");
}