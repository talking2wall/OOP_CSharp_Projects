using System;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu interfacesMainMenu = new Interfaces.MainMenu("Interfaces Main Menu");
            interfacesMainMenu.SetMenuItem("Version and Uppercase");
            interfacesMainMenu.SetMenuItem(new string[] { "Version and Uppercase" }, "Show Version", new ShowVersion());
            interfacesMainMenu.SetMenuItem(new string[] { "Version and Uppercase" }, "Count Uppercase", new CountUppercase());
            interfacesMainMenu.SetMenuItem("Show Date/Time");
            interfacesMainMenu.SetMenuItem(new string[] { "Show Date/Time" }, "Show Date", new ShowDate());
            interfacesMainMenu.SetMenuItem(new string[] { "Show Date/Time" }, "Show Time", new ShowTime());
            interfacesMainMenu.Show();

            MethodsClassForDelegates methods = new MethodsClassForDelegates();
            Delegates.MainMenu delegatesMainMenu = new Delegates.MainMenu("Delegates Main Menu");
            delegatesMainMenu.SetMenuItem("Version and Uppercase");
            delegatesMainMenu.SetMenuItem(new string[] { "Version and Uppercase" }, "Show Version", new Action(methods.ShowVersion));
            delegatesMainMenu.SetMenuItem(new string[] { "Version and Uppercase" }, "Count Uppercase", new Action(methods.CountUppercase));
            delegatesMainMenu.SetMenuItem("Show Date/Time");
            delegatesMainMenu.SetMenuItem(new string[] { "Show Date/Time" }, "Show Date", new Action(methods.ShowDate));
            delegatesMainMenu.SetMenuItem(new string[] { "Show Date/Time" }, "Show Time", new Action(methods.ShowTime));
            delegatesMainMenu.Show();
        }
    }
}