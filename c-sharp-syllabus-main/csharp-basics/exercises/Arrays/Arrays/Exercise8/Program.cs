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
        public static char[] choosedWord;
        public static char[] missed;
        public static char[] leftChars = { };
        public static char[] hiddenWord;
        public static char[] guessedChars;
        static void Main(string[] args)
        {
            InitializeWordGame();

        }
        private static void InitializeWordGame()
        {
            ChooseRandomWord();
            Console.WriteLine(MakeHiddenWord());
        }
        
        private static string MakeHiddenWord()
        {
            string hiddenWordStr = "";
            for(int i=0; i<choosedWord.Length; i++)
            {
                if (Array.IndexOf(guessedChars, choosedWord[i])==-1)
                {
                    hiddenWordStr+="_ ";
                }
                else
                {
                    hiddenWordStr+=$"{choosedWord[i]} ";
                }
            }
            return hiddenWordStr;
            
        }
        private static void ChooseRandomWord()
        {
            string leftCharStr = "";
            int index = 0;
            string randomWord = words[new Random().Next(0, 4)];
            choosedWord = new char[randomWord.Length];
            for(int i=0; i<randomWord.Length; i++)
            {
                choosedWord[i] = randomWord[i];
                if (Array.IndexOf(leftChars, randomWord[i])==-1)
                {
                    leftCharStr+=randomWord[i];
                }
            }
            
            
        }
    }
}
