using System;

namespace PigLatinPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "", repeat = "Y", result = "";
            // Greeting
            DisplayGreeting();
            //Loop begins
            do
            {
                Console.WriteLine("\nEnter a line to be translated: ");
                input = Console.ReadLine();
                result = Translate(input);
                Console.WriteLine(result);

                Console.WriteLine("\nTranslate another line? (y/n)");
                repeat = Console.ReadLine();

            } while (repeat.ToLower() == "y");

            //method to display a greeting
        }
        public static void DisplayGreeting()
        {
            Console.WriteLine("\n****Welcome to the Pig Latin Translator!***");
        }
        private static string Translate(string sentence)
        {
            //declare variables
            string modString = "";
            string[] allWords = sentence.ToLower().Split(' ');

            //process to pig latin for each word
            foreach (string word in allWords)
            {
                modString += TranslateWord(word);
                modString += " ";
            }
            Console.WriteLine("===========================================");
            return modString.TrimEnd();
        }
        private static string TranslateWord(string word)
        {
            //declare variables
            const string WAY = "way";
            const string AY = "ay";
            const string VOWEL = "aeiou";
            string modString = ""; // returned variable
            int position = 0;

            int count = 0;
            char letter = word[0];
            bool hasVowels = true;

            position = VOWEL.IndexOf(letter);
            while (position == -1 && count <= word.Length)
            {
                if (position == -1 && count < word.Length)
                {
                    ++count;
                    letter = word[count - 1];
                    position = VOWEL.IndexOf(letter);
                    hasVowels = true;
                }
                else
                {
                    ++count;
                    hasVowels = false;
                }
            }
            letter = word[0];
            position = VOWEL.IndexOf(letter);
            if (position != -1) //means it is a vowel
            {
                modString = word + WAY;
            }
            else if (hasVowels)
            {
                count = 0;
                while (position == -1 && count < word.Length)
                {
                    ++count;
                    letter = word[count];
                    position = VOWEL.IndexOf(letter);
                }
                //create new string
                modString = word.Substring(count) + word.Substring(0, count) + AY;
            }
            else
            {
                count = 0;
                //create new string
                modString = word.Substring(count) + word.Substring(0, count) + AY;
            }

            return modString;
        }
    }
}
