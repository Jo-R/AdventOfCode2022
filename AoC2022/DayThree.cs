namespace AoC2022
{
    public class DayThree
    {
        // https://adventofcode.com/2022/day/3
        public string[] input = File.ReadAllLines("Inputs/Day3Input.txt");
        public void RunProblemOne()
        {
            var total = 0;
            // each line split in half - what letter appears in each half?
            foreach (var line in input)
            {
                var first = line.Substring(0, line.Length / 2);
                var second = line.Substring(line.Length / 2, line.Length / 2);
                var intersect = first.Intersect(second);

                // what priority does this interestcing item have (it will always only be one)              
                total += GetItemPriority(intersect.First());
         
            }
            Console.WriteLine(total);
        }

        public void RunProblemTwo()
        {
            var total = 0;
            // split into groups of 3 and which letter is common to all 3
            foreach (var line in input.Chunk(3))
            {
                total += GetItemPriority(line[0].Intersect(line[1]).Intersect(line[2]).First());
            }
            Console.WriteLine(total);
        }

        private int GetItemPriority(char item)
        {
            // a-z = 1 - 26
            // A-Z = 27 - 52
            // a = unicode 97 so 97 - 96 = 1 A = unicode 65 so 65 - 38 = 26
            return char.IsUpper(item) ? (item - 38) : (item - 96);
        }

    }
}
