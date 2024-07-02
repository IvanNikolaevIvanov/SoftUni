
Print(10);


static void Print(int n)
{
    if (n == 0)
    {
        return;
    }

    Console.WriteLine($"{n} Before recursion");

    Print(n - 1);

    Console.WriteLine($"{n} After recursion");
}