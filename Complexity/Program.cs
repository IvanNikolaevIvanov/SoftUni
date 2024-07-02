using System.Diagnostics;

int n = 100_000_000;

Measure(Constant, 1_000_000_000, "Constant time O(1)");
Measure(Linear, 1_000_000_00, "Linear time O(n)");
Measure(Quadratic, 10_000, "Quadratic time O(n^2)");
Measure(Exponential, 28, "Exponential time O(2^n)");
Measure(Factorial, 10, "Factorial time O(n!)");


static void Constant(int n) 
{
    int x = 5*n;
}

static void Logarithmic(int n)
{
    
}

static void Linear(int n)
{
    int counter = 0;

    for (int i = 0; i < n; i++)
    {
        counter++;
    }
}

static void Quadratic(int n)
{
    int counter = 0;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            counter++;
        }
    }
}

static void Exponential(int n)
{
    if (n == 0)
    {
        return;
    }

    Exponential(n - 1);
    Exponential(n - 1);
}

static void Factorial(int n)
{
    if (n == 0)
    {
        return;
    }

    for (int i = 0; i < n; i++)
    {
        Factorial(n - 1);
    }
}

static void Measure(Action<int> action, int n, string name)
{
    Stopwatch watch = new Stopwatch();
    watch.Start();
    action(n);
    watch.Stop();
    Console.WriteLine($"{name} N={n} --> {watch.ElapsedMilliseconds}");
}