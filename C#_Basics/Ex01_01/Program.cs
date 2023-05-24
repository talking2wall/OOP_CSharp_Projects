using System;

namespace Ex01_01
{
    class Program
    {
        public static void Main()
        {
			run01();
		}

		private static void run01()
        {
			int inputNum1 = 0;
			int inputNum2 = 0;
			int inputNum3 = 0;
			int numOfZeroes = 0;
			int numOfDigits = 0;
			int numOfOnes;
			int numOfCanBeDividedBy4 = 0;
			int numOfDescendingSeries = 0;
			int numOfPalindroms = 0;
			string binNum;

			Console.WriteLine("Please enter three 8 digit binary numbers:");
			for (int i = 0; i < 3; i++)
			{
				binNum = getInputFromUser(out inputNum3);
				if (i == 0)
				{
					inputNum1 = inputNum3;
				}
				else if (i == 1)
				{
					inputNum2 = inputNum3;
				}

				numOfDigits += binNum.Length;
				numOfZeroes += countZeroes(binNum);
				if (inputNum3 % 4 == 0)
				{
					numOfCanBeDividedBy4++;
				}

				if (checkIfDescendingSeries(inputNum3))
				{
					numOfDescendingSeries++;
				}

				if (isPalindrom(inputNum3))
				{
					numOfPalindroms++;
				}
			}
			numOfOnes = numOfDigits - numOfZeroes;
			Console.WriteLine($"The numbers in descending order are: {DescendingOrder(inputNum1, inputNum2, inputNum3)}\r\nThe average number of zeroes is: {numOfZeroes / 3}\r\nThe average number of ones is: {numOfOnes / 3}\r\nThe number of numbers that their digits are a descending series is: {numOfDescendingSeries}\r\nThe number of numbers that can be divided by 4 is: {numOfCanBeDividedBy4}\r\nThe number of palindroms is: {numOfPalindroms}");
			Console.WriteLine("\r\nPress enter to exit...");
			Console.ReadLine();
		}

        private static bool isPalindrom(int i_InputNum)
        {
			int firstDigit = i_InputNum;
			int power = 1;

			if (i_InputNum < 10)
			{
				return true;
			}

			while (firstDigit >= 10)
            {
				power *= 10;
				firstDigit /= 10;	
            }

			if (firstDigit == i_InputNum % 10)
            {
				return isPalindrom((i_InputNum - firstDigit * power) / 10);
            }

			return false;
        }

		private static bool checkIfDescendingSeries(int i_InputNum)
		{
			bool isDescendingSeries = true;

			while (i_InputNum >= 10)
            {
				if (i_InputNum % 10 > (i_InputNum / 10) % 10)
                {
					isDescendingSeries = false;
					break;
                }
                else
                {
					i_InputNum /= 10;
                }
            }

			return isDescendingSeries;
		}

		private static int countZeroes(string i_InputText)
        {
			int counterOfZeroes = 0;

			for (int i = 0; i < i_InputText.Length; i++)
			{
				if (i_InputText[i] == '0')
				{
					counterOfZeroes++;
				}
			}

			return counterOfZeroes;
		}
		private static string DescendingOrder(int i_InputNum1, int i_InputNum2, int i_InputNum3)
        {
			string descendingOutput;

			if (i_InputNum1 > i_InputNum2)
            {
				if (i_InputNum1 > i_InputNum3)
                {
					if (i_InputNum2 > i_InputNum3)
                    {
						descendingOutput =  i_InputNum1 + ", " + i_InputNum2 + ", " + i_InputNum3;
					}
					else
                    {
						descendingOutput = i_InputNum1 + "," + i_InputNum3 + "," + i_InputNum2;
					}		
				}
				else
                {
					descendingOutput = i_InputNum3 + ", " + i_InputNum1 + ", " + i_InputNum2;
				}
            }
			else
            {
				if (i_InputNum2 > i_InputNum3)
                {
					if (i_InputNum1 > i_InputNum3)
                    {
						descendingOutput = i_InputNum2 + ", " + i_InputNum1 + ", " + i_InputNum3;
					}
					else
                    {
						descendingOutput = i_InputNum2 + ", " + i_InputNum3 + ", " + i_InputNum1;
					}
				}
				else
                {
					descendingOutput = i_InputNum3 + ", " + i_InputNum2 + ", " + i_InputNum1;
				}
            }

			return descendingOutput;  
        }
		private static bool isStringBinary(string i_InputText)
		{
			bool isBinary = true;

			if (i_InputText.Length != 8)
			{
				isBinary =  false;
			}
			else
            {
				for (int i = 0; i < i_InputText.Length; i++)
				{
					if (i_InputText[i] != '0' && i_InputText[i] != '1')
					{
						isBinary = false;
						break;
					}
				}
			}

			return isBinary;
		}
			

		private static string getInputFromUser(out int o_BinNumber)
		{
			string inputText;
			bool isValidInput;

			inputText = Console.ReadLine();
			isValidInput = isStringBinary(inputText);
			while (!isValidInput)
            {
				Console.WriteLine("The input you entered is invalid. Please try again.");
				inputText = Console.ReadLine();
				isValidInput = isStringBinary(inputText);
			}

			o_BinNumber = binaryStringToIDecimal(inputText);

			return inputText;
		}

		private static int binaryStringToIDecimal(string i_InputText)
		{
			int sum = 0;
			char digit;

			for (int i = i_InputText.Length - 1; i >= 0; i--)
			{
				digit = i_InputText[i_InputText.Length - i - 1];
				if (digit == '1')
				{
					sum += (int)Math.Pow(2, i);
				}
			}

			return sum;
		}

	}
}
