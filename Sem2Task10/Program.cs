﻿//Задача 10: Напишите программу, которая принимает на вход трёхзначное число 
//и на выходе показывает вторую цифру этого числа.

int num = TakeData("Введите трехзначное число: "); // читаем число из консоли 

while (num<100 || num>999){ // Проверяем является ли число трехзначным, если нет, то сообщаем об этом и просим ввести корректное число
    Console.WriteLine("Вы ввели не трехзначное значное число!");
    num = TakeData("Введите трехзначное число: ");
}

num=num/10; // "Отрезаем" последнюю цифру у числа
Console.WriteLine("Вторая цифра введенного числа: " + num%10); // Выводим результат как остаток от целочисленного деления на 10


int TakeData (string msg) { //метод считывающий целое число из консоли, выводя в неё сообщение
    Console.Write(msg);
    return int.Parse(Console.ReadLine()??"0");
}