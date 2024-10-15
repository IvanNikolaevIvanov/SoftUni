//List<Action> actions = new List<Action>();
//for (int i = 0; i < 10; i++)
//{
//    actions.Add(() => Console.WriteLine(i));
//}
//foreach (var a in actions)
//{
//    a();
//}

//Console.WriteLine();


using System.Collections;

static int ExpressionEvaluation(string mathExp)
{
    int result = 0;
    var firstNum = 0;
    char symbol;


    var input = mathExp
        .ToLower()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    var commandsList = new List<string>();

    foreach (var element in input)
    {
        commandsList.Add(element);
    }


    var numbers = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };

    var operators = new List<string> { "add", "plus", "subtract", "minus", "less" };

    if (!numbers.Contains(commandsList[0])
            || !numbers.Contains(commandsList[commandsList.Count - 1]))
    {
        return 0;
    }

    for (int i = 0; i < commandsList.Count; i++)
    {
        if (i % 2 == 0)
        {
            if (!numbers.Contains(commandsList[i]))
            {
                return 0;
            }
        }
        else if (i % 2 != 0)
        {
            if (!operators.Contains(commandsList[i]))
            {
                return 0;
            }
        }
    }

    while (commandsList.Count > 0)
    {


        if (numbers.Contains(commandsList[0]))
        {
            firstNum = TurnWordIntoNumber(commandsList[0]);
            result += firstNum;

            commandsList.RemoveAt(0);
        }
        else if (operators.Contains(commandsList[0]))
        {
            symbol = TurnWordIntoOpration(commandsList[0]);

            if (symbol == '+')
            {
                result += TurnWordIntoNumber(commandsList[1]);
            }
            else if (symbol == '-')
            {
                result -= TurnWordIntoNumber(commandsList[1]);
            }

            commandsList.RemoveAt(0);
            commandsList.RemoveAt(0);
        }

        continue;
    }

    return result;


}



static char TurnWordIntoOpration(string v)
{
    switch (v)
    {
        case "add":
            return '+';
        case "plus":
            return '+';
        case "subtract":
            return '-';
        case "minus":
            return '-';
        case "less":
            return '-';
        default: return '!';
    }
}

static int TurnWordIntoNumber(string value)
{
    switch (value)
    {
        case "zero":
            return 0;

        case "one":
            return 1;

        case "two":
            return 2;

        case "three":
            return 3;

        case "four":
            return 4;

        case "five":
            return 5;

        case "six":
            return 6;

        case "seven":
            return 7;

        case "eight":
            return 8;

        case "nine":
            return 9;

        case "ten":
            return 10;

        default: return 0;
    }
}


Console.WriteLine(ExpressionEvaluation("one plus two minus three plus four subtract one add seven less two"));