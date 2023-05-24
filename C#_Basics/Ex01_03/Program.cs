using System;

class Program
{
    public static void Main()
    {
        run03();
    }

    private static void run03()
    {
        int diamondHeight;
        bool isNumeric;

        Console.WriteLine("Please enter diamond height:");
        isNumeric = int.TryParse(Console.ReadLine(), out diamondHeight);
        while (!isNumeric || diamondHeight <= 0)
        {
            Console.WriteLine("Invalid input, please enter valid input:");
            isNumeric = int.TryParse(Console.ReadLine(), out diamondHeight);
        }

        advencedDiamond(diamondHeight);
        Console.WriteLine("\r\nPress enter to exit...");
        Console.ReadLine();
    }

    private static void advencedDiamond(int i_diamondHeight)
    {
        string startString = string.Empty;

        for (int i = 0; i < i_diamondHeight / 2; i++)
        {
            startString += ' ';
        }

        Ex01_02.Program.Diamond(startString + '*');
    }
}
