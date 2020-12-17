using KomodoMenu_Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Komodo_MenuConsole
{
    public class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        private MenuRepository _ingredientRepo = new MenuRepository();
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
                    "1. Create New Menu Option\n" +
                    "2. View All Menu Options\n" +
                    "3. Update Menu\n" +
                    "4. Delete Existing Menu Item\n" +
                    "5. Exit");


                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        UpdateMenu();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void DisplayAllMenuItems()
        {
            Console.Clear();
            List<Menu> listOfMenuItems = _menuRepo.GetMenuList();

            foreach (Menu menu in listOfMenuItems)
            {
                Console.WriteLine($"Meal Number: {menu.MealNumber}\n" +
                    $"Meal Name: {menu.MealName}\n" +
                    $"Description: {menu.Description}\n" +
                    $"Price: ${menu.Price}\n" +
                    $"Ingredients:  ");
                foreach (string ingredient in menu.ListOfIngredients)
                {
                    Console.WriteLine($"{ingredient},");
                }
                Console.WriteLine("\n");




            }
        }

        public void DeleteMenuItem()
        {
            Console.Clear();

            DisplayAllMenuItems();

            Console.WriteLine("\nEnter the name of the menu item you'd like to remove:");

            string input = Console.ReadLine();

            bool wasDeleted = _menuRepo.RemoveMenuFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("Menu item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted.");
            }



        }

        public void CreateNewMenuItem()
        {
            Console.Clear();
            Menu newMenu = new Menu();

            Console.WriteLine("Enter the meal number..");
            string numberAsString = Console.ReadLine();
            newMenu.MealNumber = int.Parse(numberAsString);

            Console.WriteLine("Enter the meal name.. ");
            newMenu.MealName = Console.ReadLine();

            Console.WriteLine("Enter the meal description...");
            newMenu.Description = Console.ReadLine();

            Console.WriteLine("Enter the meal price... (please exclude $)");
            string priceAsString = Console.ReadLine();
            newMenu.Price = decimal.Parse(priceAsString);

            bool addingIngredients = true;
            Console.WriteLine("Please enter the ingredients one at a time...");
            List<string> _ingredients = new List<string> { Console.ReadLine() };

            while (addingIngredients)
            {
                Console.WriteLine("Press 1 to add more ingredient, Press 2 to finish");

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Please enter another ingredient...");
                        _ingredients.Add(Console.ReadLine());
                        break;

                    case "2":
                        newMenu.ListOfIngredients = _ingredients;
                        _menuRepo.AddMenuToList(newMenu);
                        addingIngredients = false;
                        break;
                    default:
                        Console.WriteLine("Press 1 or 2");
                        Console.ReadKey();
                        break;
                }


            }
        }

        public void UpdateMenu()
        {

            DisplayAllMenuItems();

            Console.WriteLine("Enter the name of the menu you'd like to update:");

            string oldMenu = Console.ReadLine();

            Menu newMenu = new Menu();

            Console.WriteLine("Enter the meal number..");
            string numberAsString = Console.ReadLine();
            newMenu.MealNumber = int.Parse(numberAsString);

            Console.WriteLine("Enter the meal name.. ");
            newMenu.MealName = Console.ReadLine();

            Console.WriteLine("Enter the meal description...");
            newMenu.Description = Console.ReadLine();

            Console.WriteLine("Enter the meal price... (please exclude $)");
            string priceAsString = Console.ReadLine();
            newMenu.Price = decimal.Parse(priceAsString);

            bool addingIngredients = true;
            Console.WriteLine("Please enter the ingredients one at a time...");
            List<string> _ingredients = new List<string> { Console.ReadLine() };

            while (addingIngredients)
            {
                Console.WriteLine("Press 1 to add more ingredient, Press 2 to finish");

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Please enter another ingredient...");
                        _ingredients.Add(Console.ReadLine());
                        break;

                    case "2":
                        newMenu.ListOfIngredients = _ingredients;
                        addingIngredients = false;
                        break;
                    default:
                        Console.WriteLine("Press 1 or 2");
                        Console.ReadKey();
                        break;
                }

            }

            bool wasUpdated = _menuRepo.UpdateExistingMenu(oldMenu, newMenu);

            if (wasUpdated)
            {
                Console.WriteLine("Menu successfully updated");
            }
            else
            {
                Console.WriteLine("could not update content");
            }
        }

        
    }
}




