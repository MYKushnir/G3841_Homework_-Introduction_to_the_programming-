/*
Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
*/

// запрашиваем интервал у пользователя
int m = TakeIntData("Введите число M: "); 
int n = TakeIntData("Введите число N: ");

Console.WriteLine($"Сумма целых чисел в заданном промежутке = {SummFromMtoN(m,n)}"); // выводим результат


int TakeIntData(string msg) //метод считывающий целое из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return int.Parse(Console.ReadLine() ?? "0");
}

int SummFromMtoN(int m, int n) // метод суммирующий целые числа от m до n
{
    if (m <= n) return (m+SummFromMtoN(m+1,n));   // если m<=n то прибавляем следующее цело число через рекурсию   
    else return 0; // выход из рекурсии
}