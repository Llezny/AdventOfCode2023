using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    internal class Day3Part2
    {
        List<string> scheme = new();
        Regex regex = new(@"[0-9]+", RegexOptions.Multiline);
        int result = 0;
        int lineLength;
        Dictionary<(int, int), List<int>> gearsMap = new();  

        private void GetScheme()
        {
            string fileloc = @"E:\Repos\AdventOfCode2023\Day3\input2.txt";
            using (StreamReader read = new StreamReader(fileloc))
            {
                string line = read.ReadLine();
                scheme.Add(line);
                lineLength = line.Length;

                while ((line = read.ReadLine()) != null)
                {
                    scheme.Add(line);
                }
            }
        }

        public int GetResult()
        {
            GetScheme();
            for (int i = 0; i < scheme.Count; i++)
            {
                var matches = regex.Matches(scheme[i]);
                foreach (Match match in matches)
                {
                    CheckNumber(match, i);
                }
            }

            foreach(var v in gearsMap) {
                if(v.Value.Count != 2 )
                {
                    continue;
                }
                result += v.Value[0] * v.Value[1];
            }
            return result;
        }

        private void CheckNumber(Match match, int lineIdx)
        {
            var idx = match.Index;
            bool startsOnLeftBorder = idx == 0;
            bool endsOnRightBorder = idx + match.Length == lineLength;
            var parsedMatchValue = int.Parse(match.Value);


            // Check above
            var start = idx;
            var end = start + match.Length;
            if (lineIdx > 0)
            {
                for (int i = start; i < end; i++)
                {
                    if (IsGear(scheme[lineIdx - 1][i]))
                    {
                        AddToMap(lineIdx - 1, i, parsedMatchValue);
                    }
                }
            }


            //Check below
            start = idx;
            end = start + match.Length;
            if (lineIdx + 1 < scheme.Count)
            {
                for (int i = start; i < end; i++)
                {
                    if (IsGear(scheme[lineIdx + 1][i]))
                    {
                        AddToMap(lineIdx + 1, i, parsedMatchValue);
                    }
                }
            }

            var targetIdx = 0;
            if (!startsOnLeftBorder)
            {
                targetIdx = idx - 1;
                //left
                if (targetIdx > 0 && IsGear(scheme[lineIdx][idx - 1]))
                {
                    AddToMap(lineIdx, targetIdx, parsedMatchValue);
                }
                //Top left
                if (lineIdx - 1 > 0 && IsGear(scheme[lineIdx - 1][targetIdx]))
                {
                    AddToMap(lineIdx - 1, targetIdx, parsedMatchValue);
                }

                //Bottom left
                if (lineIdx + 1 < scheme.Count && IsGear(scheme[lineIdx + 1][targetIdx]))
                {
                    AddToMap(lineIdx + 1, targetIdx, parsedMatchValue);
                }
            }

            if (!endsOnRightBorder)
            {

                //Check right
                targetIdx = idx + match.Length;
                if (targetIdx < scheme[lineIdx].Length && IsGear(scheme[lineIdx][targetIdx]))
                {
                    AddToMap(lineIdx, targetIdx, parsedMatchValue);
                }

                //Top right
                targetIdx = idx + match.Length;
                if (lineIdx > 0 && IsGear(scheme[lineIdx - 1][targetIdx]))
                {
                    AddToMap(lineIdx - 1, targetIdx, parsedMatchValue);
                }

                //Bottom right
                targetIdx = idx + match.Length;
                if (lineIdx + 1 < scheme.Count && IsGear(scheme[lineIdx + 1][targetIdx]))
                {
                    AddToMap(lineIdx + 1, targetIdx, parsedMatchValue );
                }
            }
        }

        private bool IsGear(char c)
        {
            return c == '*';
        }

        private void AddToMap( int lineIdx, int columnIdx, int value )
        {
            if(gearsMap.ContainsKey((lineIdx, columnIdx))) {
                gearsMap[(lineIdx, columnIdx)].Add(value);
            }
            else
            {
                gearsMap.Add((lineIdx, columnIdx), new List<int> { value });
            }
        }
    }

}
