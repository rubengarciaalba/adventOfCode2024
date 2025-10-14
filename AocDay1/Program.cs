using System.Runtime.CompilerServices;

namespace AocDay1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var origins = new List<int>() { 3, 4, 2, 1, 3, 3 };
            var destinations = new List<int>() { 4, 3, 5, 3, 9, 3 };

            PrintDistance(origins, destinations);
        }

        private static void PrintDistance(List<int> origins, List<int> destinations)
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
    }
}
