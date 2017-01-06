using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyChallenge238
{
    class Program
    {
        static void Main()
        {
            // Easy challenge
            //Console.WriteLine(Easy("cvcvcc"));
            //Console.WriteLine(Easy("ccvv"));
            //Console.WriteLine(Easy("cvcvcvcvcvcvcvcvcvcvcv"));

            // Medium challenge
            Medium();

            Console.ReadKey();
        }

        static string Easy(string input)
        {
            var rand = new Random();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            char[] consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n',
                                  'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };

            char[] inputArray = input.ToCharArray();

            for (int i = 0; i < inputArray.Length; i++) {
                if (inputArray[i] == 'c') {
                    inputArray[i] = consonants[rand.Next(0, consonants.Length - 1)];
                }
                else if (inputArray[i] == 'v') {
                    inputArray[i] = vowels[rand.Next(0, vowels.Length - 1)];
                }
            }

            return new string(inputArray);
        }

        static void Medium()
        {
            // Define variables
            int remainingGuesses = 4, correct;
            string guess = "", word;            
            var rand = new Random();
            string[] wordList = {"scorpion", "flogging", "croppers", "migraine", "footnote", "refinery",
                                 "vaulting", "vicarage", "protract", "descents"};

            // Randomly choose a word from the list to serve as the password, and define character array of this word
            word = wordList[rand.Next(0, wordList.Length - 1)];
            char[] wordChars = word.ToCharArray();

            // Print words
            foreach (var item in wordList) {
                Console.WriteLine(item.ToUpper());
            }

            // Begin guessing -- loop until guess = word
            while (guess != word) {
                correct = 0;

                // Quit if 0 guesses remain
                if (remainingGuesses == 0) {
                    Console.WriteLine("You lose! The answer was: {0}", word.ToUpper());
                    return;
                }

                // Read guess from user and convert to CharArray     
                // Also make sure guess is 8 letters           
                do {
                    Console.Write("Guess ({0} left)? ", remainingGuesses);
                    guess = Console.ReadLine().ToLower(); 
                } while (guess.Length != 8);

                char[] guessChars = guess.ToCharArray();

                // Iterate through CharArrays and check each letter
                for (int i = 0; i < wordChars.Length; i++) {
                    if (wordChars[i] == guessChars[i]) {
                        correct++;
                    }
                }

                // Report to user and deduct a guess
                Console.WriteLine("{0}/8 correct", correct);
                remainingGuesses--;
            }

            // Loop was exited, which means the user guessed the word
            Console.WriteLine("You win!");
        }
    }
}
