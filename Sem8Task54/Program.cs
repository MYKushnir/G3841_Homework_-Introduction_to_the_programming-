/*
Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
*/

// собираем данные от пользователя:
int m = TakeIntData("Введите количество строк матрицы: ");
int n = TakeIntData("Введите количество солбцов матрицы: ");
int leftBorder = TakeIntData("Введите минимум для заполнения матрицы: ");
int rightBorder = TakeIntData("Введите максимум для заполнения матрицы: ");

// генерируем матрицу:
int[,] matrix = GenIntMatrix(m, n, leftBorder, rightBorder);

// выводим сгенерированную матрицу:
Console.WriteLine("\n\r Сгенерированная матрица:");
DrawMatrix(matrix, rightBorder);

// сортируем матрицу по строкам и выводим её
SortStringsInMatrix(matrix);
Console.WriteLine("\n\r Соритрованная по строкам матрица:");
DrawMatrix(matrix, rightBorder); // рисуем красивенько таблицей



int TakeIntData(string msg) //метод считывающий целое из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return int.Parse(Console.ReadLine() ?? "0");
}

int[,] GenIntMatrix(int m, int n, int leftBorder, int rightBorder) // генерируем матрицу с целыми случайными числами в заданном диапазоне
{
    int[,] matrix = new int[m, n]; // инициализируем двумерный массив
    Random rnd = new Random(); // инициализируем генератор случайных чисел
    int i = 0; // счетчики для цикла
    int j = 0;

    while (i < m)
    {
        while (j < n)
        {
            matrix[i, j] = rnd.Next(leftBorder, rightBorder); // записываем в массив случайное число
            j++;
        }
        j = 0;
        i++;
    }
    return matrix; // возвращаем результат
}

void DrawMatrix(int[,] matrix, int max) // метод рисующий красивую матрицу в таблице
{
    int i = 1; // счетчик начинаем с 1, т.к. 0ю строку обрабатываем до цикла в связи с необходимостью
               // рисовать верхнюю линию таблицы, отличную от средних

    int numStr = matrix.GetLength(0); // получаем количество строк

    string str = MakeTableString(matrix, 0, max, '\u2551'); // формируем строку таблицы с границами ячеек
    Console.WriteLine(MakeTableLine(str, '\u2554', '\u2550', '\u2566', '\u2557', '\u2551')); // рисуем верхнюю линию таблицы
    Console.WriteLine(str); // печатаем сформированную строку

    while (i < numStr) // цикл по строкам матрицы
    {
        str = MakeTableString(matrix, i, max, '\u2551'); // формируем i-ю строку таблицы с границами ячеек
        Console.WriteLine(MakeTableLine(str, '\u2560', '\u2550', '\u256C', '\u2563', '\u2551')); // рисуем среднюю линию таблицы
        Console.WriteLine(str); // печатаем очередную строку матрицы с границами ячеек
        i++;
    }

    Console.WriteLine(MakeTableLine(str, '\u255A', '\u2550', '\u2569', '\u255D', '\u2551')); // рисуем нижнюю границу таблицы
}

string MakeTableString(int[,] matrix, int strNum, int max, char border) // метод собирающий строку таблицы с боковыми границами ячеек
{
    string str = ""; // инициалиизируем строку
    str = str + border; // рисуем левую границу
    int numsInMax = (int)Math.Log10(max) + 1; // считаем количество цифр в макимальном элементе для организации выравнивания ячеек
    int n = matrix.GetLength(1); // вычисляем количество столбцов
    int j = 0; // счетчик для цикла

    while (j < n) // цикл по колонкам строки матрицы
    {
        str = str + ((Convert.ToString(matrix[strNum, j])).PadRight(numsInMax)) + "\u2551";  // записываем в строку очередной элемент, 
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
    int i = 1; // уикл начинаем с 1 т.к. 0й элемент уже записан

    while (i < sampleLen)
    {
        if (sampleStr[i] == whereCross) str = str + midCros; // если в строке с примером попадается вертикальная линия, то рисуем линию с перекрестием
        else str = str + midUsual; // иначе рисуем горизонтальную линию
        i++;
    }
    str = str + right; //рисуем правый символ строки
    return str;
}

void SortStringsInMatrix(int[,] matrix) // метод сортировки строк в матрице
{
    int n = matrix.GetLength(0); // получаем сведения о матрице
    int m = matrix.GetLength(1);
    int[] array = new int[m]; // инициализируем массив для записи строк
    int i = 0;
    int j = 0;

    while (i < n)
    {
        while (j < m) // переписываем строку матрицы в массив
        {
            array[j] = matrix[i, j];
            j++;
        }
        j = 0;
        BubleSort(array); // сортирум массив

        while (j < m) // переписываем из массива в матрицу
        {
            matrix[i, j] = array[j];
            j++;
        }
        i++;
        j = 0;
    }

}


void BubleSort(int[] inArray) // метод сортировки пузырьком
{
    int memory = 0; // переменная память для перестановки элементов местами
    int arrayLength = inArray.Length; // переменная содержащая длину массива, чтоб не высчитывать её много раз

    for (int i = 0; i < arrayLength; i++) // начинаем "внешний" цикл
    {
        for (int j = i + 1; j < arrayLength; j++) // цикл перебора оставшихся элементов массива, для сравнения значения с элементом под номером, заданным "внешним" циклом
        {
            if (inArray[j] > inArray[i]) // если рассматриваемый элемент больше элемента заданного "внешним" циклом, то меняем их местами
            {
                memory = inArray[i];
                inArray[i] = inArray[j];
                inArray[j] = memory;
            }
        }
    }
}