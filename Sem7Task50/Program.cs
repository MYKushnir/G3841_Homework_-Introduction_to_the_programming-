/*
Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
* Заполнить числами Фиббоначи и выделить цветом найденную цифру
*/

// собираем данные от пользователя:
int m = TakeIntData("Введите количество строк матрицы: ");
int n = TakeIntData("Введите количество солбцов матрицы: ");

double[,] matrix = GenFibonachiMatrix(m, n); // заполняем матрицу числами Фибоначи

int lenMax = (int)Math.Log10(matrix[m - 1, n - 1]) + 1; // Расчитываем количество символов в самом большом элементе для вывода красивой матрицы

Console.WriteLine("\n\rМатрица заполненная числами Фибоначи:");  // выводим результат
DrawMatrix(matrix, lenMax);

double findMe = TakeDoubleData("\n\rВведите число для поиска: "); // спрашиваем число для поиска

if (IsInMatrix(matrix, findMe)) DrawMatrixMarkElement(matrix, lenMax, findMe, 12); // отмечаем требуемые элементы в матрице, либо сообщаем, что такого числа нет
else Console.WriteLine("Данный элемент отсутствует в матрице");



double TakeDoubleData(string msg) //метод считывающий вещественное число из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    // return int.Parse(Console.ReadLine() ?? "0");
    return Convert.ToDouble(Console.ReadLine() ?? "0");
}

int TakeIntData(string msg) //метод считывающий целое из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return int.Parse(Console.ReadLine() ?? "0");
}

double[,] GenFibonachiMatrix(int m, int n) // генерируем матрицу с целыми случайными числами в заданном диапазоне с заданной точностью
{
    double[,] matrix = new double[m, n]; // инициализируем двумерный массив    
    int i = 0; // счетчики для цикла
    int j = 2;
    matrix[0, 0] = 0;
    matrix[0, 1] = 1;
    double numBeforePrevious = 0;
    double numPrevious = 1;

    while (i < m)
    {
        while (j < n)
        {
            matrix[i, j] = numPrevious + numBeforePrevious; // записываем в массив случайное число в заданных пределах округляя до нужного кол-ва знаков
            numBeforePrevious = numPrevious;
            numPrevious = matrix[i, j];
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
    //PrintRainbowString(str, " \u2551"); // печатаем сформированную строку
    Console.WriteLine(str);

    while (i < numStr) // цикл по строкам матрицы
    {
        str = MakeTableString(matrix, i, numInMax, '\u2551'); // формируем i-ю строку таблицы с границами ячеек
        Console.WriteLine(MakeTableLine(str, '\u2560', '\u2550', '\u256C', '\u2563', '\u2551')); // рисуем среднюю линию таблицы
        //PrintRainbowString(str, " \u2551"); // печатаем очередную строку матрицы с границами ячеек 
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

bool IsInMatrix(double[,] matrix, double FindMe) // метод отвечающий на вопрос есть ли заданный элемент в матрице
{
    // счетчики для цикла:
    int i = 0;
    int j = 0;
    // получаем размерность матрицы:
    int m = matrix.GetLength(0);
    int n = matrix.GetLength(1);

    while (i < m)
    {
        while (j < n)
        {
            if (matrix[i, j] == FindMe) return true; // если элемнт найден возвращаем true
            j++;
        }
        j = 0;
        i++;
    }
    return false; // возвращаем false
}

void DrawMatrixMarkElement(double[,] matrix, int numInMax, double findMe, int color) // метод рисующий красивую матрицу в таблице и выделяет нужный элемент заданным цветом
{
    int i = 1; // счетчик начинаем с 1, т.к. 0ю строку обрабатываем до цикла в связи с необходимостью
               // рисовать верхнюю линию таблицы, отличную от средних

    int numStr = matrix.GetLength(0); // получаем количество строк

    string str = MakeTableString(matrix, 0, numInMax, '\u2551'); // формируем строку таблицы с границами ячеек
    Console.WriteLine(MakeTableLine(str, '\u2554', '\u2550', '\u2566', '\u2557', '\u2551')); // рисуем верхнюю линию таблицы
    string splitter = ("\u2551" + Convert.ToString(findMe)).PadRight(numInMax + 1) + "\u2551"; // формируем строку по которой будем производить разбиение (элемент для выделения цветом)
    PrintStringWithMark(str, splitter, color); // печатаем строку, помечая цветом нужные элементы


    while (i < numStr) // цикл по строкам матрицы
    {
        str = MakeTableString(matrix, i, numInMax, '\u2551'); // формируем i-ю строку таблицы с границами ячеек
        Console.WriteLine(MakeTableLine(str, '\u2560', '\u2550', '\u256C', '\u2563', '\u2551')); // рисуем среднюю линию таблицы
        PrintStringWithMark(str, splitter, color); // печатаем строку, помечая цветом нужные элементы       
        i++;
    }

    Console.WriteLine(MakeTableLine(str, '\u255A', '\u2550', '\u2569', '\u255D', '\u2551')); // рисуем нижнюю границу таблицы
}

void PrintStringWithMark(string str, string findMe, int color) // метод печатающий строку с выделением нужного элемента
{
    string[] parts = str.Split(findMe);   // разбиваем строку на части используя интересующий элемент
    int partsSize = parts.Length;  // получаем количество элементов в массиве аолученном от разбиения 
    int i = 0;

    while (i < partsSize - 1) // цикл до предпоследнего элемента т.к. внутри цикла нельзя завершать ввод строки
    {
        Console.Write(parts[i]); // печатаем очередной элемент массива
        Console.ForegroundColor = (ConsoleColor)color; // меняем цвет вывода
        Console.Write(findMe); // печатаем выделяемый элемент
        Console.ResetColor(); // возвращаем цвет вывода в исходный
        i++;
    }
    Console.WriteLine(parts[i]); // завершаем вывод строки

    // ToDo: Метод помечает все элементы равные заданному, но не отрабатывает случай когда два элемента, которые нужно выделить, идут друг за другом.

}

