using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private readonly List<MenuItem> r_MainMenuItems = new List<MenuItem>();
        private readonly List<MenuItem> r_MenuItemsCallOrder = new List<MenuItem>();
        private readonly string r_MainMenuTitle;

        public MainMenu(string i_MainMenuTitle)
        {
            r_MainMenuTitle = i_MainMenuTitle;
            addMenuItem(r_MainMenuItems, "Exit");
        }

        private MenuItem findMenuItem(List<MenuItem> i_MenuItems, string i_ValueToFind)
        {
            foreach (MenuItem menuItem in i_MenuItems)
            {
                if (menuItem.MenuItemName == i_ValueToFind)
                {
                    return menuItem;
                }
            }

            throw new Exception("An error occurd, wrong path or menu item name was entered.");
        }

        public void SetMenuItem(string[] i_Path, string i_NameOfMenuItemToAdd, Action i_Method = null)
        {
            MenuItem currMenuItem;
            currMenuItem = findMenuItem(r_MainMenuItems, i_Path[0]);
            for (int i = 1; i < i_Path.Length; i++)
            {
                currMenuItem = findMenuItem(currMenuItem.MenuItems, i_Path[i]);
            }

            if (currMenuItem.HasMethod())
            {
                throw new Exception("An error occurd, adding a new menu item to a leaf item is not possible.");
            }

            if (currMenuItem.MenuItems.Count == 0)
            {
                addMenuItem(currMenuItem.MenuItems, "Back");
            }

            addMenuItem(currMenuItem.MenuItems, i_NameOfMenuItemToAdd, i_Method);
        }

        private void addMenuItem(List<MenuItem> i_MenuItemsToAddFor, string i_NameOfMenuItemToAdd, Action i_Method = null)
        {
            MenuItem menuItemToAdd = new MenuItem(i_MenuItemsToAddFor.Count, i_NameOfMenuItemToAdd, i_Method);
            menuItemToAdd.Selected += new Action<MenuItem>(menuItems_Selected);
            i_MenuItemsToAddFor.Add(menuItemToAdd);
        }

        public void SetMenuItem(string i_NameOfMenuItemToAdd, Action i_Method = null)
        {
            addMenuItem(r_MainMenuItems, i_NameOfMenuItemToAdd, i_Method);
        }

        public void Show()
        {
            showMenu(r_MainMenuTitle, r_MainMenuItems);
            selectMenuItem(r_MainMenuItems);
        }

        private void showMenu(string i_MenuTitle, List<MenuItem> i_MenuItems)
        {
            Console.WriteLine(string.Format("**{0}**", i_MenuTitle));
            Console.WriteLine("----------------------");
            foreach (MenuItem menuItem in i_MenuItems.Skip(1))
            {
                Console.WriteLine(string.Format("{0} -> {1}", menuItem.ChoiceNum, menuItem.MenuItemName));
            }

            Console.WriteLine(string.Format("{0} -> {1}", i_MenuItems[0].ChoiceNum, i_MenuItems[0].MenuItemName));
        }

        private void selectMenuItem(List<MenuItem> i_MenuItems)
        {
            int selection;
            Console.WriteLine(string.Format("Please enter your choice (1-{0} or 0 to exit/back):", i_MenuItems.Count - 1));
            while (inputValidation(Console.ReadLine(), i_MenuItems.Count, out selection) == false)
            {
                Console.WriteLine("Invalid input, please try again:");
            }

            Console.Clear();
            i_MenuItems[selection].MenuItemWasChosen();
        }

        private bool inputValidation(string i_Input, int i_Range, out int io_ChoiceId)
        {
            bool isInputValid;

            isInputValid = int.TryParse(i_Input, out io_ChoiceId);
            if (isInputValid == true && (io_ChoiceId < 0 || io_ChoiceId >= i_Range))
            {
                isInputValid = false;
            }

            return isInputValid;
        }

        private void menuItems_Selected(MenuItem i_ChosenMenuItem)
        {
            if (i_ChosenMenuItem.MenuItems.Count == 0)
            {
                if (i_ChosenMenuItem.ChoiceNum == 0)
                {
                    if (i_ChosenMenuItem.MenuItemName == "Back")
                    {
                        r_MenuItemsCallOrder.RemoveAt(r_MenuItemsCallOrder.Count - 1);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                r_MenuItemsCallOrder.Add(i_ChosenMenuItem);
            }

            if (r_MenuItemsCallOrder.Count == 0)
            {
                Show();
            }
            else
            {
                showMenu(r_MenuItemsCallOrder.Last().MenuItemName, r_MenuItemsCallOrder.Last().MenuItems);
                selectMenuItem(r_MenuItemsCallOrder.Last().MenuItems);
            }
        }
    }
}
