using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    internal class MenuItem
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private readonly int r_ChoiceNum;
        private readonly string r_MenuItemName;
        private readonly Action r_Method;

        public event Action<MenuItem> Selected;

        public MenuItem(int i_ChoiceNum, string i_MenuItemName, Action i_Method = null)
        {
            r_ChoiceNum = i_ChoiceNum;
            r_MenuItemName = i_MenuItemName;
            r_Method = i_Method;
        }

        public List<MenuItem> MenuItems
        {
            get { return r_MenuItems; }
        }

        public string MenuItemName
        {
            get { return r_MenuItemName; }
        }

        public int ChoiceNum
        {
            get { return r_ChoiceNum; }
        }

        public bool HasMethod()
        {
            bool hasMethod = false;
            if (r_Method != null)
            {
                hasMethod = true;
            }

            return hasMethod;
        }

        public void PrintTitle()
        {
            Console.WriteLine(string.Format("**{0}**", MenuItemName));
            Console.WriteLine("----------------------");
        }

        public void MenuItemWasChosen()
        {
            OnSelected();
        }

        protected virtual void OnSelected()
        {
            if (r_Method != null)
            {
                PrintTitle();
                r_Method.Invoke();
            }

            if (Selected != null)
            {
                Selected.Invoke(this);
            }
        }
    }
}