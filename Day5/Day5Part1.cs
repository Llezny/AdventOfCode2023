namespace AdventOfCode2023 {
    public class Day5Part1 {
        class Range {
            public long SourceStart { get; set; }
            public long DestStart { get; set; }
            public long Length { get; set; }
        }

        private List<List<Range>> ranges = new List<List<Range>>();
        private Dictionary<long, long> seedLocations = new Dictionary<long, long>();
        private List<long> seeds = new List<long>();

        string fileloc = @"E:\Repos\AdventOfCode2023\Day5\input.txt";

        public long GetResult()
        {
            ReadData();
            MapData();
            return seedLocations.Min(s => s.Value);
        }

        private void ReadData() {
            using (StreamReader reader = new StreamReader(fileloc)) {
                string line = reader.ReadLine();
                var nums = line.Split(':', StringSplitOptions.TrimEntries)[1].Split();
                foreach (var num in nums)
                {
                    seeds.Add(long.Parse(num));
                }

                List<Range> currentMap = new();
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

        private void MapData() {
            long Translate(long seed, List<Range> range) {
                foreach (var r in range)
                {
                    if (seed >= r.SourceStart && seed < r.SourceStart + r.Length)
                        return seed + r.DestStart - r.SourceStart;
                }
                return seed;
            }

            for (int i =0; i< seeds.Count; i++)  {
                foreach (var range in ranges) {
                    seeds[i] = Translate(seeds[i], range);
                }
                seedLocations[seeds[i]] = seeds[i];
            }
        }
    }
}