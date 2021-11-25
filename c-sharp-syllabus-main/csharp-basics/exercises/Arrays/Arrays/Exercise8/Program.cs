using System;

namespace Exercise8
{
    class Program
    {
        public static string[] words =
        {
            "producer",
            "love",
            "codelex",
            "programmer"
        };
        public static string choosedWord;
        public static string missed;
        public static char[] hiddenWord;
        public static char[] correctGuesses = 
        { 

        };
        public static char guess;
        public static int turn = 0;
        static void Main(string[] args)
        {
            InitializeGame();
        }

        private static void InitializeGame()                                           
        {
            BaseStart:
                missed = "";
                turn = 0;
                guess = default;
                ChooseRandomWord();
                MakeHiddenWord();
                Console.WriteLine("Welcome! You have 14 tries!");
            Start:
                string board = $"Try number {turn}!";
                board += "\nWord: ";
                PrintGuessedWords();
                for(int i = 0; i < hiddenWord.Length; i++)
                {
                   board += hiddenWord[i] + " ";
                }
                board += "\nMisses: ";
                board += missed;
                board += "\nGuess: ";
                Console.WriteLine(board);
                guess = Convert.ToChar(Console.ReadLine());
                AddToMissedChar(guess);
                PrintGuessedWords();
                if (YouWin())
                {
                    goto WinPart;
                }

                turn++;
                if (OutOfTry())
                {
                    Console.WriteLine("Out of tries!");
                    goto QuitAnswer;
                }

                goto Start;
                WinPart:
                board = $"Try number {turn}!";
                board += "\nWord: ";
                PrintGuessedWords();
                for (int i = 0; i < hiddenWord.Length; i++)
                {
                    board += hiddenWord[i] + " ";
                }

                board += "\nMisses: ";
                board += missed;
                board += "\nYOU GOT IT!";
                Console.WriteLine(board);
                QuitAnswer:
                Console.WriteLine(@"Play 'again' or 'quit'?");
                string answer = Console.ReadLine();
                if (ChoosedAgain(answer))
                {
                    goto BaseStart;
                }
                else
                {
                Environment.Exit(0);
                }
        }

        private static void PrintGuessedWords()
        {
                for (int i = 0; i <choosedWord.Length; i++)
                {
                if (guess==choosedWord[i])
                {
                    hiddenWord[i] = choosedWord[i];
                }
                }
        }

        private static void AddToMissedChar(char letter)
        {
            if (!isCorrect(letter))
            {
                missed += letter + " ";
            }
        }

        private static void MakeHiddenWord()
        {
            hiddenWord = new char[choosedWord.Length];
            for(int i = 0; i < choosedWord.Length; i++)
            {
                hiddenWord[i] = '_';
            }
        }

        private static void ChooseRandomWord()
        {
            choosedWord = words[new Random().Next(0, words.Length)];
        }

        private static bool isCorrect(char letter)
        {
            if (choosedWord.Contains(letter))
            {
                return true;
            }
            return false;
        }

        private static bool OutOfTry()
        {
            if (turn>14)
            {
                return true;
            }
            return false;
        }

        private static bool YouWin()
        {
            if (Array.IndexOf(hiddenWord, '_')==-1)
            {
                return true;
            }
            return false;
        }

        private static bool ChoosedAgain(string choice)
        {
            return choice.ToLower()=="again";
        }
    }
}
