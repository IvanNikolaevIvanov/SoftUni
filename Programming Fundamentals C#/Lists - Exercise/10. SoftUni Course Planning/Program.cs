using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            var schedule = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "course start")
                {
                    break;
                }

                string[] command = input.Split(':').ToArray();

                string lessonTitle = command[1];

                if (command[0] == "Add")
                {
                    Add(schedule, lessonTitle);
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);

                    Insert(schedule, lessonTitle, index);

                }
                else if (command[0] == "Remove")
                {
                    Remove(lessonTitle, schedule);
                }
                else if (command[0] == "Swap")
                {
                    string swapLesson = command[2];
                    Swap(lessonTitle, swapLesson, schedule);

                }
                else if (command[0] == "Exercise")
                {
                    Exercise(lessonTitle, schedule);
                }

            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");

            }
        }

        private static void Exercise(string lessonTitle, List<string> schedule)
        {
            int currIndex = 0;
            if (schedule.Contains(lessonTitle))
            {
                if (!schedule.Contains($"{lessonTitle}-Exercise"))
                {
                    for (int i = 0; i < schedule.Count; i++)
                    {
                        if (schedule[i] == lessonTitle)
                        {
                            currIndex = i + 1;
                        }
                    }
                    schedule.Insert(currIndex, $"{lessonTitle}-Exercise");
                }
            }
            else
            {
                schedule.Add(lessonTitle);
                schedule.Add($"{lessonTitle}-Exercise");
            }
        }

        private static void Swap(string lessonTitle, string swapLesson, List<string> schedule)
        {
            int currentIndex = 0;
            int currentExerciseIndex = 0;
            int swapIndex = 0;
            int currentSwapExerciseIndex = 0;
            string currentLesson = string.Empty;
            
            if (schedule.Contains(lessonTitle) && schedule.Contains(swapLesson))
            {

                for (int i = 0; i < schedule.Count; i++)
                {
                    if (schedule[i] == lessonTitle)
                    {
                        currentIndex = i;
                       
                        currentExerciseIndex = i + 1; 
                    }
                    if (schedule[i] == swapLesson)
                    {
                        swapIndex = i;
                        
                        currentSwapExerciseIndex = i + 1; 
                    }
                }
                currentLesson = lessonTitle;
                
                schedule.RemoveAt(currentIndex);
                schedule.Insert(currentIndex, swapLesson);
                schedule.RemoveAt(swapIndex);
                schedule.Insert(swapIndex, currentLesson);

                if (schedule.Contains($"{lessonTitle}-Exercise"))
                {
                    schedule.RemoveAt(currentExerciseIndex);
                    schedule.Insert(currentSwapExerciseIndex, $"{lessonTitle}-Exercise");
                }


                if (schedule.Contains($"{swapLesson}-Exercise"))
                {
                    schedule.RemoveAt(currentSwapExerciseIndex);
                    schedule.Insert(currentExerciseIndex, $"{swapLesson}-Exercise");
                }

            }

        }

        private static void Remove(string lessonTitle, List<string> schedule)
        {
            if (schedule.Contains($"{lessonTitle}-Exercise"))
            {
                schedule.Remove($"{lessonTitle}-Exercise");
            }
            schedule.Remove(lessonTitle);
        }

        private static void Insert(List<string> schedule, string lessonTitle, int index)
        {
            for (int i = 0; i < schedule.Count; i++)
            {
                if (schedule.Contains(lessonTitle))
                {
                    continue;
                }
                else
                {
                    schedule.Insert(index, lessonTitle);
                }
            }
        }

        private static void Add(List<string> schedule, string lessonTitle)
        {
            for (int i = 0; i < schedule.Count; i++)
            {
                if (schedule.Contains(lessonTitle))
                {
                    continue;
                }
                else
                {
                    schedule.Add(lessonTitle);
                }
            }
        }
    }
}
