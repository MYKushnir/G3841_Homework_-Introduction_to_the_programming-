/*
Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
* Найдите площадь треугольника образованного пересечением 3 прямых
*/

// Забираем коэффиценты для уравнений прямых
Console.WriteLine("Прямые задаются уравнением: y = kx + b");
double[] line1 = TakeLine(1);
double[] line2 = TakeLine(2);
double[] line3 = TakeLine(3);

// Находим точки пересечения прямых:
double[] a = CrossPoint(line1, line2);
double[] b = CrossPoint(line1, line3);
double[] c = CrossPoint(line2, line3);

// Выводим координаты точек пересечения округляя до 3го знака:
Console.WriteLine("\n\r Вершины треугольника найдем как точки пересечения прямых:");
Console.WriteLine("Точка А: (" + Math.Round(a[0], 3) + ", " + Math.Round(a[1], 3) + ")");
Console.WriteLine("Точка B: (" + Math.Round(b[0], 3) + ", " + Math.Round(b[1], 3) + ")");
Console.WriteLine("Точка C: (" + Math.Round(c[0], 3) + ", " + Math.Round(c[1], 3) + ")");

// подсчитываем площадь и выводим её:
double area = Math.Abs(((b[0] - a[0]) * (c[1] - a[1]) - (c[0] - a[0]) * (b[1] - a[1])) / 2);
Console.WriteLine("\n\rПлощадь треугольника: " + Math.Round(area, 3));


double[] TakeLine(int num) // метод формирующий массив коэффицентов для уравнения прямой
{
    double[] result = new double[2]; // инициализируем массив
    result[0] = TakeDoubleData($"Введите k{num}:"); // заполняем коэффициент k
    result[1] = TakeDoubleData($"Введите b{num}:"); // заполняем коэффициент b
    return result; // возвращаем массив
}

double TakeDoubleData(string msg) //метод считывающий вещественное число из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return Convert.ToDouble(Console.ReadLine() ?? "0");
}

double[] CrossPoint(double[] line1, double[] line2) // метод для нахождения точки пересечения двух прямых
{
    double[] result = new double[2]; // инициализируем массив для координат точки
    result[0] = (line2[1] - line1[1]) / (line1[0] - line2[0]); // расчитываем x координату точки пересечения
    result[1] = line2[0] * result[0] - line2[1]; // рассчитываем y координату точки пересечения
    return result; // возвращаем результат
}

