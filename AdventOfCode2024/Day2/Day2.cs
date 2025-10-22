using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace AdventOfCode2024.Day2 
{
    public class Day2 {
        public Day2()
        {
            var reports = new List<List<int>>() {
                { new List<int> { 7, 6, 4, 2, 1 } },
                { new List<int> { 1, 2, 7, 8, 9 } },
                { new List<int> { 9, 7, 6, 2, 1 } },
                { new List<int> { 1, 3, 2, 4, 5 } },
                { new List<int> { 8, 6, 4, 4, 1 } },
                { new List<int> { 1, 3, 6, 7, 9 } },
                { new List<int> { 1, 3, 6, 7, 9, 9 } },
                { new List<int> { 1, 2, 3, 4, 5, 4 } }
            };

            var answer = 0;

            foreach (var report in reports.Select((levels, index) => new { index, levels }))
            {
                if (IsSafe(report.levels, true))
                {
                    answer++;
                }
            }

            Console.WriteLine($"The number of safe reports is {answer}");
        }
      
        private bool IsSafe(List<int> report, bool checkFixedReport)
        {
            var areReportLevelsDecreasing = false;
            var validatedLevels = new List<bool>();

            for (var i = 1; i < report.Count; i++)
            {
                int previousLevel = report[i - 1];
                int currentLevel = report[i];

                if (i == 1)
                {
                    areReportLevelsDecreasing = previousLevel > currentLevel;
                }

                if (((areReportLevelsDecreasing && previousLevel > currentLevel)
                     || (!areReportLevelsDecreasing && currentLevel > previousLevel))
                     && isValidLevelsDifference(previousLevel, currentLevel))
                {
                    validatedLevels.Add(true);
                }
                else
                {
                    validatedLevels.Add(false);
                }
            }

            if (validatedLevels.All(l => l))
            {
                return true;
            }
          
            for (var indexToIgnore = 0; checkFixedReport && indexToIgnore < report.Count; indexToIgnore++)
            {
                var newReport = new List<int>();

                for (var i = 0; i < report.Count; i++)
                {
                    if (i != indexToIgnore)
                    {
                        newReport.Add(report[i]);
                    }
                }

                if (IsSafe([.. newReport], false))
                {
                    return true;
                }
            }

            return false;
        }

        private bool isValidLevelsDifference(int value1, int value2)
        {
            var diff = Math.Abs(value1 - value2);

            return diff > 0 && diff <= 3;
        }
    }
}
