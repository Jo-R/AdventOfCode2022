namespace AoC2022
{
    public class DayOne
    {
        // https://adventofcode.com/2022/day/1

        public Dictionary<int, int> totals = new Dictionary<int, int>();
        public void RunProblemOne()
        {
           PopulateDictionary();

           Console.WriteLine(totals.Values.Max());
        }

        public void RunProblemTwo()
        {
            PopulateDictionary();

            Console.Write(totals.Values.OrderByDescending(x => x).Take(3).Sum());
        }

        private void PopulateDictionary()
        {
            var input = File.ReadAllLines("Inputs/Day1Input.txt");

            var elf = 1;
            var elfCount = 0;
            foreach (var line in input)
            {
                if (line == String.Empty)
                {
                    totals[elf] = elfCount;
                    elf++;
                    elfCount = 0;
                    continue;
                }

                elfCount = elfCount + Int32.Parse(line);
            }
        }
    }
}
