namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] vowels = {'a', 'e', 'i', 'o', 'u'};
            for(int i = 0; i < vowels.Length; i++)
            {
                System.Console.WriteLine(vowels[i]);
            }

            foreach(var vowel in vowels)
            {
                System.Console.WriteLine(vowel);
            }
        }
    }
}
