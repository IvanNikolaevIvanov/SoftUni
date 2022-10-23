using System;
using System.Collections.Generic;

namespace _05._Students_2._0
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

                if (IsStudentExisting(students, commands[0], commands[1]))
                {
                    Students student = GetStudent(students, commands[0], commands[1]);

                    student.FirstName = commands[0];
                    student.LastName = commands[1];
                    student.Age = int.Parse(commands[2]);
                    student.Hometown = commands[3];


                }
                else
                {
                    Students student = new Students
                    {
                        FirstName = commands[0],
                        LastName = commands[1],
                        Age = int.Parse(commands[2]),
                        Hometown = commands[3],
                    };

                    students.Add(student);
                }
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

        static Students GetStudent(List<Students> students, string firstname, string lastname)
        {
            Students existingStudent = null;

            foreach (var student in students)
            {
                if (student.FirstName == firstname && student.LastName == lastname)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }
        static bool IsStudentExisting(List<Students> students, string firstname, string lastname)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstname && student.LastName == lastname)
                {
                    return true;
                }
            }
            return false;
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
