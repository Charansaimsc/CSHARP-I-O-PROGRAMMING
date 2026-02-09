/*Problem Statement: Write a C# program that counts the number of
words in a given text file and displays the top 5 most frequently
occurring words.
Requirements: Use StreamReader to read the file. Use a
Dictionary<string, int> to count word occurrences. Sort the words based
on frequency and display the top 5.*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class WordFrequencyService
{
    public static void Run()
    {
        string filePath = "input.txt";

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            Dictionary<string, int> wordCount = CountWords(filePath);
            DisplayTopWords(wordCount, 5);
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O Error: " + ex.Message);
        }
    }

    private static Dictionary<string, int> CountWords(string filePath)
    {
        Dictionary<string, int> words = new Dictionary<string, int>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] tokens = Regex.Split(line.ToLower(), @"\W+");

                foreach (string word in tokens)
                {
                    if (string.IsNullOrWhiteSpace(word))
                        continue;

                    if (words.ContainsKey(word))
                        words[word]++;
                    else
                        words[word] = 1;
                }
            }
        }

        return words;
    }

    private static void DisplayTopWords(Dictionary<string, int> words, int topN)
    {
        Console.WriteLine($"Top {topN} most frequent words:");
        Console.WriteLine("----------------------------");

        var topWords = words
            .OrderByDescending(w => w.Value)
            .Take(topN);

        foreach (var pair in topWords)
        {
            Console.WriteLine($"{pair.Key} : {pair.Value}");
        }
    }
}
