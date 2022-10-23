using System;
using System.Collections.Generic;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Students> students = new List<Students>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "end")
                {
                    break;
                }

                Students student = new Students
                {
                    FirstName = commands[0],
                    LastName = commands[1],
                    Age = int.Parse(commands[2]),
                    Hometown = commands[3],
                };

                students.Add(student);

            }

            string cityName = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.Hometown == cityName)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }

        }
    }

    class Students
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }


    }
}
