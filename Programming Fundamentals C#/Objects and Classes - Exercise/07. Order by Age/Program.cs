using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "End")
                {
                    break;
                }

                string name = input[0];
                string ID = input[1];
                int age = int.Parse(input[2]);

                Person currentPerson = new Person(name, ID, age);

                if (persons.All(curPerson => curPerson.ID != ID))
                {
                    persons.Add(currentPerson);
                }
                else
                {
                    foreach (var person in persons)
                    {
                        if (person.ID == ID)
                        {
                            person.Name = name;
                            person.Age = age;
                        }
                    }
                }
                

            }

            var orderedPersons = persons.OrderBy(x => x.Age);

            foreach (var person in orderedPersons)
            {
                Console.WriteLine(person);
            }

        }
    }

    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }


        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
