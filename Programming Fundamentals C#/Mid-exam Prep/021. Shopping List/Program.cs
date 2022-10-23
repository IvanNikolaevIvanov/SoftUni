using System;
using System.Linq;

namespace _021._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commands[0] == "Go" )
                {
                    break;
                }

                string item = commands[1];
                string command = commands[0];

                if (command == "Urgent")
                {
                    
                    
                    if (!list.Contains(item))
                    {
                        list.Insert(0, item);
                    }
                    
                }
                else if (command == "Unnecessary")
                {
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                    }
                }
                else if (command == "Correct")
                {
                    string newItem = commands[2];
                    
                    int currentIndex = 0;

                    if (list.Contains(item))
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] == item)
                            {
                                currentIndex = i;
                            }
                        }

                        list.RemoveAt(currentIndex);
                        list.Insert(currentIndex, newItem);
                    }
                }
                else if (command == "Rearrange")
                {
                    string currItem = item;
                    
                    if (list.Contains(item))
                    {                        
                        list.Remove(item);
                        list.Add(currItem);
                    }


                }

            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
