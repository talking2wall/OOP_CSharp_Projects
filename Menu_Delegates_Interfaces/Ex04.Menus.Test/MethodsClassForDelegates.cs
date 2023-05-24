using System;

namespace Ex04.Menus.Test
{
    internal class MethodsClassForDelegates
    {
        public void ShowVersion()
        {
            Console.WriteLine("{0}Version: 8859.4.1.23{0}", Environment.NewLine);
        }

        public void CountUppercase()
        {
            int uppercaseCouter = 0;
            Console.WriteLine("Enter a string to count the number of uppercase letters in it:");
            string userInput = Console.ReadLine();
            for (int i = 0; i < userInput.Length; i++)
            {
                if (char.IsUpper(userInput[i]))
                {
                    uppercaseCouter++;
                }
            }

            Console.WriteLine("{1}The number of uppercase letters in your string is: {0}{1}", uppercaseCouter, Environment.NewLine);
        }

        public void ShowDate()
        {
            DateTime Date = DateTime.Now;
            Console.WriteLine("{0}The date is: {1}{0}", Environment.NewLine, Date.ToString("dd/MM/yyyy"));
        }

        public void ShowTime()
        {
            DateTime Date = DateTime.Now;
            Console.WriteLine("{0}The time is: {1}{0}", Environment.NewLine, Date.ToString("hh:mm:ss"));
        }
    }
}