/*
Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
* Дополнительно вывести среднее арифметическое по диагоналям и диагональ выделить разным цветом.
*/

// собираем данные от пользователя:
int m = TakeIntData("Введите количество строк матрицы: ");
int n = TakeIntData("Введите количество солбцов матрицы: ");
int leftBorder = TakeIntData("Введите минимум для заполнения матрицы: ");
int rightBorder = TakeIntData("Введите максимум для заполнения матрицы: ");
int rounder = TakeIntData("Введите количество знаков после запятой: ");
int numInMax = (int)Math.Log10(rightBorder) + 2 + rounder; // подсчитываем количество символов в самом длинном элементе матрицы 

double[,] matrix = GenDoubleMatrix(m, n, leftBorder, rightBorder, rounder); // генерируем матрицу по параметрам

DrawMatrix(matrix, numInMax); // рисуем матрицу

// выводим результат подсчета средних арифметических:
Console.WriteLine("\n\rСреднее арифметическое по столбцам:");
PrintArray(CountColumnsAverage(matrix));

double[] averageDiagonal = CountDiagonalAverage(matrix);
Console.WriteLine("Среднее арифметическое на главной диагонали:" + averageDiagonal[0]);
Console.WriteLine("Среднее арифметическое на побочной диагонали:" + averageDiagonal[1]);



int TakeIntData(string msg) //метод считывающий целое из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return int.Parse(Console.ReadLine() ?? "0");
}

double[,] GenDoubleMatrix(int m, int n, double leftBorder, double rightBorder, int rounder) // генерируем матрицу дробными случайными числами в заданном диапазоне с заданной точностью
{
    double[,] matrix = new double[m, n]; // инициализируем двумерный массив
    Random rnd = new Random(); // инициализируем генератор случайных чисел
    int i = 0; // счетчики для цикла
    int j = 0;

    while (i < m)
    {
        while (j < n)
        {
            matrix[i, j] = Math.Round((rnd.NextDouble() * (rightBorder - leftBorder) + leftBorder), rounder); // записываем в массив случайное число в заданных пределах округляя до нужного кол-ва знаков
            j++;
        }
        j = 0;
        i++;
    }
    return matrix; // возвращаем результат
}

void DrawMatrix(double[,] matrix, int numInMax) // метод рисующий красивую матрицу в таблице
{
    int i = 1; // счетчик начинаем с 1, т.к. 0ю строку обрабатываем до цикла в связи с необходимостью
               // рисовать верхнюю линию таблицы, отличную от средних

    int numStr = matrix.GetLength(0); // получаем количество строк

    string str = MakeTableString(matrix, 0, numInMax, '\u2551'); // формируем строку таблицы с границами ячеек
    Console.WriteLine(MakeTableLine(str, '\u2554', '\u2550', '\u2566', '\u2557', '\u2551')); // рисуем верхнюю линию таблицы
    Console.WriteLine(str);

    while (i < numStr) // цикл по строкам матрицы
    {
        str = MakeTableString(matrix, i, numInMax, '\u2551'); // формируем i-ю строку таблицы с границами ячеек
        Console.WriteLine(MakeTableLine(str, '\u2560', '\u2550', '\u256C', '\u2563', '\u2551')); // рисуем среднюю линию таблицы
        Console.WriteLine(str);
        i++;
    }

    Console.WriteLine(MakeTableLine(str, '\u255A', '\u2550', '\u2569', '\u255D', '\u2551')); // рисуем нижнюю границу таблицы
}

string MakeTableString(double[,] matrix, int strNum, int numInMax, char border) // метод собирающий строку таблицы с боковыми границами ячеек
{
    string str = ""; // инициалиизируем строку
    str = str + border; // рисуем левую границу
    int n = matrix.GetLength(1); // получаем количество столбцов
    int j = 0; // счетчик для цикла

    while (j < n) // цикл по колонкам строки матрицы
    {
        str = str + ((Convert.ToString(matrix[strNum, j])).PadRight(numInMax)) + "\u2551";  // записываем в строку очередной элемент, 
                                                                                            //дописываем нужное количество пробелов и рисуем правую границу      
        j++;
    }
    return str; // возвращаем результат

}

string MakeTableLine(string sampleStr, char left, char midUsual, char midCros, char right, char whereCross) // метод формирующий линию таблицы
{
    /*
        sampleStr - пример на основании которого формируется линия
        char left - первый символ строки
        midUsual - горизонтальная линия
        midCros - горизонтальная линия с перекрестиями для границы ячеек
        right - правый символ строки
        whereCross - символ в строке-примере на основании которого принимается решение о необходимости перекрестия
    */

    string str = ""; // инициализируем строку
    str = str + left; // записываем в нее левый символ
    int sampleLen = sampleStr.Length - 1; // считаем длинну строки-примера вычитаем единицу, т.к. цикл нужен до предпоследнего элемента
    int i = 1; // цикл начинаем с 1 т.к. 0й элемент уже записан

    while (i < sampleLen)
    {
        if (sampleStr[i] == whereCross) str = str + midCros; // если в строке с примером попадается вертикальная линия, то рисуем линию с перекрестием
        else str = str + midUsual; // иначе рисуем горизонтальную линию
        i++;
    }
    str = str + right; //рисуем правый символ строки
    return str;
}

double[] CountColumnsAverage(double[,] matrix) // расчет среднего арифметического по столбцам
{
    // расчитываем размер матрицы, инициализируем массив для записи ответа:
    int m = matrix.GetLength(0);
    int n = matrix.GetLength(1);
    double[] average = new double[n];
    int i = 0;
    int j = 0;

    while (j < n) // цикл по массиву, внешний по столбцам, внутренний по строкам
    {
        while (i < m)
        {
            average[j] = average[j] + matrix[i, j]; // накапливаем сумму
            i++;
        }
        average[j] = Math.Round((average[j] / m), 4); // делим накопленную сумму на кол-во элементов
        i = 0;
        j++;
    }
    return average;
}

double[] CountDiagonalAverage(double[,] matrix)
{
    // расчитываем размер матрицы, инициализируем массив для записи ответа:
    int m = matrix.GetLength(0);
    int n = matrix.GetLength(1);
    double[] average = new double[2];
    int i = 0;
    int j = 0;

    while (i < m) // цикл по массиву
    {
        while (j < n)
        {
            if (i == j) average[0] = average[0] + matrix[i, j]; // если элемент на главной диагонали
            if (j == (n - 1 - i)) average[1] = average[1] + matrix[i, j]; // если элемент на побочной диагонали
            j++;
        }
        j = 0;
        i++;
    }
    // делим накопленные суммы на кол-во элементов:
    average[0] = Math.Round(average[0] / Math.Min(m, n), 4);
    average[1] = Math.Round(average[1] / Math.Min(m, n), 4);
    return average;

}

void PrintArray(double[] inArray)// метод выводящий одномерный массив на экран
{
    int i = 1; // переменная счетчик
    int arrayLength = inArray.Length; // переменная содержащая длину массива, чтоб не высчитывать её много раз 

    if (arrayLength != 0) Console.Write("[\"" + inArray[0]); // если массив не пустой, то выводим 0-й элемент с элементами оформления вывода
    else Console.Write("["); // иначе выводим только открывющуюся скобку

    while (i < arrayLength)
    {
        Console.Write("\",\"" + inArray[i]); // выводим i-й элемент массива
        i++;
    }

    if (arrayLength != 0) Console.WriteLine("\"]"); // если массив не пустой, то закрываем кавычку и квадратную скобку
    else Console.WriteLine("]"); // иначе только закрываем скобку
}