/*
На вход программы подаются три целых положительных числа. 
Определить, является ли это сторонами треугольника. 
Если да, то вывести всю информацию по нему - площадь, периметр, 
значения углов треугольника в градусах, является ли он прямоугольным, равнобедренным, равносторонним.
*/

// спрашиваем пользователя длинны отрезков: 
double len1 = TakeDoubleData("Введите длинну 1-го отрезка: ");
double len2 = TakeDoubleData("Введите длинну 2-го отрезка: ");
double len3 = TakeDoubleData("Введите длинну 3-го отрезка: ");

if (IsTriangle(len1, len2, len3)) // проверяем являются ли отрезки сторонами треугольника
{
    // описываем тип треугольника используя методы:
    Console.Write("\n\rВведенные отрезки являются сторонами");
    if (IsEquilateral(len1, len2, len3)) Console.Write(" равностороннего");
    if (IsIsosceles(len1, len2, len3)) Console.Write(" равнобедренного");
    if (IsRectangular(len1, len2, len3)) Console.Write(" прямоугольного");
    Console.WriteLine(" треугольника.");

    // выводим информацию о периметре и площади треугольника:
    Console.WriteLine("\n\rПериметр треугольника = " + Math.Round(Perimeter(len1, len2, len3), 3));
    Console.WriteLine("\n\rПлощадь треугольника = " + Math.Round(TriangleArea(len1, len2, len3), 3));

    // вычисляем углы и выводм их в консоль:
    double[] angles = TriangleAngles(len1, len2, len3);
    Console.WriteLine($"\n\rУглы треугольника:\n\ralpha = {Math.Round(angles[0], 3)}\n\rbeta = {Math.Round(angles[1], 3)}\n\rgamma = {Math.Round(angles[2], 3)}");

}
else Console.WriteLine("Данные отрезки не являются сторонами треугольника!");



double TakeDoubleData(string msg) //метод считывающий вещественное число из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return Convert.ToDouble(Console.ReadLine() ?? "0");
}

bool IsTriangle(double len1, double len2, double len3) // метод проверяющий являются ли отрезки сторонами треугольника
{
    // Если сумма любых двух длинн сторон больше длинны третьей стороны, то это стороны треугольника:
    if (len1 + len2 > len3 && len1 + len3 > len2 && len2 + len3 > len1) return true;
    return false;
}

bool IsIsosceles(double len1, double len2, double len3) // метод проверки на равнобедренность
{
    // если две стороны равны между собой, но не равны третьей, то треугольник равнобедренный
    if ((len1 == len2 && len1 != len3) || (len1 == len3 && len1 != len2) || (len3 == len2 && len3 != len1)) return true;
    return false;
}

bool IsEquilateral(double len1, double len2, double len3) // метод проверки на равностороннесть
{
    // если все стороны равны между собой то треугольник равносторонний
    if (len1 == len2 && len1 == len3) return true;
    return false;
}

bool IsRectangular(double len1, double len2, double len3) // метод проверки на прямоугольность
{
    // Если выполняется теорема пифагора, то треугольник прямоугольный
    if (Math.Pow(len1, 2) + Math.Pow(len2, 2) == Math.Pow(len3, 2) || Math.Pow(len1, 2) + Math.Pow(len3, 2) == Math.Pow(len2, 2) || Math.Pow(len2, 2) + Math.Pow(len3, 2) == Math.Pow(len1, 2)) return true;
    return false;
}

double Perimeter(double len1, double len2, double len3) // метод расчета периметра
{
    return len1 + len2 + len3; // возвращаем сумму длинн сторон
}

double TriangleArea(double len1, double len2, double len3) // метод расчета площади по формуле Герона
{
    double p = Perimeter(len1, len2, len3) / 2; // расчитываем полупериметр
    return Math.Sqrt(p * (p - len1) * (p - len2) * (p - len3));
}

double[] TriangleAngles(double len1, double len2, double len3) // метод для нахождения углов в треугольнике
{
    double[] angles = new double[3]; // массив содержащий углы треугольника
    // Решаем треугольник по 3м сторонам:
    angles[0] = Math.Acos((Math.Pow(len2, 2) + Math.Pow(len3, 2) - Math.Pow(len1, 2)) / (2 * len2 * len3));
    angles[0] = angles[0] * 180 / Math.PI; // перевод из радиан в градусы
    angles[1] = Math.Acos((Math.Pow(len1, 2) + Math.Pow(len3, 2) - Math.Pow(len2, 2)) / (2 * len1 * len3));
    angles[1] = angles[1] * 180 / Math.PI; // перевод из радиан в градусы
    angles[2] = 180 - angles[0] - angles[1];

    return angles;

}