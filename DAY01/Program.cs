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
            //string[] input = { "+7", "+7", "-2", "-7", "-4" };
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
                        Console.WriteLine(sum);
                        foundSame = true;
                        break;
                    }

                }
            }
        }

        public static bool SeenBefore(double check, List<double> list)
        {
            int distinct = list.Distinct().Count();
            bool truth = list.Count == list.Distinct().Count();
            return truth;
        }

    }
}
