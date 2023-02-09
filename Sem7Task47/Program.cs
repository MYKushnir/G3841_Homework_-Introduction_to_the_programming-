/*
Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
* При выводе матрицы показывать каждую цифру разного цвета(цветов всего 16)
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
    PrintRainbowString(str, " \u2551"); // печатаем сформированную строку

    while (i < numStr) // цикл по строкам матрицы
    {
        str = MakeTableString(matrix, i, numInMax, '\u2551'); // формируем i-ю строку таблицы с границами ячеек
        Console.WriteLine(MakeTableLine(str, '\u2560', '\u2550', '\u256C', '\u2563', '\u2551')); // рисуем среднюю линию таблицы
        PrintRainbowString(str, " \u2551"); // печатаем очередную строку матрицы с границами ячеек        
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

void PrintRainbowString(string str, string exclusion) // метод выводящий в консоль переданную строку меняя цвет каждого символа на случайный,
                                                      // кроме символов перечисленных в строке exclusion
{
    Random rnd = new Random(); // инициализируем генератор случайных чисел
    int len = str.Length; // получаем длинну строки
    int i = 0;

    while (i < len)
    {
        if (IsInString(exclusion, str[i])) // если i-й символ содердится в строке исключений 
        {
            Console.ResetColor(); //изменяем цвет вывода на дефолтный
            if (i < len - 1) Console.Write(str[i]); // если печатаем не последний символ строки, то дописываем в терминал символ
            else Console.WriteLine(str[i]);    // иначе завершаем вывод строки в терминале        
        }
        else
        {
            Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 14); // генерируем случайный цвет вывода тескста
            if (i < len - 1) Console.Write(str[i]); // если печатаем не последний символ строки, то дописываем в терминал символ
            else Console.WriteLine(str[i]);  // иначе завершаем вывод строки в терминале  
        }
        i++;
    }
    Console.ResetColor(); //изменяем цвет вывода на дефолтный
}

bool IsInString(string sampleString, char symbol) // метод проверяющий наличие символа в строке
{
    int i = 0;
    int len = sampleString.Length; // получаемс длинну строки

    while (i < len)
    {
        if (sampleString[i] == symbol) return true; // если i-й элемент строки совпадает с символом для поиска, то возвращаем true
        i++;
    }
    return false; // возвращаем false
}