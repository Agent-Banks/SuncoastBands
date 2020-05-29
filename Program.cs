using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SuncoastBands
{
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int inputFromUser;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out inputFromUser);

            if (isThisGoodInput)
            {
                return inputFromUser;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }

        }
        static void Main(string[] args)
        {
            // Get a new context that will connect to the database
            var context = new SuncoastBandsContext();

            var bands = context.Bands;
            var albums = context.Albums.Include(album => album.Band);

            //var bandCount = bands.Count();

            //Console.WriteLine($"There are {bandCount} bands!");

            var userHasQuitApp = false;

            while (userHasQuitApp == false)
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Welcome to Suncoast Bands Record Label. Please choose an option.");
                Console.WriteLine("(1) - View all the bands");
                Console.WriteLine("(2) - Add a new band");
                Console.WriteLine("(3) - Add an album for a band");
                Console.WriteLine("(4) - Let a band go");
                Console.WriteLine("(5) - Resign a band");
                Console.WriteLine("(6) - View albums by band name");
                Console.WriteLine("(7) - View all albums ordered by release date");
                Console.WriteLine("(8) - View all bands that are signed");
                Console.WriteLine("(9) - View all bands that are not signed");
                Console.WriteLine("(10) - Quit the application");
                Console.WriteLine("------------------------------------------------------------");

                var option = PromptForInteger("Option: ");

                if (option == 10)
                {
                    userHasQuitApp = true;
                }

                if (option == 1)
                {
                    foreach (var band in bands)
                    {
                        //Console.WriteLine(band.Name);
                    }
                }
            }
        }
    }
}
