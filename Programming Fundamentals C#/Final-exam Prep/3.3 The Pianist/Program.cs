using System;
using System.Collections.Generic;

namespace _3._3_The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var pieces = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                string piece = input[0];
                string composer = input[1];
                string key = input[2];

                pieces.Add(piece, new List<string> { composer, key });            

            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Stop")
                {
                    break;
                }

                string command = commands[0];
                string piece = commands[1];

                if (command == "Add")
                {
                    
                    string comp = commands[2];
                    string key = commands[3];
                    
                    
                    if (!pieces.ContainsKey(piece))
                    {
                        pieces.Add(piece, new List<string> { comp, key });
                        Console.WriteLine($"{piece} by {comp} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }

                if (command == "Remove")
                {

                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);

                        Console.WriteLine($"Successfully removed {piece}!");

                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }

                }


                if (command == "ChangeKey")
                {
                    string newKey = commands[2];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece][1] = newKey;

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }

                }
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }

            
        }
    }
}
