using System.Text;

string input = Console.ReadLine();
// abv>1>1>2>2asdasd

string result = "";

int power = 0;

for (int i = 0; i < input.Length; i++)
{
    char currentSymbol = input[i];

    if (currentSymbol == '>')
    {
        power += int.Parse(input[i + 1].ToString());

        result += currentSymbol;
    }
    else if (power == 0)
    {
        result += currentSymbol;
    }
    else
    {
        power--;
    }
}

Console.WriteLine(result);

