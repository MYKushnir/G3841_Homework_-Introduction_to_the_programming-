/*
Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
* Ввести с клавиатуры длину массива и диапазон значений элементов
*/

// спрашиваем у пользователя параметры массива
int arrayLenght = TakeIntData("Введите длинну массива: ");
int leftBorder = TakeIntData("Введите нижний предел значений для генерации элементов массива: ");
int rightBorder = TakeIntData("Введите верхний предел значений для генерации элементов массива: ");

// проверяем корректность введенных пределов
while (leftBorder >= rightBorder)
{
    leftBorder = TakeIntData("\n\rНижний предел должен быть строго меньше верхнего!\n\rВведите нижний предел значений для генерации элементов массива: ");
    rightBorder = TakeIntData("Введите верхний предел значений для генерации элементов массива: ");
}


PrintArray(GenRandArray(arrayLenght, leftBorder, rightBorder)); // генерируем и выводим массив в консоль


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