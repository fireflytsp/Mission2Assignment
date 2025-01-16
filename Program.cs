// Sarah Durham
// This program simulates rolling two 6-sided dice. The user inputs how many times they'd like to roll
// the dice. The program will randomly generate numbers and create a histogram showing the percentage of 
// total dice rolls that number assumed.

using System;

namespace Mission2Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask the user for the number of rolls
            Console.WriteLine("Enter the number of times you'd like to roll the dice:");
            int numRolls = 0;
            while (!int.TryParse(Console.ReadLine(), out numRolls) || numRolls <= 0)
            {
                Console.WriteLine("Please enter a valid positive number.");
            }

            // Create a DiceRoller instance
            DiceRoller diceRoller = new DiceRoller();

            // Get the results of the dice rolls
            int[] rollResults = diceRoller.RollDice(numRolls);

            // Display the results as a histogram
            Console.WriteLine("\nRESULTS: \nEach '*' represents 1% of the total number of rolls. " +
                              "\nTotal number of rolls: " + numRolls);

            for (int iCount = 2; iCount <= 12; iCount++)
            {
                double percentage = (double)rollResults[iCount] / numRolls * 100;
                int numStars = (int)(percentage); // Each star represents 1%
                string stars = new string('*', numStars);

                Console.WriteLine(iCount + ":" + stars);
            }
        }
    }

    class DiceRoller
    {
        private Random _random;

        public DiceRoller()
        {
            _random = new Random();
        }

        public int[] RollDice(int numRolls)
        {
            // Initialize an array to track the number of times each sum occurs (2-12)
            int[] rollResults = new int[13]; // Index 0 and 1 are unused

            // Simulate the dice rolls
            for (int i = 0; i < numRolls; i++)
            {
                int die1 = _random.Next(1, 7); // Roll first die (1-6)
                int die2 = _random.Next(1, 7); // Roll second die (1-6)

                int sum = die1 + die2; // Sum of the dice

                rollResults[sum]++; // Increment the count for the corresponding sum
            }

            return rollResults;
        }
    }
}