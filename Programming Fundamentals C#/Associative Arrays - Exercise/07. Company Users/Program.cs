using System;
using System.Collections.Generic;

namespace _07._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = new Dictionary<string, List<string>>();

            

            while (true)
            {
                var command = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "End")
                {
                    break;
                }
                string companyName = command[0];
                string employeeId = command[1];

                

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }

                if (!companies[companyName].Contains(employeeId))
                {
                    companies[companyName].Add(employeeId);
                }


            }

            foreach (var company in companies)
            {

                Console.WriteLine(company.Key);

                foreach (var name in company.Value)
                {
                    Console.WriteLine($"-- {name}");
                }


            }

        }
    }
}
