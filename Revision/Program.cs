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


// static bool Comparison(string StringA, string StringB)
//{
//    var isAnagram = false;

//    var firstString = StringA.ToLower();
//    var secondString = StringB.ToLower();

//    if (StringA.Length != StringB.Length)
//    {
//        return false;
//    }

//    for (int i = 0; i < firstString.Length; i++)
//    {
//        var firstStringSymbol = StringA[i];

//        for (int j = 0; j < secondString.Length; j++)
//        {
//            var secondStringSymbol = secondString[j];

//            if (firstStringSymbol == secondStringSymbol)
//            {
//                isAnagram = true;
//            }
//        }

//    }

//    return isAnagram;
// }
