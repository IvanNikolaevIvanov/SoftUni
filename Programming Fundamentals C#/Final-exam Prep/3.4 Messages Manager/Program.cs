using System;
using System.Collections.Generic;

namespace _3._4_Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            var users = new Dictionary<string, List<int>>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Statistics")
                {
                    break;
                }

                string command = commands[0];

                if (command == "Add")
                {
                    string name = commands[1];
                    int sent = int.Parse(commands[2]);
                    int received = int.Parse(commands[3]);

                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, new List<int> { sent, received });
                    }
                    else
                    {
                        continue;
                    }

                }

                else if (command == "Message")
                {
                    string sender = commands[1];
                    string receiver = commands[2];

                    if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        foreach (var user in users)
                        {
                            if (user.Key == sender)
                            {
                                user.Value[0]++;

                            }
                            if (user.Key == receiver)
                            {
                                user.Value[1]++;

                            }
                        }
                    }


                    foreach (var user in users)
                    {

                        if (user.Key == sender)
                        {
                            if (user.Value[0] + user.Value[1] >= capacity)
                            {
                                Console.WriteLine($"{user.Key} reached the capacity!");
                                users.Remove(sender);
                                break;
                            }
                        }
                        
                    }

                    foreach (var user in users)
                    {

                        if (user.Key == receiver)
                        {
                            if (user.Value[1] + user.Value[0] >= capacity)
                            {
                                Console.WriteLine($"{user.Key} reached the capacity!");
                                users.Remove(receiver);
                                break;
                            }
                        }

                    }


                }

                //if (user.Value[0] >= capacity)
                //{
                //    Console.WriteLine($"{user.Key} reached the capacity!");
                //    users.Remove(sender);
                //    break;
                //}





                else if (command == "Empty")
                {
                    string username = commands[1];

                    if (username == "All")
                    {
                        users.Clear();
                    }
                    else
                    {
                        foreach (var user in users)
                        {
                            if (user.Key == username)
                            {
                                users.Remove(username);
                                break;
                            }
                        }
                    }
                }




            }

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} - {user.Value[0] + user.Value[1]}");
            }


        }
    }


}
