/*
Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
* Отсортировать массив методом пузырька
*/

int arrayLenght = TakeIntData("Введите длинну массива: "); // спрашиваем у пользователя длинну массива

while (arrayLenght <= 0) // проверяем корректность ввода
{
    arrayLenght = TakeIntData("\n\rДлинна массива должна быть строго больше 0!\n\rВведите длинну массива: ");
}

int[] result = GenRandArray(arrayLenght, 100, 999);  // генерируем нужный массив
Console.WriteLine("\n\rСгенерированный массив:"); // выводим сгенерированный массив...
PrintArray(result);
Console.WriteLine("Количество четных чисел: " + CountEven(result)); // ...и количество четных чисел в нем

BubleSort(result); // сортируем массив...
Console.WriteLine("\n\rОтсортированный массив:"); // .. и выводим его
PrintArray(result);



int TakeIntData(string msg) //метод считывающий целое из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return int.Parse(Console.ReadLine() ?? "0");
}

int[] GenRandArray(int arrayLenght, int leftBorder, int rightBorder) // метод генерирующий массив случайных значений заданной длинны и в заданных пределах
{
    Random rnd = new Random(); // инициализируем генератор случайных чисел
    int i = 0; // переменная-счетчик
    int[] result = new int[arrayLenght]; // массив для заполнения

    while (i < arrayLenght)
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

void BubleSort(int[] inArray) // метод сортировки пузырьком
{
    int memory = 0; // переменная память для перестановки элементов местами
    int arrayLength = inArray.Length; // переменная содержащая длину массива, чтоб не высчитывать её много раз

    for (int i = 0; i < arrayLenght; i++) // начинаем "внешний" цикл
    {
        for (int j = i + 1; j < arrayLenght; j++) // цикл перебора оставшихся элементов массива, для сравнения значения с элементом под номером, заданным "внешним" циклом
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

int CountEven(int[] inArray) // метод подсчета количества четных элементов массива
{
    int arrayLength = inArray.Length; // переменная содержащая длину массива, чтоб не высчитывать её много раз
    int counter = 0; // количество четных элементов

    for (int i = 0; i < arrayLength; i++) // цикл по массиву
    {
        if (inArray[i] % 2 == 0) counter++; // если остаток от целочисленного деления на 2=0, то плюсуем счетчик четных чисел
    }
    return counter; // возвращаем значение счетчика
}