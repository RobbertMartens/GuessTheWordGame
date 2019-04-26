using System;
using System.Collections.Generic;

namespace GuessTheWordGame
{
    public class Program
    {
        private static string _targetWord;
        private static string _userInput;
        private static bool _isCorrect = false;
        private static int _guessesRemaining = 5;

        private static List<string> _wordList;


        public static void Main(string[] args)
        {
            _wordList = CreateWordList();
            _targetWord = SetTargetWord(_wordList);
            Console.WriteLine("Welcome to the Guess The Word Game. What word am I thinking of..?");
            Guess();
            Console.WriteLine("Thank you for playing this game! Hope to see you again soon!");
            Console.ReadLine();
        }

        private static void Guess()
        {
            for (int i = 0; i < _guessesRemaining;)
            {
                Console.WriteLine("Your input:");
                _userInput = Console.ReadLine();
                _isCorrect = IsWordCorrect(_userInput);

                if (_isCorrect)
                {
                    Console.WriteLine("Congratulations! You beat the game!");
                    break;
                }

                _guessesRemaining--;

                if (_guessesRemaining <= 0)
                {
                    Console.WriteLine($"Too bad! You lost the game! The correct word was: {_targetWord}");
                    Console.Read();
                    break;
                }

                Console.WriteLine($"Try again! You have {_guessesRemaining} guesses remaining!");
                GiveWordLengthFeedback(_userInput);
                GiveCorrectLettersFeedback(_userInput);
            }
        }

        private static bool IsWordCorrect(string userInput)
        {
            if (userInput.ToLower().Replace(" ", "") == _targetWord.ToLower().Replace(" ", ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void GiveWordLengthFeedback(string userInput)
        {
            var targetWordLength = _targetWord.Length;
            var userInputLength = userInput.Length;

            if (targetWordLength > userInputLength)
            {
                Console.WriteLine($"Target word is {targetWordLength-userInputLength} letters longer");
            }

            if (targetWordLength < userInputLength)
            {
                Console.WriteLine($"Target word is {userInputLength-targetWordLength} letters shorter!");
            }

            if (targetWordLength == userInputLength)
            {
                Console.WriteLine("Your guessed word has the same amount of letters as the target word!");
            }
        }

        private static void GiveCorrectLettersFeedback(string userInput)
        {
            var targetWordLength = _targetWord.Length;
            var userInputLength = userInput.Length;

            for (int i = 0; i < userInputLength; i++)
            {
                for (int j = 0; j < targetWordLength; j++)
                {
                    if (userInput[i].ToString().ToLower() == _targetWord[j].ToString().ToLower())
                    {
                        if (i == j)
                        {
                            Console.WriteLine($"The letter {userInput[i]} is placed correct!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"The letter {userInput[i]} is correct, but not in the right place!");
                            break;
                        }
                    }
                }
            }
        }

        private static string SetTargetWord(List<string> wordlist)
        {
            var sizeWordList = wordlist.Count;
            var targetWord = wordlist[new Random().Next(0, sizeWordList)];
            return targetWord;
        }

        private static List<string> CreateWordList()
        {
            return new List<string>()
            {
                "Henk", "Sjaak", "Bier", "Koningsdag", "Testcoders", "Scheissarbeid", "Koekenpan",
                "Word", "Wak", "Vet", "Leip"
            };
        }
    }
}
