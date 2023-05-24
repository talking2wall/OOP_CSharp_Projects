using System;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            run02();
        }

        public static void Diamond(string i_FirstLine)
        {
            int asteriskCounter = 0;
            string startString = string.Empty;
            string endString = string.Empty;
            int i;

            Console.WriteLine(i_FirstLine);
            for (i = 0; i < i_FirstLine.Length; i++)
            {
                if (i_FirstLine[i] == '*')
                {
                    asteriskCounter++;
                }
            }

            if (asteriskCounter == i_FirstLine.Length)
            {
                return;
            }

            for (i = 0; i < i_FirstLine.Length - (asteriskCounter + 1); i++)
            {
                startString += " ";
            }

            for (i = 0; i < asteriskCounter + 2; i++)
            {
                endString += "*";
            }

            Diamond(startString + endString);
            Console.WriteLine(i_FirstLine);
        }

        private static void run02()
        {
            Diamond("    *");
            Console.WriteLine("\r\nPress enter to exit...");
            Console.ReadLine();
        }
    }
}
