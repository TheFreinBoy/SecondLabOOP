using System;
using Name;
using System.Text;

public class FractionTester
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        Fraction f1 = InputFraction("першого");
        Fraction f2 = InputFraction("другого");

        Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
        Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
        Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
        Console.WriteLine($"{f1} / {f2} = {f1 / f2}");

        Console.WriteLine($"Рядкове представлення з цілою частиною {f1} = {f1.ToStringWithIntegerPart()}");
        Console.WriteLine($"Дійсне значення {f1} = {f1.ToDouble()}");

        Console.Write("Введіть значення для обчислення CalcExpr1: ");
        long number1 = long.Parse(Console.ReadLine());
        Console.WriteLine($"Результат CalcExpr1({number1}): {Fraction.CalculateExpression1(number1)}");

        Console.Write("Введіть значення для обчислення CalcExpr2: ");
        long number2 = long.Parse(Console.ReadLine());
        Console.WriteLine($"Результат CalcExpr2({number2}): {Fraction.CalculateExpression2(number2)}");
    }

    private static Fraction InputFraction(string order)
    {
        Console.Write($"Введіть чисельник {order} дробу: ");
        long numerator = long.Parse(Console.ReadLine());

        Console.Write($"Введіть знаменник {order} дробу: ");
        long denominator = long.Parse(Console.ReadLine());

        return new Fraction(numerator, denominator);
    }
}