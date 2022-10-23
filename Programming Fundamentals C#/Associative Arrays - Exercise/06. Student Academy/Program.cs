using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);


            }

            foreach (var student in students)
            {
                string studentName = student.Key;
                double studentAvrGrade = student.Value.Average();

                if (studentAvrGrade >= 4.50)
                {
                    Console.WriteLine($"{studentName} -> {studentAvrGrade:f2}");
                }
            }

        }
    }
}
