using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
namespace DAY03
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<DataPoint> input = ParseFile("/Users/chill/Documents/HomeWork/AdventOfCode/2018/DAY03/input.txt");
            Grid grid = new Grid();
            foreach (DataPoint data in input)
            {
                grid.AddClaim(data.cordinates, data.size, data);
            }
            grid.CountOverlaping();
            int test = grid.GetIntact();


        }


        public static List<DataPoint> ParseFile(string uri)
        {
            List<DataPoint> DataPoints = new List<DataPoint>();
            string[] input = File.ReadAllLines(uri);
            //string[] input = {"#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2"};
            foreach (string line in input)
            {
                string[] lineData = line.Split(' ');
                DataPoint data = new DataPoint();
                string id = lineData[0].Substring(1);
                data.ID = Convert.ToInt32(id);
                string[] cords = lineData[2].Split(',');
                Vector2 pos = new Vector2(Convert.ToInt64(cords[0]), Convert.ToInt64(cords[1].TrimEnd(':')));
                data.cordinates = pos;

                string[] sizecords = lineData[3].Split('x');
                Vector2 size = new Vector2(Convert.ToInt64(sizecords[0]), Convert.ToInt64(sizecords[1]));
                data.size = size;
                DataPoints.Add(data);
            }
            return DataPoints;


        }
    }

    public class DataPoint
    {
        public Vector2 cordinates = new Vector2(0, 0);
        public Vector2 size = new Vector2(0, 0);
        public int ID = 0;
        public bool intact = true;

    }

    public class Grid
    {
        Dictionary<Vector2, List<DataPoint>> grid = new Dictionary<Vector2, List<DataPoint>>();

        public void AddClaim(Vector2 start, Vector2 size,DataPoint point) 
        {

            for (int x = (int) start.X; x< start.X + size.X; x++)
            {
                for (int y = (int) start.Y; y < start.Y + size.Y; y++)
                {
                    Vector2 gridKey = new Vector2(x, y);
                    if (! grid.ContainsKey(gridKey)) {
                        List<DataPoint> points = new List<DataPoint>
                        {
                            point
                        };
                        grid.Add(new Vector2(x, y), points);
                    }
                    else if (grid.ContainsKey(gridKey))
                    {
                        List<DataPoint> val = new List<DataPoint>();
                        grid.TryGetValue(gridKey, out val);
                        grid.Remove(gridKey);
                        val.Add(point);
                        val.Select(c => { c.intact = false; return c; }).ToList();
                        grid.Add(gridKey, val);
                    }

                }
            }

        }

        public int CountOverlaping()
        {
            int count = 0;
            foreach(Vector2 key in grid.Keys)
            {
                List<DataPoint> value = new List<DataPoint>();
                grid.TryGetValue(key, out value);
                if (value.Count() > 1)
                {
                    count++;
                }


            }
            return count;
        }

        public int GetIntact()
        {
            foreach (Vector2 key in grid.Keys)
            {
                List<DataPoint> value = new List<DataPoint>();
                grid.TryGetValue(key, out value);
                if (value.Count() == 1 && value.First().intact)
                {
                    return value.First().ID;
                }


            }
            return 0;
        }
    }
}
