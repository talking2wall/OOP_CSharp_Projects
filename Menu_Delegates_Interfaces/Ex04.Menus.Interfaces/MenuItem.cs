using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    internal interface IChoicesObserver
    {
        void ChoiceSelected(MenuItem i_ChosenMenuItem);
    }

    public interface IMethods
    {
        void RunMethod();
    }

    internal class MenuItem
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private readonly int r_ChoiceNum;
        private readonly string r_MenuItemName;
        private readonly IMethods r_Method;
        private IChoicesObserver m_ChoicesObserver;

        public MenuItem(int i_ChoiceNum, string i_MenuItemName, IMethods i_Function = null)
        {
            r_ChoiceNum = i_ChoiceNum;
            r_MenuItemName = i_MenuItemName;
            r_Method = i_Function;
        }

        public List<MenuItem> MenuItems
        {
            get { return r_MenuItems; }
        }

        public string MenuItemName
        {
            get { return r_MenuItemName; }
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

        public int ChoiceNum
        {
            get { return r_ChoiceNum; }
        }

        public void AttachObserver(IChoicesObserver i_ChoicesObserver)
        {
            m_ChoicesObserver = i_ChoicesObserver;
        }

        public void PrintTitle()
        {
            Console.WriteLine(string.Format("**{0}**", MenuItemName));
            Console.WriteLine("----------------------");
        }

        public void doWhenChosen()
        {
            if(r_Method != null)
            {
                PrintTitle();
                r_Method.RunMethod();
            }

            notifyChoicesObserver();
        }

        private void notifyChoicesObserver()
        {
            m_ChoicesObserver.ChoiceSelected(this);
        }
    }
}
