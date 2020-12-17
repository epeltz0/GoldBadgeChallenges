using System;
using System.Collections.Generic;
using KomodoMenu_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Menu_Tests
{
    [TestClass]
    public class UnitTest1
    {

        private MenuRepository _repo;
        private Menu _menu;

        [TestInitialize]
        public void Arrange()
        {
            List<string> listOfIngredients = new List<string>();
            _repo = new MenuRepository();
            _menu = new Menu(1, "hamburger", "meat, cheese, on bun", 10.00m, listOfIngredients);

            _repo.AddMenuToList(_menu);
        }

        [TestMethod]
        public void ViewTest()
        {
            var x = _repo.GetMenuList();

            Assert.IsNotNull(x);
            Assert.IsTrue(x.Count > 0);
        }

        [TestMethod]
        public void AddToListTest()
        {
            
            Menu menu = new Menu();
            menu.MealName = "hamburger";
            MenuRepository repository = new MenuRepository();

            repository.AddMenuToList(menu);
            Menu menuFromDirectory = repository.GetMenuByName("hamburger");

            Assert.IsNotNull(menuFromDirectory);
        }

        [TestMethod]
        public void UpdateExistingMenusTest()
        {
            List<string> listOfIngredients = new List<string>();
            Menu newMenu = new Menu(2, "tacos", "meat, cheese, on tortilla", 9.00m, listOfIngredients);

            bool updateResult = _repo.UpdateExistingMenu("tacos", newMenu);

            Assert.IsTrue(updateResult);
        }

        public void UpdateExistingMenuBoolTest(string orignalMenu, bool shouldUpdate)
        {
            List<string> listOfIngredients = new List<string>();
            Menu newMenu = new Menu(2, "tacos", "meat, cheese, on tortilla", 9.00m, listOfIngredients);

            bool updateResult = _repo.UpdateExistingMenu("hamburger", newMenu);

            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteMenu()
        { 
            bool deleteResult = _repo.RemoveMenuFromList(_menu.MealName);

            Assert.IsTrue(deleteResult);
        }
    }
}
