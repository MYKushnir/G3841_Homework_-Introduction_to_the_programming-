// Ввод числа пользователем:
Console.WriteLine("Введите число:");
int num1 = int.Parse(Console.ReadLine()??"0");

if (num1%2==0) // если остаток от целочисленного деления числа на 2 = 0, то
{
    Console.WriteLine("Число чётное"); //выводим, что число чётное
}
else{
    Console.WriteLine("Число не чётное"); // иначе число не чётное
}