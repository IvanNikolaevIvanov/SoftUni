using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> listOfStudents = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                Student student = new Student(input[0], input[1], input[2]);

                listOfStudents.Add(student);
            }

            List<Student> orderedList = listOfStudents
                .OrderByDescending(student => student.Grade).ToList();

            foreach (var item in orderedList)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Student
    {

        public Student(string firstName, string lastName, string grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }


        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade}";

        }
    }
}
