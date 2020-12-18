using BadgesConsole;
using BadgesRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BadgesConsole
{
    class ProgramUI
    {
        private BadgesRepo _badgesRepo = new BadgesRepo();
        private BadgesRepo _doors = new BadgesRepo();
        private Dictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();
        List<string> listOfDoors = new List<string>();
        public void Run()
        {

            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a badge\n" +
                    "2. View All Badges\n" +
                    "3. Update Badges\n" +
                    "4. Exit\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        ViewAllBadges();
                        break;
                    case "3":
                        UpdateBadges();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void CreateNewBadge()
        {
            Console.Clear();
            Badges newBadge = new Badges();

            Console.WriteLine("Enter the badge's ID number");
            string idNumberString = Console.ReadLine();
            newBadge.BadgeID = int.Parse(idNumberString);

            Console.WriteLine("What doors does this badge have access to...");
            bool addingDoors = true;
            Console.WriteLine("Please enter the doors one at a time...");
            listOfDoors.Add(Console.ReadLine());

            while (addingDoors)
            {
                Console.WriteLine("Press 1 to add another door, Press 2 to finish");

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Please enter another door...");
                        listOfDoors.Add(Console.ReadLine());
                        break;

                    case "2":
                        newBadge.ListOfDoors = listOfDoors;
                        _badgesRepo.AddBadgeToDictionary(newBadge);
                        _dictionary.Add(newBadge.BadgeID, listOfDoors);
                        addingDoors = false;
                        break;
                    default:
                        Console.WriteLine("Press 1 or 2");
                        Console.ReadKey();
                        break;
                }


            }
        }

        private void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badges> BadgeDictionary = _badgesRepo.GetBadgesDictionary();

                foreach (KeyValuePair<int, List<string>>badge in _dictionary)
                {
                Console.WriteLine($"\tBadge ID\t" + $"\tDoor Access\t");
                Console.Write($"\n\t{badge.Key}\t\t");
               
                string listOfDoors = String.Join(',', badge.Value);
                Console.Write($"\t{listOfDoors}");

                Console.WriteLine("\n");
                }
           
        }

        public void UpdateBadges()
        {
            ViewAllBadges();

            Console.WriteLine("Enter the badge's ID number you would like to update");

            int oldBadgeId = int.Parse(Console.ReadLine()); 

            Badges newBadge = new Badges();

            bool addingDoors = true;
           
            while (addingDoors)
            {
                Console.WriteLine("Press 1 to add another door, Press 2 to remove all doors, Press 3 to be done...");

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Please enter another door...");
                        listOfDoors.Add(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("All doors have been deleted");
                        listOfDoors.Clear();
                        break;

                    case "3":
                        newBadge.ListOfDoors = listOfDoors;
                        _badgesRepo.UpdateBadges(_dictionary, oldBadgeId, newBadge.ListOfDoors);
                        addingDoors = false;
                        break;

                    default:
                        Console.WriteLine("Press 1, 2, 3...");
                        Console.ReadKey();
                        break;
                }

            }
            bool wasUpdated = _badgesRepo.UpdateExistingBadges(oldBadgeId, newBadge);

            if (wasUpdated)
            {
                Console.WriteLine("Badge successfully updated");
            }
            else
            {
                Console.WriteLine("Could not update badge");
            }


        }
    }
}