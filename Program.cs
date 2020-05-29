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
        static bool PromptForBool(string prompt)
        {
            Console.Write(prompt);
            bool inputFromUser;
            var isThisGoodInput = bool.TryParse(Console.ReadLine(), out inputFromUser);

            if (inputFromUser == true || inputFromUser == false)
            {
                return inputFromUser;
            }
            else
            {
                Console.WriteLine("Sorry that is an invalid input. I am using false as your answer");
                return false;
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
                    Console.WriteLine("Here are all the Bands in Suncoast Bands");
                    foreach (var band in bands)
                    {
                        Console.WriteLine(band.Name);
                    }
                }

                if (option == 2)
                {
                    var newName = PromptForString("What is the name of the band?");
                    var newCountryOfOrigin = PromptForString("What is the country of origin for this band?");
                    var newNumberOfMembers = PromptForInteger("How many members are in this band?");
                    var newWebsite = PromptForString("What is the bands website?");
                    var newStyle = PromptForString("What style of music does this band play?");
                    var newIsSigned = PromptForBool("Has this band signed with our record label? 'True or False'");
                    var newContactName = PromptForString("What is the primary contact name for this band?");
                    var newContactPhoneNumber = PromptForString("What is the primary phone number for this contact?");
                    var newBand = new Band
                    {
                        Name = newName,
                        CountryOfOrigin = newCountryOfOrigin,
                        NumberOfMembers = newNumberOfMembers,
                        Website = newWebsite,
                        Style = newStyle,
                        IsSigned = newIsSigned,
                        ContactName = newContactName,
                        ContactPhoneNumber = newContactPhoneNumber
                    };

                    context.Bands.Add(newBand);
                    context.SaveChanges();
                }
            }
        }
    }
}
