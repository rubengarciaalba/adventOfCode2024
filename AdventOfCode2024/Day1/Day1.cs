using System.Runtime.CompilerServices;

namespace AdventOfCode2024.Day1
{
    public class Day1
    {
        public Day1()
        {
            var origins = new List<int>() { 3, 4, 2, 1, 3, 3 };
            var destinations = new List<int>() { 4, 3, 5, 3, 9, 3 };

            PrintDistance(origins, destinations);
            PrintSimilarityScore(origins, destinations);
        }
        
        private void PrintDistance(List<int> origins, List<int> destinations)
        {
            var distance = 0;

            origins.Sort();
            destinations.Sort();

            if (origins.Count != destinations.Count)
            {
                Console.WriteLine("The given lists don't have the same length");
                return;
            }

            for (int i = 0; i < origins.Count; i++)
            {
                if (origins[i] > destinations[i])
                {
                    distance += origins[i] - destinations[i];

                    continue;
                }

                distance += destinations[i] - origins[i];
            }

            Console.WriteLine($"The total distance is: {distance}");
        }

        private void PrintSimilarityScore(List<int> origins, List<int> destinations)
        {
            var score = 0;

            var existingSimilarityScores = new Dictionary<int, int>();

            foreach (var o in origins)
            {
                if (!existingSimilarityScores.ContainsKey(o))
                {
                    existingSimilarityScores.Add(o, destinations.Count(d => d == o));
                }

                score += o * existingSimilarityScores[o];
            }

            Console.WriteLine($"The similarity score is {score}");
        }
    }
}
