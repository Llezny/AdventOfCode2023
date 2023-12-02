

namespace AdventOfCode2023
{
    internal class Day2Part2
    {
        int result = 0;

        public int GetResult()
        {
            string fileloc = @"E:\Repos\AdventOfCode2023\Day2\input2.txt";

            using (StreamReader read = new StreamReader(fileloc))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    result += GetPower(GetMinimumCounts(ref line));

                }
            }
            return result;
        }


        int GetPower(Dictionary<string, int> colorCountsMinimums)
        {
            int power = 1;
            foreach (var colorCountPair in colorCountsMinimums)
            {
                if(colorCountPair.Value > 0 )
                {
                    power *= colorCountPair.Value;
                }
            }
            return power;
        }

        Dictionary<string, int> GetMinimumCounts(ref string line)
        {
            var colorCountsMinimums = new Dictionary<string, int>
            {
                { "blue", int.MinValue },
                { "red", int.MinValue },
                { "green", int.MinValue },
            };

            string[] sets = line.Split(';');
            foreach (var set in sets)
            {
                var colorCounts = CountColors(set);
                foreach(var colorCountPair in colorCounts )
                {
                    colorCountsMinimums[colorCountPair.Key] = Math.Max(colorCountsMinimums[colorCountPair.Key], colorCountPair.Value);
                }
            }
            return colorCountsMinimums;
        }

        Dictionary<string, int> CountColors(string set)
        {
            var colorCounts = new Dictionary<string, int>();

            string[] colorTokens = set.Split(',', ';', ':');
            foreach (var garbageCountColorPair in colorTokens)
            {
                string beautifulCountColorPair = garbageCountColorPair.Trim();
                if (beautifulCountColorPair.Contains("blue"))
                {
                    colorCounts["blue"] = colorCounts.GetValueOrDefault("blue") + GetColorCount(beautifulCountColorPair);
                }
                else if (beautifulCountColorPair.Contains("red"))
                {
                    colorCounts["red"] = colorCounts.GetValueOrDefault("red") + GetColorCount(beautifulCountColorPair);
                }
                else if (beautifulCountColorPair.Contains("green"))
                {
                    colorCounts["green"] = colorCounts.GetValueOrDefault("green") + GetColorCount(beautifulCountColorPair);
                }
            }
            return colorCounts;
        }

        int GetColorCount(string token)
        {
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
