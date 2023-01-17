using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            //Random rng;
            bool cont = true;
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            //bool cont = bool.Parse(Console.ReadLine());
            cont = false;
            if (Console.ReadLine().ToLower() == "yes")
            {
                cont = true;
            }
            if (cont == true)
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                int userAge = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                bool seeList = false;
                if (Console.ReadLine().ToLower() == "sure") seeList = true;
                if (seeList)
                {
                    int tally = 0;
                    foreach (string activity in activities)
                    {
                        tally += 1;
                        if (tally == 1) Console.Write($"{activity}");
                        if (tally != 1) Console.Write($", {activity}");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    bool addToList = false;
                    if (Console.ReadLine().ToLower() == "yes") addToList = true;
                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        tally = 0;
                        foreach (string activity in activities)
                        {
                            tally += 1;
                            if (tally == 1) Console.Write($"{activity}");
                            if (tally != 1) Console.Write($", {activity}");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        addToList = true;
                        if (Console.ReadLine().ToLower() == "no") addToList = false;
                    }
                }

                while (cont)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];
                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    //cont = bool.Parse(Console.ReadLine());
                    cont = true;
                    if (Console.ReadLine().ToLower() == "keep") cont = false;
                }
            }
        }

    }
}