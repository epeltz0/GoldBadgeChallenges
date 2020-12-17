using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoMenu_Repository
{
    public class MenuRepository
    {
        private List<Menu> _listOfMenuItems = new List<Menu>();
       
        List<string> listOfIngredients = new List<string>();

        public void AddMenuToList(Menu menu)
        {
            _listOfMenuItems.Add(menu);
        }


        public List<Menu> GetMenuList()
        {
            return _listOfMenuItems;
        }

        public bool RemoveMenuFromList(string mealName)
        {
            Menu menu = GetMenuByName(mealName);

            if (menu == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menu);

            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Menu GetMenuByName(string name)
        {
            foreach (Menu menu in _listOfMenuItems)
            {
                if (menu.MealName.ToLower() == name)
                {
                    return menu;
                }
            }

            return null;
        }

        public bool UpdateExistingMenu(string originalMenu, Menu newMenu)
        {
            
            Menu oldMenu = GetMenuByName(originalMenu);

            if (oldMenu != null)
            {
                oldMenu.MealNumber = newMenu.MealNumber;
                oldMenu.MealName = newMenu.MealName;
                oldMenu.Description = newMenu.Description;
                oldMenu.Price = newMenu.Price;
                oldMenu.ListOfIngredients = newMenu.ListOfIngredients;

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
