using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day2Part1
    {
        const int RedMax = 12;
        const int GreenMax = 13;
        const int BlueMax = 14;
        const string pattern = @"Game (\d+)";

        int result = 0;

        public int GetResult()
        {
            string fileloc = @"E:\Repos\AdventOfCode2023\Day2\input.txt";

            using (StreamReader read = new StreamReader(fileloc))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    if(IsPossible( ref line ))
                    {
                        result += GetId(ref line);
                    }
                }
            }
            return result;
        }

        int GetId(ref string input)
        {
            var match = Regex.Match(input, pattern);

            if (int.TryParse(match.Groups[1].Value, out int gameId)) {
                return gameId;
            }
            Console.WriteLine("NOT FOUND ID!!!");
            return gameId;
        }

        bool IsPossible( ref string line )
        {
            string[] sets = line.Split(';');
            foreach (var set in sets)
            {
                var colorCounts = CountColors(set);
                if (colorCounts.GetValueOrDefault("blue") > BlueMax || colorCounts.GetValueOrDefault("green") > GreenMax || colorCounts.GetValueOrDefault("red") > RedMax ) {
                    return false;
                }
            }
            return true;
        }

        Dictionary<string, int> CountColors(string set)
        {
            var colorCounts = new Dictionary<string, int>();

            string[] colorTokens = set.Split(',', ';');
            foreach (var garbageCountColorPair in colorTokens)
            {
                string beautifulCountColorPair = garbageCountColorPair.Trim();
                if (beautifulCountColorPair.Contains("blue")) {
                    colorCounts["blue"] = colorCounts.GetValueOrDefault("blue") + GetColorCount(beautifulCountColorPair);
                }
                else if (beautifulCountColorPair.Contains("red")) {
                    colorCounts["red"] = colorCounts.GetValueOrDefault("red") + GetColorCount(beautifulCountColorPair);
                }
                else if (beautifulCountColorPair.Contains("green")) {
                    colorCounts["green"] = colorCounts.GetValueOrDefault("green") + GetColorCount(beautifulCountColorPair);
                }
            }
            return colorCounts;
        }

        int GetColorCount(string token) {
            int count;
            string[] parts = token.Split(' ');
            if (parts.Length > 1 && int.TryParse(parts[0], out count))
            {
                return count;
            }
            return 0;
        }
    }
}
