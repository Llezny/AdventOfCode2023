using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day3
{
    internal class Day3Part1
    {
        List<string> scheme = new();
        Regex regex = new(@"[0-9]+", RegexOptions.Multiline);
        int result = 0;
        int lineLength;

        private void GetScheme()
        {
            string fileloc = @"E:\Repos\AdventOfCode2023\Day3\input.txt";
            using (StreamReader read = new StreamReader(fileloc))
            {
                string line = read.ReadLine();
                scheme.Add( line );
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
            for( int i = 0; i < scheme.Count; i ++)
            {
                var matches = regex.Matches(scheme[i]);
                foreach (Match match in matches)
                {
                    if (IsPartNumber(match, i))
                    {
                        Console.WriteLine(match.Value);
                        result += int.Parse(match.Value);
                    }
                }
            }

            return result;
        }

        private bool IsPartNumber( Match match, int lineIdx ) {

            var idx = match.Index;
            bool startsOnLeftBorder = idx == 0;
            bool endsOnRightBorder = idx + match.Length == lineLength;



            // Check above
            var start = idx;
            var end = start + match.Length;
            if (lineIdx > 0)
            {
                for (int i = start; i < end; i++)
                {
                    if (IsSymbol(scheme[lineIdx - 1][i]))
                    {
                        return true;
                    }
                }
            }


            //Check below
            start = idx;
            end = start + match.Length;
            if(lineIdx + 1 < scheme.Count)
            {
                for (int i = start; i < end; i++)
                {
                    if (IsSymbol(scheme[lineIdx + 1][i]))
                    {
                        return true;
                    }
                }
            }

            var targetIdx = 0;
            if ( !startsOnLeftBorder )
            {
                targetIdx = idx - 1;
                //left
                if (targetIdx > 0 && IsSymbol(scheme[lineIdx][idx - 1]))
                {
                    return true;
                }
                //Top left
                if (lineIdx - 1 > 0 && IsSymbol(scheme[lineIdx - 1][targetIdx]))
                {
                    return true;
                }

                //Bottom left
                if (lineIdx + 1 < scheme.Count && IsSymbol(scheme[lineIdx + 1][targetIdx]))
                {
                    return true;
                }
            }

            if( !endsOnRightBorder )
            {

                //Check right
                targetIdx = idx + match.Length;
                if (targetIdx < scheme[lineIdx].Length && IsSymbol(scheme[lineIdx][targetIdx]))
                {
                    return true;
                }

                //Top right
                targetIdx = idx + match.Length;
                if (lineIdx > 0 && IsSymbol(scheme[lineIdx - 1][targetIdx]))
                {
                    return true;
                }

                //Bottom right
                targetIdx = idx + match.Length;
                if (lineIdx + 1 < scheme.Count && IsSymbol(scheme[lineIdx + 1][targetIdx]))
                {
                    return true;
                }

            }
            return false;
        }

        private bool IsSymbol( char c )
        {
            if(!char.IsLetterOrDigit(c) && c != '.')
            {
            //    Console.Write(c);
                return true;
            }
            return false;
        }
    }

}
