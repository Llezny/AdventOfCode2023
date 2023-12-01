namespace AdventOfCode2023
{
    internal class Day1Part1 {

        int result = 0;

        public int GetResult () {
            string fileloc = @"E:\Repos\AdventOfCode2023\Day1\input.txt";

            using (StreamReader read = new StreamReader(fileloc)) {
                string line;
                while ((line = read.ReadLine()) != null) {
                    result += int.Parse( $"{GetFirst(ref line)}{GetLast(ref line)}" );
                }
            }
            return result;
        }

        private char GetFirst( ref string line )
        {
            for( int i = 0; i < line.Length; i++)
            {
                if (Char.IsNumber(line[i])) {
                    return line[i];
                }
            }
            return new char();
        }

        private char GetLast( ref string line )
        {
            for (int i = line.Length -1; i >= 0; i--)
            {
                if (Char.IsNumber(line[i]))
                {
                    return line[i];
                }
            }
            return new char();
        }
    }
}
