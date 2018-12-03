using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day02
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] lines = File.ReadAllLines(@"/Users/chill/Documents/HomeWork/AdventOfCode/2018/Day02/input.txt");
            //string[] lines = { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz" };
            int count = 0;
            HashSet<string> diffrentStrings = new HashSet<string>();
            foreach (string line in lines)
            {
                count++;
                for (int i = count; i <= lines.Length - 1; i++)
                {
                    string checkLine = lines[i];
                    char[] checkArray = checkLine.ToCharArray();
                    char[] lineArray = line.ToCharArray();
                    List<int> diffrences = new List<int>();
                    for (int x = 0; x <= line.Length -1; x++) {
                        if(! (checkArray[x] == lineArray[x]))
                        {
                           
                            diffrences.Add(x);
                        }
                    }
                    if (diffrences.Count() == 1)
                    {
                        Console.WriteLine("test");
                        List<char> Char = lineArray.ToList();
                        Char.Remove(lineArray[diffrences.First()]);
                        Console.WriteLine(new string(Char.ToArray())); 
                    }
                }
            }
           

        }

        public static int Part1(string[] lines)
        {
            int doubles = 0;
            int triples = 0;
            foreach (string line in lines)
            {
                string input = line;
                bool foundDouble = false;
                bool foundTriple = false;
                foreach (char letter in line)
                {
                    int numberOfTimes = input.Count(x => x == letter);
                    input.Replace(letter, '\0');
                    if (numberOfTimes == 2)
                    {
                        if (!foundDouble)
                        {
                            doubles++;
                            foundDouble = true;
                        }
                    }
                    else if (numberOfTimes == 3)
                    {
                        if (!foundTriple)
                        {
                            triples++;
                            foundTriple = true;
                        }
                    }
                }
            }
            return doubles * triples;
        }
    }
}
