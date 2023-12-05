namespace AdventOfCode2023 {
    public class Day5Part2 {
        class Range {
            public long SourceStart { get; set; }
            public long DestStart { get; set; }
            public long Length { get; set; }
        }

        private List<List<Range>> ranges = new List<List<Range>>();
        private Dictionary<long, long> seedLocations = new Dictionary<long, long>();
        private List<long> seeds = new List<long>();

        string fileloc = @"E:\Repos\AdventOfCode2023\Day5\input2.txt";

        private long Translate(long seed, List<Range> range) {
            foreach (var r in range)
            {
                if (seed >= r.SourceStart && seed < r.SourceStart + r.Length)
                    return seed + r.DestStart - r.SourceStart;
            }
            return seed;
        }

        public long GetResult() {
            ReadData();
            long min = long.MaxValue;
            for (int i = 0; i < seeds.Count; i = i + 2)
            {
                for (long j = seeds[i]; j < seeds[i] + seeds[i + 1]; j++)
                {
                    var seedLocation = MapSeed(j);
                    if (min > seedLocation)
                    {
                        min = seedLocation;
                    }
                }
            }
            return min;
        }

        private void ReadData()
        {
            using (StreamReader reader = new StreamReader(fileloc))
            {
                string line = reader.ReadLine();
                var nums = line.Split(':', StringSplitOptions.TrimEntries)[1].Split();
                foreach (var num in nums)
                {
                    seeds.Add(long.Parse(num));
                }

                List<Range> currentMap = new List<Range>();
                while ((line = reader.ReadLine()) != null) {
                    if (string.IsNullOrEmpty(line))
                    {
                        ranges.Add(currentMap);
                        currentMap = new List<Range>();
                        continue;
                    }
                    if(!line.Contains("map:")) {
                        var entryData = line.Split().Select(long.Parse).ToList();
                        currentMap.Add(new Range()
                        {
                            DestStart = entryData[0],
                            SourceStart = entryData[1],
                            Length = entryData[2]
                        });
                    }
                }
                ranges.Add(currentMap);
            }
        }
        long MapSeed(long seed)
        {
            foreach (var range in ranges)
            {
                seed = Translate(seed, range);
            }
            return seed;
        }
    }
}