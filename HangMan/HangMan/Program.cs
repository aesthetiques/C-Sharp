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
            string currentGuess = "";
            string incorrectGuess = "";
            int totalGuesses = 0;

            List<char> guessList = new List<char>(chosenWord.ToCharArray());
            List<char> correctGuessList = new List<char>(chosenWord.Length);
            List<char> totalGuessList = new List<char>(chosenWord.Length) { '_' };

            while(true)
            {
                if(guessList == correctGuessList)
                {
                    Console.WriteLine($"You have successfully guessed {chosenWord}! See you next time!");
                }
                
                for(int i = 0; i < guessList.Count; i++)
                {
                    if(totalGuessList[i] == guessList[i])
                    {

                    }
                }


            }

        }
    }
}
