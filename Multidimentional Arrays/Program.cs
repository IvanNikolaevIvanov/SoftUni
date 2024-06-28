
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        static void GetSumOfDiagonals()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int leftRightSum = 0;
            int rightLeftSum = 0;

            for (int i = 0, j = size - 1; i < size; i++, j--)
            {
                leftRightSum += matrix[i, i];
                rightLeftSum += matrix[j, i];
            }

            Console.WriteLine(Math.Abs(leftRightSum - rightLeftSum));
        }

        static void PrintElementsOfMatrix()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] symbols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (IsValidCommand(dimensions, tokens))
                {
                    string tempValue = matrix[int.Parse(tokens[1]), int.Parse(tokens[2])];
                    matrix[int.Parse(tokens[1]), int.Parse(tokens[2])] = matrix[int.Parse(tokens[3]), int.Parse(tokens[4])];
                    matrix[int.Parse(tokens[3]), int.Parse(tokens[4])] = tempValue;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        PrintElementsOfMatrix();
    }

    private static void PrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }
            Console.WriteLine();
        }
    }

    private static bool IsValidCommand(int[] dimensions, string[] tokens)
    {
        return
            tokens[0] == "swap"
            && tokens.Length == 5
            && int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < dimensions[0]
            && int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < dimensions[1]
            && int.Parse(tokens[3]) >= 0 && int.Parse(tokens[3]) < dimensions[0]
            && int.Parse(tokens[4]) >= 0 && int.Parse(tokens[4]) < dimensions[1];
    }
}