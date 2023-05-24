using System;

namespace Ex04.Menus.Test
{
    internal class ShowTime : Interfaces.IMethods
    {
        void Interfaces.IMethods.RunMethod()
        {
            DateTime Date = DateTime.Now;
            Console.WriteLine("{0}The time is: {1}{0}", Environment.NewLine, Date.ToString("hh:mm:ss"));
        }
    }
}