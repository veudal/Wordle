using System.Reflection;
using Wordle.Properties;

namespace Wordle
{
    internal class Program
    {
        static bool gameOver;
        static int guessCount;

        static void Main(string[] args)
        {
            while (true)
            {
                List<string> words, guesses;
                string randomWord;
                IntializeGame(out words, out guesses, out randomWord);

                while (gameOver == false)
                {
                    guessCount++;
                    Console.CursorTop = 0;
                    Console.CursorLeft = 0;
                    string guess = string.Empty;
                    while (guess.Length != 5 || !words.Contains(guess))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        guess = Console.ReadLine();
                        Console.Clear();

                        DrawGrid();
                        int i = 1;
                        foreach (string g in guesses)
                        {
                            DisplayGuess(randomWord, g, i);
                            i++;
                        }
                        Console.CursorLeft = 0;
                        Console.CursorTop = 0;
                    }
                    DisplayGuess(randomWord, guess, guessCount);
                    guesses.Add(guess);
                    if (randomWord.ToUpper() == guess.ToUpper())
                    {
                        gameOver = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(@" __      __                                                            __ ");
                        Console.WriteLine(@"|  \    /  \                                                          |  \");
                        Console.WriteLine(@" \▓▓\  /  ▓▓ ______  __    __      __   __   __  ______  _______      | ▓▓");
                        Console.WriteLine(@"  \▓▓\/  ▓▓ /      \|  \  |  \    |  \ |  \ |  \/      \|       \     | ▓▓");
                        Console.WriteLine(@"   \▓▓  ▓▓ |  ▓▓▓▓▓▓\ ▓▓  | ▓▓    | ▓▓ | ▓▓ | ▓▓  ▓▓▓▓▓▓\ ▓▓▓▓▓▓▓\    | ▓▓");
                        Console.WriteLine(@"    \▓▓▓▓  | ▓▓  | ▓▓ ▓▓  | ▓▓    | ▓▓ | ▓▓ | ▓▓ ▓▓  | ▓▓ ▓▓  | ▓▓     \▓▓");
                        Console.WriteLine(@"    | ▓▓   | ▓▓__/ ▓▓ ▓▓__/ ▓▓    | ▓▓_/ ▓▓_/ ▓▓ ▓▓__/ ▓▓ ▓▓  | ▓▓     __ ");
                        Console.WriteLine(@"    | ▓▓    \▓▓    ▓▓\▓▓    ▓▓     \▓▓   ▓▓   ▓▓\▓▓    ▓▓ ▓▓  | ▓▓    |  \");
                        Console.WriteLine(@"     \▓▓     \▓▓▓▓▓▓  \▓▓▓▓▓▓       \▓▓▓▓▓\▓▓▓▓  \▓▓▓▓▓▓ \▓▓   \▓▓     \▓▓");
                    }
                    else if (guessCount > 5)
                    {
                        gameOver = true;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\nNo more guesses left. The word was: " + randomWord);
                Console.WriteLine("Press enter to try again.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void DrawGrid()
        {
            Console.CursorLeft = 18;
            Console.CursorTop = 10;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 6; i++)
            {
                Console.Write("+---+---+---+---+---+");
                Console.CursorTop++;
                Console.CursorLeft = 18;
                Console.Write("|   |   |   |   |   |");
                Console.CursorTop++;
                Console.CursorLeft = 18;
            }
            Console.WriteLine("+---+---+---+---+---+");
        }

        private static void IntializeGame(out List<string> words, out List<string> guesses, out string randomWord)
        {
            guessCount = 0;
            gameOver = false;
            words = Resources.five_letter_words.Split(" ", StringSplitOptions.TrimEntries).ToList();
            guesses = new List<string>();
            Random random = new Random();
            randomWord = words[random.Next(words.Count)];
            DrawGrid();
        }

        private static void DisplayGuess(string randomWord, string guess, int count)
        {
            Console.CursorLeft = 20;
            Console.CursorTop = 9 + (count * 2);
            for (int i = 0; i < 5; i++)
            {
                if (guess[i] == randomWord[i])
                    Console.ForegroundColor = ConsoleColor.Green;

                else if (randomWord.Contains(guess[i]))
                    Console.ForegroundColor = ConsoleColor.Yellow;

                else
                    Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(guess[i]);
                Console.CursorLeft += 3;
            }
        }
    }
}