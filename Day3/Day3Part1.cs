using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day3
{
    internal class Day3Part1
    {
        string scheme = new("");
        Regex regex = new(@"[0-9]+");
        int result = 0;
        int lineLength;
        int[] dict = new int[1000];

        private void GetScheme()
        {
            string fileloc = @"E:\Repos\AdventOfCode2023\Day3\input.txt";
            using (StreamReader read = new StreamReader(fileloc))
            {
                string line = read.ReadLine();
                scheme += line;
                lineLength = line.Length;
       
                while ((line = read.ReadLine()) != null)
                {
                    scheme += line;
                }
            }
        }

        public int GetResult()
        {
            GetScheme();
            var matches = regex.Matches(scheme);
            foreach(Match match in matches )
            {
                if(IsPartNumber(match))
                {
                    if (dict[int.Parse(match.Value)] == 0)
                    {

                    }
                    Console.WriteLine(match.Value);
                    result += ;
                }
            }
            return result;
        }

        private bool IsPartNumber( Match match ) {

            var idx = match.Index;
            bool startsOnLeftBorder = idx % lineLength == 0;
            bool endsOnRightBorder = (idx + 1) % lineLength == 0;

            // Check above
            var start = Math.Max(0, match.Index - lineLength);
            var end = start + match.Length;
            for( int i = start; i < end; i++ ) {
                if (IsSymbol(scheme[i])) {
                    return true;
                }
            }

            //Check below
            start = Math.Min(scheme.Length - 1, match.Index + lineLength);
            end = Math.Min(scheme.Length - 1, start + match.Length);
            for (int i = start; i < end; i++)
            {
                if (IsSymbol(scheme[i]))
                {
                    return true;
                }
            }
            var targetIdx = 0;
            if ( !startsOnLeftBorder )
            {
                targetIdx = idx - 1;
                //left
                if (targetIdx > 0 && IsSymbol(scheme[idx - 1]))
                {
                    return true;
                }
                //Top left
                targetIdx = idx - 1 - lineLength;
                if (targetIdx > 0 && IsSymbol(scheme[targetIdx]))
                {
                    return true;
                }

                //Bottom left
                targetIdx = idx - 1 + lineLength;
                if (targetIdx < scheme.Length && IsSymbol(scheme[targetIdx]))
                {
                    return true;
                }
            }

            if( !endsOnRightBorder )
            {

                //Check right
                targetIdx = idx + match.Length;
                if (targetIdx < scheme.Length && IsSymbol(scheme[targetIdx]))
                {
                    return true;
                }

                //Top right
                targetIdx = idx + match.Length - lineLength;
                if (targetIdx > 0 && IsSymbol(scheme[targetIdx]))
                {
                    return true;
                }

                //Bottom right
                targetIdx = idx + match.Length + lineLength;
                if (targetIdx < scheme.Length && IsSymbol(scheme[targetIdx]))
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
                Console.Write(c);
                return true;
            }
            return false;
        }
    }

}
