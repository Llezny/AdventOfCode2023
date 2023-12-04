using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day3
{
    internal class Day4Part1
    {
        int result = 0;


        public int GetResult()
        {
            string fileloc = @"E:\Repos\AdventOfCode2023\Day4\input.txt";
            using (StreamReader read = new StreamReader(fileloc))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    var matches = 0;
                    var str = line.Split(':')[1].Split("|");
                    var winningNumbers = str[0].Split(" ");
                    var myNumbers = str[1].Split(" "); ;
                    foreach (var num in myNumbers) { 
                        if(num != "" && winningNumbers.Contains(num))
                        {
                            matches++;
                        }
                    }

                    if(matches > 0)
                    {
                        result += (int)Math.Pow(2, matches - 1);
                    }

                }
            }

            return result;
        }

    }

}
