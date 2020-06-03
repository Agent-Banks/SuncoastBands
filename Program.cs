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
        static DateTime PromptForDateTime(string prompt)
        {
            Console.Write(prompt);
            DateTime inputFromUser;
            var isThisGoodInput = DateTime.TryParse(Console.ReadLine(), out inputFromUser);

            if (isThisGoodInput)
            {
                return inputFromUser;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm putting todays date.");
                return DateTime.Now;
            }
        }
        static void AddNewBand()
        {
            var context = new SuncoastBandsContext();
            var bands = context.Bands;
            var newName = PromptForString("What is the name of the band? ");
            var newCountryOfOrigin = PromptForString("What is the country of origin for this band? ");
            var newNumberOfMembers = PromptForInteger("How many members are in this band? ");
            var newWebsite = PromptForString("What is the bands website? ");
            var newStyle = PromptForString("What style of music does this band play? ");
            var newIsSigned = PromptForBool("Has this band signed with our record label? 'True or False' ");
            var newContactName = PromptForString("What is the primary contact name for this band? ");
            var newContactPhoneNumber = PromptForString("What is the primary phone number for this contact? ");

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
            Console.WriteLine("--------------------------");
            Console.WriteLine("This band has been added to the record label.");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }

        static void ViewAllBands()
        {
            var context = new SuncoastBandsContext();
            var bands = context.Bands;

            Console.WriteLine("Here are all the Bands in Suncoast Bands:");
            Console.WriteLine("--------------------------");

            foreach (var band in bands)
            {
                Console.WriteLine(band.Name);
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }
        
        static void ViewAllAlbumsOrderedByRelease()
        {
            var context = new SuncoastBandsContext();
            var bands = context.Bands;
            var albums = context.Albums.Include(album => album.Band);

            Console.WriteLine("Here are all the albums in our record label ordered by release date:");
            Console.WriteLine("--------------------------");

            var orderAlbumByReleaseDate = context.Albums.OrderBy(album => album.ReleaseDate);

            foreach (var album in orderAlbumByReleaseDate)
            {
                var albumDescription = album.AlbumDescription();
                Console.WriteLine(albumDescription);
            }
                
            Console.WriteLine("--------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }

        static void AddAlbumForBand()
        {
            var context = new SuncoastBandsContext();
            var bands = context.Bands;
            var albums = context.Albums.Include(album => album.Band);

            Console.WriteLine("Here are all the Bands in Suncoast Bands:");
            Console.WriteLine("--------------------------");

            foreach (var band in bands)
            {
                Console.WriteLine($"({band.Id}), {band.Name} ");
            }

            Console.WriteLine("--------------------------");
            var selectedBandId = PromptForInteger("Which band would you like to chose?");

            var selectedBand = bands.FirstOrDefault(band => band.Id == selectedBandId);

            if (selectedBand == null)
            {
                Console.WriteLine("You entered a band that doesn't exist.");
            }
            else
            {
                var newTitle = PromptForString("What is the title of the album? ");
                var newIsExplicit = PromptForBool("Is this album explicit? (True/False) ");
                var newReleasedate = PromptForDateTime("What is the release date? (MM/dd/yyyy h:mm tt) ");

                    var newAlbum = new Album()
                    {
                        Title = newTitle,
                        IsExplicit = newIsExplicit,
                        ReleaseDate = newReleasedate,
                        BandId = selectedBand.Id
                    };

                context.Albums.Add(newAlbum);
                context.SaveChanges();
                Console.WriteLine("A new album has been added for this band.");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.WriteLine();
            }
        }

        static void ViewAlbumsByBandName()
        {
            var context = new SuncoastBandsContext();
            var bands = context.Bands;
            var albums = context.Albums.Include(album => album.Band);

            Console.WriteLine("Here are all the Bands in Suncoast Bands:");
            Console.WriteLine("--------------------------");
            
            foreach (var band in bands)
            {
                Console.WriteLine($"({band.Id}), {band.Name} ");
            }

            Console.WriteLine("--------------------------");
            var selectedBandId = PromptForInteger("Which band would you like to chose? ");
            Console.WriteLine("--------------------------");

            var selectedBand = bands.FirstOrDefault(band => band.Id == selectedBandId);


            if (selectedBand == null)
            {
                Console.WriteLine("You entered a band that doesn't exist.");
            }
            else
            {
                Console.WriteLine("This band has made the following albums:");
                Console.WriteLine("--------------------------");

                foreach (var album in albums)
                {
                    if (album.BandId == selectedBandId)
                    {
                        Console.WriteLine($"{album.Title}");
                    }
                }
            }
                Console.WriteLine("--------------------------");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.WriteLine();
        }

        static void ViewAllBandsThatAreSigned()
        {
            var context = new SuncoastBandsContext();
            var bands = context.Bands;
            var albums = context.Albums.Include(album => album.Band);

            Console.WriteLine("Here are all the bands that are signed:");
            Console.WriteLine("--------------------------");

            foreach (var band in bands)
            {
                if (band.IsSigned == true)
                {
                    Console.WriteLine(band.Name);
                }
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }

        static void DropABand()
        {
            
        }

        static void ViewAllBandsThatAreNotSigned()
        {
            var context = new SuncoastBandsContext();
            var bands = context.Bands;
            var albums = context.Albums.Include(album => album.Band);

            Console.WriteLine("Here are all the bands that are not signed:");
            Console.WriteLine("--------------------------");

            foreach (var band in bands)
            {
                if (band.IsSigned == false)
                {
                     Console.WriteLine(band.Name);
                }
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Get a new context that will connect to the database
            var context = new SuncoastBandsContext();

            var userHasQuitApp = false;

            while (userHasQuitApp == false)
            {
                var bands = context.Bands;
                var albums = context.Albums.Include(album => album.Band);

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Welcome to Suncoast Bands Record Label. Please choose an option:");
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
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Thank you for using Suncoast Bands Record Label Database!");
                    Console.WriteLine("We hope to see you again!");
                    Console.WriteLine("--------------------------");
                    userHasQuitApp = true;
                }

                if (option == 1)
                {
                    ViewAllBands();
                }

                if (option == 2)
                {
                    AddNewBand();
                }

                if (option == 8)
                {
                    ViewAllBandsThatAreSigned();
                }

                if (option == 9)
                {
                    ViewAllBandsThatAreNotSigned();
                }

                if (option == 7)
                {
                    ViewAllAlbumsOrderedByRelease();
                }

                if (option == 3)
                {
                    AddAlbumForBand();
                }

                if (option == 6)
                {
                    ViewAlbumsByBandName();
                }

                if (option == 4)
                {
                    Console.WriteLine("Here are all the Bands in Suncoast Bands:");
                    Console.WriteLine("--------------------------");
                    foreach (var band in bands)
                    {
                        Console.WriteLine($"({band.Id}), {band.Name} ");
                    }

                    Console.WriteLine("--------------------------");
                    Console.WriteLine();

                    var selectedBandId = PromptForInteger("Which band would you like to let go? ");

                    var selectedBand = bands.FirstOrDefault(band => band.Id == selectedBandId);


                    if (selectedBand == null)
                    {
                        Console.WriteLine("You entered a band that doesn't exist.");


                    }
                    else
                    {
                        bool newBandIsSigned = false;
                        selectedBand.IsSigned = newBandIsSigned;
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"This band is now let go");
                    }
                    context.SaveChanges();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.WriteLine();
                }

                if (option == 5)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Here are all the Bands in Suncoast Bands:");
                    foreach (var band in bands)
                    {
                        Console.WriteLine($"({band.Id}), {band.Name} ");
                    }
                    Console.WriteLine("--------------------------");
                    var selectedBandId = PromptForInteger("Which band would you like to resign? ");

                    var selectedBand = bands.FirstOrDefault(band => band.Id == selectedBandId);


                    if (selectedBand == null)
                    {
                        Console.WriteLine("You entered a band that doesn't exist.");


                    }
                    else
                    {
                        bool newBandIsSigned = true;
                        selectedBand.IsSigned = newBandIsSigned;
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"This band is now resigned");
                    }
                    context.SaveChanges();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }
    }
}
