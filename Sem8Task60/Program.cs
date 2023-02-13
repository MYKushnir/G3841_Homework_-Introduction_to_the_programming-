/*
Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
*/

// спрашиваем у пользователя сведения для массива
int n = TakeIntData("Введите размерность по первому измерению массива: ");
int m = TakeIntData("Введите размерность по второму измерению массива: ");
int o = TakeIntData("Введите размерность по третьему измерению массива: ");

// проверяем возможность заполнения массива различными двухзначными числами:
if ((n * m * o) > 90) Console.WriteLine("Массив указанной размерности невозможно заполнить неповторяющимися двухзначными числами!");
else
{
    int[,,] array = Gen3DArray(n, m, o); // генерируем массив
    Console.WriteLine("\n\r Сгенерированный массив:");
    Print3DArrayWithIndex(array); // выводим результат
}


int TakeIntData(string msg) //метод считывающий целое из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return int.Parse(Console.ReadLine() ?? "0");
}

int[,,] Gen3DArray(int n, int m, int o) // метод генерирующий трехмерный массив, заполняя его различными двухзначными числами
{
    int[,,] result = new int[n, m, o];
    Random rnd = new Random(); // инициализируем генератор случайных чисел
    int num = rnd.Next(10, 99); // генерируем первое значение

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            for (int k = 0; k < o; k++)
            {
                while (IsIn3DArray(result, num)) // проверяем есть ли сгенерированное значение в массиве
                {
                    num = rnd.Next(10, 99); // генерируем следующее значение
                }

                result[i, j, k] = num; // записываем полученный элемент
                num = rnd.Next(10, 99); // генерируем следующее значение
            }
        }
    }
    return result;
}

bool IsIn3DArray(int[,,] array, int num) // метод проверяющий наличие числа в трехмерном массиве
{
    int n = array.GetLength(0);
    int m = array.GetLength(1);
    int o = array.GetLength(2);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            for (int k = 0; k < o; k++)
            {
                if (array[i, j, k] == num) return true; // если число найдено - возвращаем true 
            }
        }
    }
    return false; // возвращаем false
}

void Print3DArrayWithIndex(int[,,] array) // метод выводящий элементы трехмерного массива с их индексами
{
    // получаем сведения о массиве
    int n = array.GetLength(0);
    int m = array.GetLength(1);
    int o = array.GetLength(2);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            for (int k = 0; k < o; k++)
            {
                Console.Write($"{array[i, j, k]} ({i}, {j}, {k})  "); // выводим элемент массива и его координаты
            }
            Console.WriteLine(""); // закрываем строку
        }
    }
}