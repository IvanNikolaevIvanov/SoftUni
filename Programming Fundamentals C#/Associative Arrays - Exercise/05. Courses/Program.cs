using System;
using System.Collections.Generic;

namespace _05._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "end")
                {
                    break;
                }

                string course = commands[0];
                string name = commands[1];

                if (!courses.ContainsKey(course))
                {                    
                    courses.Add(course, new List<string>());
                    
                }
                courses[course].Add(name);


            }

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {courses[item.Key].Count}");

                foreach (var name in item.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
