using System;

namespace NumberGuessingGame
{
    class NumberGame
    {
        private int number;
        private int numGuesses;

        public NumberGame(string name, int age)
        {
            int firstDigit = char.ToUpper(name[0]) - 64;  // A=1, B=2, ... Z=26
            int lastDigit = SumDigits(age);
            number = firstDigit * 10 + lastDigit;
            numGuesses = 0;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to the number guessing game!");
            Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess what it is?");
            while (numGuesses < 6)
            {
                int guess = int.Parse(Console.ReadLine());
                numGuesses++;
                if (guess < number)
                {
                    Console.WriteLine("Wrong, the number is bigger.");
                }
                else if (guess > number)
                {
                    Console.WriteLine("Wrong, the number is smaller.");
                }
                else
                {
                    Console.WriteLine("Congratulations, you guessed the number in " + numGuesses + " guesses!");
                    Console.WriteLine("You've just learned the Divide and Conquer algorithm, " + GetName() + "!");
                    return;
                }
            }
            Console.WriteLine("Wrong guess, maybe you should educate yourself on \"Divide and Conquer algorithm to guess the number\". The correct number was " + number + ".");
            PlayAgain();
        }

        private int SumDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }

        private string GetName()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToLower(Console.ReadLine()));
        }

        private void PlayAgain()
        {
            Console.WriteLine("Do you want to play again? (yes/no)");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                Console.WriteLine("I hope you've educated yourself on Divide and Conquer algorithm now, let's play again.");
                numGuesses = 0;
                StartGame();
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's your name?");
            string name = GetName();
            Console.WriteLine("How old are you?");
            int age = int.Parse(Console.ReadLine());
            NumberGame game = new NumberGame(name, age);
            game.StartGame();
        }

        private static string GetName()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToLower(Console.ReadLine()));
        }
    }
}