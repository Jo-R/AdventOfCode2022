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
                // a-z = 1 - 26
                // A-Z = 27 - 52
                var c = intersect.First();
                // a = unicode 97 so 97 - 96 = 1 A = unicode 65 so 65 - 38 = 26
                total += char.IsUpper(c) ? (c - 38) : (c - 96);
         
            }
            Console.WriteLine(total);
        }

        public void RunProblemTwo()
        {

        }

    }
}
