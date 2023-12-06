namespace AdventOfCode2023 {
    public class Day6Part1 {

        long[] times;
        long[] distances;

        string fileloc = @"E:\Repos\AdventOfCode2023\Day6\input.txt";

        public long GetResult()
        {
            long result = 1;
            ReadData();
            for(int i = 0; i < times.Length; i++)
            {
                long records = times[i];
                long raceDurations = distances[i];
                var minTimeToHold = FindMinimumTimeToWin(raceDurations, records);
                var maxTimeToHold = FindMaximumTimeToWin(raceDurations, records);
                Console.WriteLine($"min: {minTimeToHold}, max: {maxTimeToHold}");
                Console.WriteLine($"Ways to beat: { maxTimeToHold - minTimeToHold + 1 }");
                result *= (maxTimeToHold - minTimeToHold + 1);
            }


            return result;
        }

        private long FindMinimumTimeToWin( long raceDuration, long recordToBeat ) {
            long holdDurationLeftPivot = 0;
            long holdDurationRightPivot = raceDuration / 2;
            long leftRecord = 0;

            while(leftRecord < recordToBeat) {
                holdDurationLeftPivot = (holdDurationLeftPivot + holdDurationRightPivot) / 2;
                leftRecord = GetDistance(raceDuration, holdDurationLeftPivot);
            }
            while (recordToBeat < GetDistance(raceDuration, holdDurationLeftPivot - 1))
            {
                holdDurationLeftPivot--;
            }
            return holdDurationLeftPivot;
        }

        private long FindMaximumTimeToWin(long raceDuration, long recordToBeat)
        {
            long holdDurationLeftPivot = raceDuration / 2 ;
            long holdDurationRightPivot = raceDuration ;
            long rightRecord = GetDistance(raceDuration, holdDurationRightPivot);

            while (rightRecord < recordToBeat) {
                holdDurationRightPivot = (holdDurationLeftPivot + holdDurationRightPivot) / 2;
                rightRecord = GetDistance(raceDuration, holdDurationRightPivot);
            }
            while( recordToBeat < GetDistance(raceDuration, holdDurationRightPivot + 1))
            {
                holdDurationRightPivot++;
            }

            return holdDurationRightPivot;
        }

        private long GetDistance( long raceDuration, long holdDuration )
        {
            return (raceDuration - holdDuration) * holdDuration;
        }

        private void ReadData() {
            using (StreamReader reader = new StreamReader(fileloc)) {
                distances = reader.ReadLine().Split(':', StringSplitOptions.TrimEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                times = reader.ReadLine().Split(':', StringSplitOptions.TrimEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            }                       
        }

    
    }
}