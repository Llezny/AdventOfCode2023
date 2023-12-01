
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
        internal class Day1Part2
        {

            int result = 0;

            const string pattern = @"(one|two|three|four|five|six|seven|eight|nine|[0-9])";
            Regex firstRegex = new(pattern, RegexOptions.IgnoreCase);
            Regex lastRegex = new(pattern, RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

        public int GetResult()
            {
                string fileloc = @"E:\Repos\AdventOfCode2023\Day1\input2.txt";

                using (StreamReader read = new StreamReader(fileloc))
                {
                    string line;
                    while ((line = read.ReadLine()) != null)
                    {
                        result += int.Parse($"{GetFirst(ref line)}{GetLast(ref line)}");
                }
                }
                return result;
            }

            private int GetFirst(ref string line)
            {
                Match m = firstRegex.Match(line);
                return ToInt( m.Value);
            }

            private int GetLast(ref string line)
            {
                
                Match m = lastRegex.Match(line);
                return ToInt(m.Value);
            }

            public static int ToInt( string str) => str switch {
                "zero" => 0,
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                _ => int.Parse(str)
            };

        }
    }
