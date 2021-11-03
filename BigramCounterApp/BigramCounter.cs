using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BigramParseApp
{
    public class BigramCounter
    {
        public static Dictionary<string, int> CountBigrams(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Could not count bigrams for empty string.");
            }

            string[] words = ParseTextIntoWords(text);

            Dictionary<string, int> bigrams = new Dictionary<string, int>();

            for (int i = 0; i < words.Length - 1; i++)
            {
                string bigram = $"{words[i]} {words[i + 1]}";                

                if (bigrams.ContainsKey(bigram))
                {
                    bigrams[bigram]++;
                }
                else
                {
                    bigrams.Add(bigram, 1);
                }
            }

            return bigrams;
        }

        public static string[] ParseTextIntoWords(string text)
        {
            string[] result = Regex.Replace(Regex.Replace(text, "[^a-zA-Z\\s]+|[\\n\\t\\r]+", ""), "\\s+", " " ).Trim().ToLower().Split(' ');
            return result;
        }
    }
}
