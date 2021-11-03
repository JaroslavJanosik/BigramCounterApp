using System;
using System.Collections.Generic;
using System.IO;

namespace BigramParseApp
{
    public class BigramConsoleInteraction
    {
        public void RunBigramCounterApp()
        {
            try
            {
                var filePath = ProcessConsoleInput();
                var text = ReadTextFile(filePath);

                try
                {
                    var bigrams = BigramCounter.CountBigrams(text);
                    PrintHistogram(bigrams);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);                   
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file was not found.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                PressEnterToCloseTheWindow();
            }
        }

        private string ProcessConsoleInput()
        {
            Console.WriteLine("Enter a text file path:");

            string input;  

            while (string.IsNullOrEmpty(input = Console.ReadLine())) {}

            return input;
        }        

        private string ReadTextFile(string path)
        {
            string text = "";

            using (StreamReader streamReader = File.OpenText(path))
            {
                text = streamReader.ReadToEnd();
            }

            Console.Out.WriteLine($"\nText: {text}");
            
            return text;
        }

        private void PrintHistogram(Dictionary<string, int> bigrams)
        {
            Console.Out.WriteLine("\nHistogram:");

            foreach (KeyValuePair<string, int> kvp in bigrams)
            {
                Console.Out.WriteLine($"* \"{kvp.Key}\" {kvp.Value}");
            }

            PressEnterToCloseTheWindow();
        }

        private void PressEnterToCloseTheWindow()
        {
            Console.WriteLine("\nPress Enter to close the window ...");
            Console.Read();
        }

    }
}
