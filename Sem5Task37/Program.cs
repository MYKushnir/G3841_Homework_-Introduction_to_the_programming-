/*
Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
[3 7 22 2 78] -> 76
* Отсортируйте массив методом вставки и методом подсчета, а затем найдите разницу между первым и 
последним элементом. Для задачи со звездочкой использовать заполнение массива целыми числами.
*/

int arrayLenght = TakeIntData("Введите длинну массива: "); // спрашиваем у пользователя длинну массива

while (arrayLenght <= 0) // проверяем корректность ввода
{
    arrayLenght = TakeIntData("\n\rДлинна массива должна быть строго больше 0!\n\rВведите длинну массива: ");
}

double[] arr = new double[arrayLenght];
arr=GenRandArray(arrayLenght,0,50);
PrintArray(arr);

Console.WriteLine("\n\rРазность между max и min: " + (FindMax(arr) - FindMin(arr)));



int TakeIntData(string msg) //метод считывающий целое из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return int.Parse(Console.ReadLine() ?? "0");
}

double[] GenRandArray(int arrayLenght, int leftBorder, int rightBorder) // метод генерирующий массив случайных значений заданной длинны и в заданных пределах
{
    Random rnd = new Random(); // инициализируем генератор случайных чисел
    int i = 0; // переменная-счетчик
    double[] result = new double[arrayLenght]; // массив для заполнения

    while (i < arrayLenght)
    {
        result[i] = rnd.Next(leftBorder, rightBorder); // присваиваем i-тому элементу случайное значение в заданном пределе
        i++; // переходим к следующему элементу
    }

    return result; // возвращаем результат
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

double FindMin(double[] inArray) // метод поиска минимума 
{
    int arrayLength = inArray.Length; // переменная содержащая длину массива, чтоб не высчитывать её много раз
    double min = inArray[0]; // присваиваем к min значение 0го элемента
    for (int i = 1; i < arrayLength; i++) // цикл начинаем с 1го элемента
    {
        if (inArray[i] < min) min = inArray[i]; // если i-й элемент больше, то запоминаем его как минимальный
    }
    return min; // возвращаем результат
}

double FindMax(double[] inArray) // метод поиска максимума
{
    int arrayLength = inArray.Length; // переменная содержащая длину массива, чтоб не высчитывать её много раз
    double max = inArray[0]; // присваиваем к max значение 0го элемента
    for (int i = 1; i < arrayLength; i++) // цикл начинаем с 1го элемента
    {
        if (inArray[i] > max) max = inArray[i]; // если i-й элемент больше, то запоминаем его как максимальный
    }
    return max; // возвращаем результат
}


