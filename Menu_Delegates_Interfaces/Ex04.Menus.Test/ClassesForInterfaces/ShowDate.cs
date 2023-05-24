using System;

namespace Ex04.Menus.Test
{
    internal class ShowDate : Interfaces.IMethods
    {
        void Interfaces.IMethods.RunMethod()
        {
            DateTime Date = DateTime.Now;
            Console.WriteLine("{0}The date is: {1}{0}", Environment.NewLine, Date.ToString("dd/MM/yyyy"));
        }
    }
}