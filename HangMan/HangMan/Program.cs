using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"./data/ChallengeWords.txt";
            MainMenuHandler(path);
        }

        static void InitApp(string path)
        {
            List<string> challengeWords = new List<string>
            {
                "potato",
                "tomato",
                "computer",
                "onomatopoeia",
                "challenging",
                "hangry"
            };

            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    for (int i = 0; i < challengeWords.Count; i++)
                    {
                        Byte[] challengeList = new UTF8Encoding(true).GetBytes(challengeWords[i]);
                        fs.Write(challengeList, 0, challengeList.Length);
                        byte[] newLine = Encoding.ASCII.GetBytes(Environment.NewLine);
                        fs.Write(newLine, 0, newLine.Length);
                    }

                }
            }
        }

        static int MainMenuOptions()
        {
            Console.WriteLine("Choose an number that correlates to an option below, and hit enter.");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. View Challenge Words");
            Console.WriteLine("3. Add Challenge Word");
            Console.WriteLine("4. Remove Challenge Word");
            Console.WriteLine("5. Exit Game");
            return Convert.ToInt32(Console.ReadLine());
        }

        static string ChooseWord(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                List<string> words = new List<string>(File.ReadAllLines(path));
                int roll = new Random().Next(0, words.Count -1);
                return words[roll];
            }
        }
        
        static List<string> GetList(string path)
        {
            
            using (StreamReader sr = File.OpenText(path))
            {
                List<string> wordList = new List<String>(File.ReadAllLines(path));

                foreach(string word in wordList)
                {
                    Console.WriteLine(word);
                }
                return wordList;
            }
        }

        static void AddWord(string path)
        {
            List<string> wordList = new List<string>(GetList(path));

            Console.Clear();
            Console.WriteLine("Current word list");

            foreach(string word in wordList)
            {
                Console.WriteLine(word);
            }

            wordList.Add(Console.ReadLine());

            if (File.Exists(path))
            {
                File.Delete(path);
                using(FileStream fs = File.Create(path))
                {
                    for(int i = 0; i < wordList.Count; i++)
                    {
                        Byte[] challengeList = new UTF8Encoding(true).GetBytes(wordList[i]);
                        fs.Write(challengeList, 0, challengeList.Length);
                        byte[] newLine = Encoding.ASCII.GetBytes(Environment.NewLine);
                        fs.Write(newLine, 0, newLine.Length);
                    }
                    Console.WriteLine($"Successfully added a word to your word list.");
                }
            }
        }

        static void RemoveWord(string path)
        {
            List<string> wordList = new List<string>(GetList(path));

            Console.Clear();
            Console.WriteLine("Current list:");

            foreach(string word in wordList)
            {
                Console.WriteLine(word);
            }

            wordList.RemoveAt(wordList.IndexOf(Console.ReadLine()));

            if (File.Exists(path))
            {
                File.Delete(path);
                using(FileStream fs = File.Create(path))
                {
                    for(int i = 0; i < wordList.Count; i++)
                    {
                        Byte[] challengeList = new UTF8Encoding(true).GetBytes(wordList[i]);
                        fs.Write(challengeList, 0, challengeList.Length);
                        byte[] newLine = Encoding.ASCII.GetBytes(Environment.NewLine);
                        fs.Write(newLine, 0, newLine.Length);
                    }

                    Console.WriteLine($"Successfully removed a word from your list; New List:");

                    foreach (string word in wordList)
                    {
                        Console.WriteLine(word);
                    }
                    Console.WriteLine("");
                }
            }
        }


        static void MainMenuHandler(string path)
        {
            InitApp(path);
            int chosenOption = MainMenuOptions();

            switch (chosenOption)
            {
                case 1:
                    GameHandler(path);
                    break;
                case 2:
                    GetList(path);
                    MainMenuHandler(path);
                    break;
                case 3:
                    AddWord(path);
                    MainMenuHandler(path);
                    break;
                case 4:
                    RemoveWord(path);
                    MainMenuHandler(path);
                    break;
                case 5:
                    Console.WriteLine("Thanks for playing!!");
                    break;
                default:
                    MainMenuHandler(path);
                    break;
            }

        }

        static void GameHandler(string path)
        {
            string chosenWord = ChooseWord(path);

            Console.WriteLine("Enter a character or word as a guess!");
            string guess = Console.ReadLine();
            string incorrectGuess = "";
            int totalGuesses = 0;
            bool hasWon = false;

            char[] chosenList = chosenWord.ToCharArray();
            char[] correctGuess = new char[chosenWord.Length];
            char[] currentGuess = new char[1] { Convert.ToChar(guess) };
            List<char> failedGuesses = new List<char>();

            for(int c = 0; c < correctGuess.Length; c++)
            {
                correctGuess[c] = '_';
            }

            Console.WriteLine(correctGuess);

            //Array.Exists<char>(correctGuess, x => x == '_')
            int totalCorrectGuesses = 0;

            while (totalCorrectGuesses < chosenWord.Length)
            {
                bool wasCorrect = false;
                for(int i = 0; i < chosenList.Length; i++)
                {
                    if(currentGuess[0] == chosenList[i])
                    {
                        correctGuess[i] = chosenList[i];
                        wasCorrect = true;
                        totalCorrectGuesses++;
                    }
                    else if(correctGuess[i] != chosenList[i] && !Char.IsLetter(correctGuess[i]))
                    {
                        correctGuess[i] = '_';
                        Console.WriteLine(correctGuess);
                    }
                    Console.WriteLine(correctGuess);
                }

                if (!wasCorrect)
                {
                    failedGuesses.Add(currentGuess[0]);
                    Console.WriteLine($"Your failed guesses: {failedGuesses}");
                }

                if(totalCorrectGuesses != chosenWord.Length)
                {
                    currentGuess = Console.ReadLine().ToCharArray();
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed {chosenWord}");
                    return;
                }
            }

        }
    }
}
