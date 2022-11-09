using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ProblematicProblem
{
    class program
    {
        Random rng;
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            //cont = bool.Parse(Console.ReadLine());
            cont = Console.ReadLine().IsLogical();
            Console.WriteLine();
            Console.WriteLine("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Would you like to see the current list of activities? yes/no: ");
            bool seeList = Console.ReadLine().IsLogical();
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.WriteLine($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.WriteLine("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = Console.ReadLine().IsLogical();
                Console.WriteLine();
                while (addToList == true)
                {
                    Console.WriteLine("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.WriteLine($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine().IsLogical();


                }
            }

            do
            {
                Console.WriteLine("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.WriteLine("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                var rng = new Random();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber].ToString();

                if (userAge < 21 && randomActivity.Equals("Wine Tasting", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}!");
                Console.WriteLine();
                Console.WriteLine("Is this ok or do you want to grab another activity? Keep / Redo?");

                cont = Console.ReadLine().IsLogical();

                


                


            } while (cont);
                       
                 
                     
                    

        }
     
    }
    
    
    internal static class MyExtensions
    {
        public static bool IsLogical(this string sender)
        {
            if(string.IsNullOrEmpty(sender))
                return false;

            if (sender.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
                return true;
            else if (sender.Equals("true", StringComparison.CurrentCultureIgnoreCase))
                return true;
            else if (sender.Equals("redo", StringComparison.CurrentCultureIgnoreCase))
                return true;
            else
                return false;
        }
    }
}
        

   
    
 