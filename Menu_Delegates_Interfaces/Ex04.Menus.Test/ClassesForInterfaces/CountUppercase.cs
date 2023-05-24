using System;

namespace Ex04.Menus.Test
{
    internal class CountUppercase : Interfaces.IMethods
    {
        void Interfaces.IMethods.RunMethod()
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
    }
}