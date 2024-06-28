

Func<decimal, decimal, decimal> sum = (x, y) => x + y; 
Func<decimal, decimal, decimal> subtract = (x, y) => x - y; 
Func<decimal, decimal, decimal> multiply = (x, y) => x * y; 
Func<decimal, decimal, decimal> divide = (x, y) => Math.Round((x / y), 9);

Console.WriteLine(Calculator(5, 6, sum));
Console.WriteLine(Calculator(5, 6, subtract));
Console.WriteLine(Calculator(5, 6, multiply));
Console.WriteLine(Calculator(5, 6, divide));



static decimal Calculator(decimal a, decimal b, Func<decimal, decimal, decimal> operation)
{
    return operation(a, b);
}