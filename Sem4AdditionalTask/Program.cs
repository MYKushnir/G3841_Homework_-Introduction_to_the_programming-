/*
Дополнительно: Написать программу которая из имен через запятую выберет случайное имя
и выведет в терминал
 Игорь, Антон, Сергей -> Антон 
Подсказка: Для разбора строки использовать метод string.split(). Для выбора случайного имени метод Random.Next(1,<длина массива имен>+1).
*/

string str = TakeData("Введите список имен через запятую: "); // считываем список имен из консоли в строковую переменную
Console.WriteLine(WhooBuyBeer(str));


string TakeData(string msg) //метод считывающий данные из консоли, выводя в неё сообщение
{
    Console.Write(msg);
    return Console.ReadLine() ?? "0";
}

string WhooBuyBeer(string names) // метод решающий "вечный" вопрос =)
{
    names = names.Replace(", ", ","); // удаляем пробелы после запятых, чтоб не выводилось два пробела в результате, после "вводной" фразы    
    string[] parts = str.Split(',', StringSplitOptions.RemoveEmptyEntries); // разбиваем полученную строку по запятым и записываем их в массив parts
    Random rnd = new Random(); // инициализируем генератор случайных чисел
    int randNum = rnd.Next(0, (parts.Length - 1)); // выбираем счастливчика    
    string result = ("За Клинским пойдет " + parts[randNum] + "!"); // собираем результат работы метода
    return result;
}
