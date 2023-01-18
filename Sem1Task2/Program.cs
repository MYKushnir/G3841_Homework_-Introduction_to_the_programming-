// Ввод чисел пользователем:
Console.WriteLine("Введите первое число:");
int num1 = int.Parse(Console.ReadLine()??"0");
Console.WriteLine("Введите второе число:");
int num2 = int.Parse(Console.ReadLine()??"0");

if (num1>num2){ // случай когда первое число больше второго
    Console.WriteLine("Первое число больше второго ("+num1+" > "+num2+")"); 
}
else if (num2>num1) { //случай когда второе число больше первого
   Console.WriteLine("Второе число больше первого ("+num2+" > "+num1+")"); 
}

else { //случай когда числа равны
    Console.WriteLine("Первое число равно второму ("+num2+" = "+num1+")");
}