/*
Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
*/

// запрашиваем числа у пользователя
double m = TakeDoubleData("Введите число M: ");
double n = TakeDoubleData("Введите число N: ");

Console.WriteLine($"Функция Аккермана A({m},{n}) = {Ackerman(m, n)}"); // выводим результат


double TakeDoubleData(string msg) //метод считывающий целое из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return Convert.ToDouble(Console.ReadLine() ?? "0");
}

double Ackerman(double m, double n) // расчет значения функции Акермана
{
    if (m == 0) return n + 1;
    else
      if ((m != 0) && (n == 0)) return Ackerman(m - 1, 1);
    else
        return Ackerman(m - 1, Ackerman(m, n - 1));
}