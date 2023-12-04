namespace AdventOfCode2023.Day3
{
    internal class Day4Part2
    {
        int[] k = new int[10000];
        int result = 0;
        int lineNum = 0;

        List<List<int>> cardsLookup = new List<List<int>>();
        Queue<int> cardsToCheck = new Queue<int>();

        private void PrepareLookup()
        {
            string fileloc = @"E:\Repos\AdventOfCode2023\Day4\input2.txt";
            using (StreamReader read = new StreamReader(fileloc))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    var matches = 0;
                    var str = line.Split(':')[1].Split("|");
                    var winningNumbers = str[0].Split(" ");
                    var myNumbers = str[1].Split(" ");
                    cardsLookup.Add(new List<int>());
                    cardsToCheck.Enqueue(lineNum);
                    foreach (var num in myNumbers)
                    {
                        if (num != "" && winningNumbers.Contains(num))
                        {
                            matches++;
                            cardsLookup[lineNum].Add(lineNum + matches);
                        }
                    }
                    lineNum++;
                }
            }
        }

        public int GetResult()
        {
            PrepareLookup();
            while(cardsToCheck.Count > 0)
            {
                var newCard = cardsToCheck.Dequeue();
                foreach (var card in cardsLookup[newCard])
                {
                    cardsToCheck.Enqueue(card);
                    k[newCard]++;
                    result++;
                }
            }
            return result + lineNum;
        }
    }
}
