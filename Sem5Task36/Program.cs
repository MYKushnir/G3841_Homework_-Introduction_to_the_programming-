/*
Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
* Найдите все пары в массиве и выведите пользователю
*/

int arrayLength = TakeIntData("Введите длинну массива: "); // спрашиваем у пользователя длинну массива

while (arrayLength <= 0) // проверяем корректность ввода
{
    arrayLength = TakeIntData("\n\rДлинна массива должна быть строго больше 0!\n\rВведите длинну массива: ");
}


int[] result = GenRandArray(arrayLength, 0, 50);  // генерируем нужный массив
Console.WriteLine("\n\rСгенерированный массив:"); // выводим сгенерированный массив...
PrintArray(result); // выводим сгенерированный массив
Console.WriteLine("Сумма элементов, стоящих на нечетных местах: " + SumOnOddPosition(result)); // выводим сумму элементов на нечетных местах

Console.WriteLine("Парные элементы окрашены в один цвет:"); // раскрашиваем парные элементы в один цвет и выводим массив
ColorisePairsInArray(result, FindPairPosition(result));

int TakeIntData(string msg) //метод считывающий целое из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return int.Parse(Console.ReadLine() ?? "0");
}

int[] GenRandArray(int arrayLength, int leftBorder, int rightBorder) // метод генерирующий массив случайных значений заданной длинны и в заданных пределах
{
    Random rnd = new Random(); // инициализируем генератор случайных чисел
    int i = 0; // переменная-счетчик
    int[] result = new int[arrayLength]; // массив для заполнения

    while (i < arrayLength)
    {
        result[i] = rnd.Next(leftBorder, rightBorder); // присваиваем i-тому элементу случайное значение в заданном пределе
        i++; // переходим к следующему элементу
    }

    return result; // возвращаем результат
}

void PrintArray(int[] inArray)// метод выводящий одномерный массив на экран
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

int SumOnOddPosition(int[] inArray) // метод подсчитывающий сумму элементов на нечетных местах
{
    int arrayLength = inArray.Length; // переменная содержащая длину массива, чтоб не высчитывать её много раз
    int summ = 0; // сумма элементов 

    for (int i = 0; i < arrayLength; i = i + 2) // цикл по массиву начинаем с 0го элемента, т.к. для пользователя это 1й нечетный элемент
    {
        summ = summ + inArray[i]; // добавляем к сумме значение iго элемента
    }
    return summ; // возвращаем значение счетчика
}

int[,] FindPairPosition(int[] inArray) // метод возвращающий массив с номерами парных элементов
{
    int[,] pairArray = new int[(inArray.GetLength(0) / 2), 2]; // массив-результат работы
    int pairAmount = 0; // количество найденных пар
    bool exitFlag = false; // флажок выхода из цикла
    int arrayLength = inArray.Length - 1; // переменная содержащая номер последнего элемента, чтоб не высчитывать её много раз
    int i = 0;
    int j = 0;


    //for (int i = 0; i < arrayLength-1; i++) // начинаем "внешний" цикл
    while (i < arrayLength - 1)
    {
        if (!IsInArray(pairArray, i, pairAmount))
        { // проверяем есть ли i-ый элемент массива среди пар            
            j = i + 1;
            //for (int j = i + 1; (j < arrayLength || !exitFlag); j++) 
            while (j < arrayLength && !exitFlag)// цикл перебора оставшихся элементов массива, для сравнения значения с элементом под номером, заданным "внешним" циклом
            {
                if (!IsInArray(pairArray, j, pairAmount))
                { // проверяем есть ли j-ый элемент массива среди пар
                    if (inArray[i] == inArray[j]) // если нашли пару
                    {
                        pairArray[pairAmount, 0] = i; // записываем номер первого числа пары
                        pairArray[pairAmount, 1] = j; // записываем номер второго числа пары                        
                        pairAmount++; // увеличиваем счетчик количества пар
                        exitFlag = true; // ставим флажок выхода из цикла, т.к. пара найдена и дальше просматривать массив не нужно
                    }
                }
                j++;
            }
            exitFlag = false; // опускаем флажок            
        }
        i++;
    }

    return (Resize2DArray(pairArray, pairAmount, 2)); // отрезаем пустые элементы у массива и возвращаем его
}

bool IsInArray(int[,] inArray, int num, int lim) // метод проверяет наличие числа в масиве, просматривая его до указанной строки
{
    int i = 0;
    int arrayLength = inArray.GetLength(0); // переменная содержащая длину массива, чтоб не высчитывать её много раз
    while (i < arrayLength && i < lim)// && i < arrayLength)
    {
        if (inArray[i, 0] == num || inArray[i, 1] == num) return true;
        i++;
    }
    return false;
}

int[,] Resize2DArray(int[,] original, int rows, int cols) // метод изменяющий длинну двумерного массива
{
    int[,] newArray = new int[rows, cols]; // инициализируем новый массив нужного размера
    int minRows = Math.Min(rows, original.GetLength(0)); // выясняем что меньше, количество строк новом или исходном массиве
    int minCols = Math.Min(cols, original.GetLength(1)); // выясняем что меньше, количество столбцов в новом или исходном массиве

    for (int i = 0; i < minRows; i++)
        for (int j = 0; j < minCols; j++)
            newArray[i, j] = original[i, j]; // переписываем элементы из оригинального массива в новый 
    return newArray;
}

void ColorisePairsInArray(int[] inArray, int[,] pairs) // метод выводящий массив, расскрашивая его элементы на основе матрицы пар
{
    int i = 0; // счетчик для цикла
    int arrayLength = inArray.Length;  // переменная содержащая длину массива, чтоб не высчитывать её много раз     
    int color = 1; // переменная содержащая текущий цвет символов
    Console.Write("["); // пишем в консоль первый сивол вывода

    while (i < arrayLength)
    {
        color = ColorNum(i, pairs); // расчитываем номер цвета для вывода очередного элемента на основании матрицы парных элеменнтов           
        Console.ForegroundColor = (ConsoleColor)color; //изменяем цвет вывода тескста
        Console.Write(inArray[i] + ","); // выводим значение элемента массива
        i++;
    }
    Console.ForegroundColor = (ConsoleColor)15; // возвращаем цвет к стандартному
    Console.WriteLine("]"); // закрываем вывод массива
}

int ColorNum(int num, int[,] pairs) // метод расчета цвета длдя вывода элемента
{
    int i = 0;
    int result = 15; // результат, по умолчанию 15 - белый цвет
    bool exitFlag = false; // флажок выхода из цикла
    int pairsLength = pairs.GetLength(0); // получаем количество строк в матрице пар

    while (i < pairsLength && !exitFlag) // просматриваем матрицу до конца либо пока не найдем элемент
    {
        if (num == pairs[i, 0] || num == pairs[i, 1])
        {
            result = (i + 1) - (i / 13) * 13; // номер цвета не может быть больше 15(белый), также нам неприемлим цвет 0 (черное на черном не видно)  
                                              // данная формула позволяет избежать генерацию "неправильных" цветов         
            exitFlag = true; // поднимаем флажок для выхода из цикла
        }
        i++;
    }
    return result;
}
