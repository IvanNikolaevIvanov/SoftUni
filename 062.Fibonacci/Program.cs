// 0, 1, 1, 2, 3, 5, 8, 13

int fibonacci = Fibonacci(7);
Console.WriteLine(fibonacci);

static int Fibonacci(int position)
{
	if (position == 0)
	{
		return 0;
	}
	if (position == 1)
	{
		return 1;
	}

	return Fibonacci(position - 1) + Fibonacci(position - 2);
}