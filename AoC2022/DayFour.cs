
namespace AoC2022
{
    public class DayFour : IAdventOfCode
    {
        public string[] input = File.ReadAllLines("Inputs/Day4Input.txt");

        public void RunProblemOne()
        {
            var total = 0;
            // in how many pairs does one range fully contain another
            foreach (var pair in input)
            {
                var split = pair.ToString().Split(",");
                var one = GetFullRange(split[0]);
                var two = GetFullRange(split[1]);
                var isFullyContained = !one.Except(two).Any() || !two.Except(one).Any();
                if (isFullyContained) total++;
            }
            Console.WriteLine(total);
        }

        public void RunProblemTwo()
        {
            // in how many pairs do the ranges overlap
            var total = 0;
            foreach (var pair in input)
            {
                var split = pair.ToString().Split(",");
                var one = GetFullRange(split[0]);
                var two = GetFullRange(split[1]);
                var hasOverlap = one.Intersect(two).Any();
                if (hasOverlap) total++;
            }
            Console.WriteLine(total);
        }

        private IEnumerable<int> GetFullRange(string pair)
        {
            var split = pair.ToString().Split("-");
            var oneAsInt = Int32.Parse(split[0]);
            return Enumerable.Range(oneAsInt, Int32.Parse(split[1]) - Int32.Parse(split[0]) + 1);
        }
    }
}
