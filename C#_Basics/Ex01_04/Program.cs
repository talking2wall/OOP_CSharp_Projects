using System;

namespace Ex01_04
{
    class Program
    {
        public static void Main()
        {
            run04();
        }

        private static void run04()
        {
            string isDividable;
            string uppercaseCount;
            string inputText;
            int inputNum;

            Console.WriteLine("Please enter a string of 6 characters (needs to contain only uppercase letters, only lowercase letters or only numbers):");
            inputText = Console.ReadLine();
            while (!inputValidation(inputText, out inputNum))
            {
                Console.WriteLine("Invalid input, try again:");
                inputText = Console.ReadLine();
            }

            if (inputNum == -1)
            {
                isDividable = "Not a number";
            }
            else if (inputNum % 3 == 0)
            {
                isDividable = "Can be divided by 3";
            }
            else
            {
                isDividable = "Can't be divided by 3";
            }

            if (char.IsUpper(inputText[0]))
            {
                uppercaseCount = "The number of uppercase letters is: " + inputText.Length;
            }
            else
            {
                uppercaseCount = "Does not contain uppercase letters";
            }

            Console.WriteLine($"Is palindrom?: {isPalindrom(inputText)}\r\n{isDividable}\r\n{uppercaseCount}");
            Console.WriteLine("\r\nPress enter to exit...");
            Console.ReadLine();
        }

        private static bool isPalindrom(string i_InputText)
        {
            string newString;

            if (i_InputText.Length == 1 || i_InputText.Length == 0)
            {
                return true;
            }

            if (i_InputText[0] != i_InputText[i_InputText.Length - 1])
            {
                return false;
            }

            newString = i_InputText.Remove(0, 1);
            newString = newString.Remove(newString.Length - 1);

            return isPalindrom(newString);
        }

        private static bool inputValidation (string i_InputText, out int io_InputNum)
        {
            bool flagUpper = false;
            bool flagLower = false;
            bool isValidInput = true;

            io_InputNum = -1;
            if (i_InputText.Length != 6)
            {
                isValidInput = false;
            }
            else
            {
                if (int.TryParse(i_InputText, out io_InputNum))
                {
                    if (io_InputNum < 0)
                    {
                        isValidInput = false;
                    }
                }
                else
                {
                    io_InputNum = -1;
                    for (int i = 0; i < i_InputText.Length; i++)
                    {
                        if (!char.IsLetter(i_InputText[i]))
                        {
                            isValidInput = false;
                            break;
                        }

                        if (char.IsUpper(i_InputText[i]))
                        {
                            flagUpper = true;
                        }

                        if (char.IsLower(i_InputText[i]))
                        {
                            flagLower = true;
                        }

                        if (flagUpper == flagLower)
                        {
                            isValidInput = false;
                            break;
                        }
                    }
                }
            }

            return isValidInput;
        }
    }
}
