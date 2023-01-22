//Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
//A (3,6,8); B (2,1,-7), -> 15.84
//* Сделать метод загрузки точек

int[] points={0,0,0,0,0,0}; // инициализируем массив, в который будем считывать координаты
TakePoints(points); // считываем координаты

Console.WriteLine("Расстояние между точками = "+Math.Sqrt(Math.Pow(points[0]-points[3],2)+Math.Pow(points[1]-points[4],2)+Math.Pow(points[2]-points[5],2))); // вывод результата



void TakePoints (int[] array){ // Метод забирающий координаты точек из консоли
    Console.Write("Введите координаты точек:"); // выводим сообщение пользователю
    string inData=Console.ReadLine()??"A (0,0,0); B(0,0,0)"; // читаем введенные данные
    int position = 0; // номер символа, который считывается в данный момент
    
    array[0]=int.Parse(dataBetween('(', ',' ,inData, ref position)); //получаем координату X точки A
    array[1]=int.Parse(dataBetween(',', ',' ,inData, ref position)); //получаем координату Y точки A
    array[2]=int.Parse(dataBetween(',', ')' ,inData, ref position)); //получаем координату Z точки A
    array[3]=int.Parse(dataBetween('(', ',' ,inData, ref position)); //получаем координату X точки B
    array[4]=int.Parse(dataBetween(',', ',' ,inData, ref position)); //получаем координату Y точки B
    array[5]=int.Parse(dataBetween(',', ')' ,inData, ref position)); //получаем координату Z точки B 

}


// метод возвращающий содержимое строки между заданными символами, начиная с указанного номера символа:
string dataBetween (char leftBorder, char rightBorder, string inData, ref int startPosition){ 

    string? result=""; // результат работы метода
    int numStart=startPosition; // номер символа левой границы

    while (numStart<=inData.Length-1 && inData[numStart]!=leftBorder){ // ищем символ левой границы и его номер, выходим когда нашли, либо дошли до конца
        numStart++;
    }

    int numFinish=numStart+1; // номер символа правой границы, задаем его как следующий за левой границей

    while (numFinish<=inData.Length-1 && inData[numFinish]!=rightBorder){ // ищем символ правой границы и его номер, выходим когда нашли, либо дошли до конца
        numFinish++;
    }

    int i=numStart+1; // переменная-счетчик для сбора результата

    while(i<numFinish){ // Собираем в результат символы между граничными
        result=result+inData[i];
        i++;
    }
    startPosition=numFinish; // меняем значение переменной, переданной по указателю, чтоб сообщить номер правой границы
    return result; // возвращаем содержимое строки между граничными символами
}