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
            using(StreamReader sr = File.OpenText(path))
            {
                List<string> wordList = new List<String>(File.ReadAllLines(path));

                foreach(string word in wordList)
                {
                    Console.WriteLine(word);
                }
                return wordList;
            }
        }

        static void AddWord(string path, string word)
        {
            List<string> wordList = new List<string>(GetList(path));
            wordList.Add(word);

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
                    Console.WriteLine($"Successfully added {word} to your word list.");
                }
            }
        }

        static void RemoveWord(string path, string word)
        {
            List<string> wordList = new List<string>(GetList(path));
            wordList.RemoveAt(wordList.IndexOf(word));

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
                    Console.WriteLine($"Successfully removed {word} from your word list.");
                }
            }
        }




    }
}
