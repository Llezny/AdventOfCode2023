namespace AdventOfCode2023
{
    public class Day6Part2
    {

        long duration;
        long recordToBeat;

        string fileloc = @"E:\Repos\AdventOfCode2023\Day6\input2.txt";

        public long GetResult()
        {
            ReadData();
            long result = 1;
            var minTimeToHold = FindMinimumTimeToWin(duration, recordToBeat);
            var maxTimeToHold = FindMaximumTimeToWin(duration, recordToBeat);
            result *= (maxTimeToHold - minTimeToHold + 1);
            return result;
        }

        private long FindMinimumTimeToWin(long raceDuration, long recordToBeat)
        {
            long holdDurationLeftPivot = 0;
            long holdDurationRightPivot = raceDuration / 2;
            long leftRecord = 0;

            while (leftRecord < recordToBeat)
            {
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
            long holdDurationLeftPivot = raceDuration / 2;
            long holdDurationRightPivot = raceDuration;
            long rightRecord = GetDistance(raceDuration, holdDurationRightPivot);

            while (rightRecord < recordToBeat)
            {
                holdDurationRightPivot = (holdDurationLeftPivot + holdDurationRightPivot) / 2;
                rightRecord = GetDistance(raceDuration, holdDurationRightPivot);
            }
            while (recordToBeat < GetDistance(raceDuration, holdDurationRightPivot + 1))
            {
                holdDurationRightPivot++;
            }

            return holdDurationRightPivot;
        }

        private long GetDistance(long raceDuration, long holdDuration)
        {
            return (raceDuration - holdDuration) * holdDuration;
        }

        private void ReadData()
        {
            using (StreamReader reader = new StreamReader(fileloc))
            {
                // xD
                duration = long.Parse(string.Join("", reader.ReadLine().Split(':', StringSplitOptions.TrimEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)));
                recordToBeat = long.Parse(string.Join("", reader.ReadLine().Split(':', StringSplitOptions.TrimEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)));
            }
        }


    }
}