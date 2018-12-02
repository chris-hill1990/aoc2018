using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DAY01
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] input = File.ReadAllLines(@"/Users/chill/Documents/HomeWork/AdventOfCode/2018/DAY01/input.txt");
            double sum = 0;
            List<double> sums = new List<double>
            {
                sum
            };
            bool foundSame = false;

            while (!foundSame)
            {
                foreach (string line in input)
                {
                    double val = Convert.ToDouble(line);
                    if (SeenBefore(sum, sums))
                    {
                        sum += val;
                        sums.Add(sum);
                    }
                    else
                    {
                        foundSame = true;
                        break;
                    }

                }
            }
            Console.WriteLine("The repeating sum is: " + sum);
        }

        public static bool SeenBefore(double check, List<double> list) => list.Count == list.Distinct().Count();

    }
}
