using System;

namespace Ex04.Menus.Test
{
    internal class ShowVersion : Interfaces.IMethods
    {
        void Interfaces.IMethods.RunMethod()
        {
            Console.WriteLine("{0}Version: 8859.4.1.23{0}", Environment.NewLine);
        }
    }
}