using System;

namespace Ex01_05
{
    class Program
    {
        public static void Main()
        {
            run05();
        }

        private static void run05()
        {
            int inputNum;
            string inputText;

            Console.WriteLine("Please enter 6 digit integer:");
            inputText = Console.ReadLine();
            while (!inputValidation(inputText, out inputNum))
            {
                Console.WriteLine("Invalid input, please try again:");
                inputText = Console.ReadLine();
            }

            Console.WriteLine($"There Are {numOfHigherDigits(inputNum)} digits that are higher than the units digit\r\nThe lowest digit is: {lowestDigit(inputText)}\r\nThere are {canBeDividedBy3(inputText)} digits that can be divided by 3\r\nThe average of digits is: {getAverageOfDigits(inputNum)}");
            Console.WriteLine("\r\nPress enter to exit...");
            Console.ReadLine();
        }

        private static bool inputValidation(string i_InputText, out int io_InputNum)
        {
            io_InputNum = -1;
            bool isValidInput = true;

            if (i_InputText.Length != 6 || !int.TryParse(i_InputText, out io_InputNum) || io_InputNum < 0)
            {
                isValidInput = false;
                io_InputNum = -1;
            }

            return isValidInput;
        }

        private static int numOfHigherDigits(int i_InputNum)
        {
            int digit = i_InputNum % 10;
            int higherDigitsCounter = 0;

            i_InputNum = i_InputNum / 10;
            while (i_InputNum != 0)
            {
                if (digit < i_InputNum % 10)
                {
                    higherDigitsCounter++;
                }
                    
                i_InputNum /= 10;
            }

            return higherDigitsCounter;
        }

        private static int lowestDigit(string i_InputText)
        {
            char lowestDig = i_InputText[0];

            for (int i = 1; i < i_InputText.Length; i++)
            {
                if (i_InputText[i] < lowestDig)
                {
                    lowestDig = i_InputText[i];
                }      
            }

            return lowestDig - 48;
        }

        private static int canBeDividedBy3(string i_InputText)
        {
            int dividableCounter = 0;

            for (int i = 0; i < i_InputText.Length; i++)
            {
                if ((i_InputText[i] - 48) % 3 == 0)
                {
                    dividableCounter++;
                }  
            }

            return dividableCounter;
        }

        private static int getAverageOfDigits(int i_InputNum)
        {
            int sumOfDigits = 0;

            while (i_InputNum != 0)
            {
                sumOfDigits += i_InputNum % 10;
                i_InputNum /= 10;
            }

            return sumOfDigits / 6;
        }
    }
}
