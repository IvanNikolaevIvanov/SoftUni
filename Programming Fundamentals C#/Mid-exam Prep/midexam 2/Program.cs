using System;
using System.Linq;

namespace midexam_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commands[0] == "Include")
                {
                    list.Add(commands[1]);
                }
                if (commands[0] == "Remove")
                {
                    string firstOrLast = commands[1];
                    int numToRemove = int.Parse(commands[2]);
                    

                    if (numToRemove > 0 && numToRemove <= list.Count - 1)
                    {
                        if (firstOrLast == "first")
                        {
                            for (int j = 0 ; j < numToRemove ; j++)
                            {
                                list.RemoveAt(0);
                                
                            }
                        }
                        else if (firstOrLast == "last")
                        {


                            for (int l = numToRemove; l > 0; l--)
                            {
                                list.RemoveAt(list.Count - 1);
                            }


                        }

                    }
                }
                if (commands[0] == "Prefer")
                {
                    int firstCoffeeIndex = int.Parse(commands[1]);
                    int secondCoffeeIndex = int.Parse(commands[2]);
                    
                    if (firstCoffeeIndex >= 0 && firstCoffeeIndex <= list.Count - 1 && secondCoffeeIndex >= 0 && secondCoffeeIndex <= list.Count - 1 && firstCoffeeIndex != secondCoffeeIndex)
                    {
                        string firstCoffee = list[firstCoffeeIndex];
                        string secondCoffee = list[secondCoffeeIndex];

                        list.RemoveAt(firstCoffeeIndex);
                        list.Insert(firstCoffeeIndex, secondCoffee);
                        list.RemoveAt(secondCoffeeIndex);
                        list.Insert(secondCoffeeIndex, firstCoffee);

                    }

                }
                if (commands[0] == "Reverse")
                {

                    list.Reverse();

                }

            }

            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
