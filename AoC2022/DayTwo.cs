
namespace AoC2022
{
    public class DayTwo : IAdventOfCode
    {
        // https://adventofcode.com/2022/day/2
        // A rock B paper C scissors (opponent)
        // Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock.
        // If both players choose the same shape, the round instead ends in a draw.
        public Dictionary<Shape, Shape> WinnerLoser = new Dictionary<Shape, Shape>() {
            {Shape.Rock, Shape.Scissors},
            {Shape.Scissors, Shape.Paper },
            {Shape.Paper, Shape.Rock}, 
        };

        public Dictionary<Shape, Shape> LoserWinner = new Dictionary<Shape, Shape>() {
            {Shape.Scissors, Shape.Rock},
            {Shape.Paper, Shape.Scissors },
            {Shape.Rock, Shape.Paper},
        };

        public string[] input = File.ReadAllLines("Inputs/Day2Input.txt");

        public void RunProblemOne()
        {
            // x rock, y paper, z scissors (me)
            // 0 loss, 3 draw, 6 win (my points for outcome)
            var results = new Dictionary<string, int>
            {
                { "A X", 3 },
                { "A Y", 6 },
                { "A Z", 0 },
                { "B X", 0 },
                { "B Y", 3 },
                { "B Z", 6 },
                { "C X", 6 },
                { "C Y", 0 },
                { "C Z", 3 },
            };

            var total = 0;
            foreach (var line in input)
            {
                var shape = line[line.Length - 1] switch
                {
                    'X' => Shape.Rock,
                    'Y' => Shape.Paper,
                    'Z' => Shape.Scissors,
                    _ => throw new NotImplementedException()
                };
                var thisRound = GetPlayPoints(shape) + results[line];
                total += thisRound;
            }
            Console.WriteLine(total);
        }

        public void RunProblemTwo()
        {
            // X means you need to lose,
            // Y means you need to end the round in a draw,
            // and Z means you need to win
            var total = 0;
            foreach (var line in input)
            {
                var myMove = line[line.Length - 1];
                var opponentMove = LookupOpponentShape(line[0]);
                if (myMove == 'Y')
                {
                    total = total + 3 + GetPlayPoints(opponentMove);
                    continue;
                }

                if (myMove == 'Z')
                {
                    total = total + 6 + GetPlayPoints(LoserWinner[opponentMove]);
                    continue;

                }
                
                if (myMove == 'X')
                {
                    total = total + 0 + GetPlayPoints(WinnerLoser[opponentMove]);
                    continue;
                }
             
                
            }
            Console.WriteLine(total);
        }

        private int GetPlayPoints(Shape shape)
        {
            // rock 1 pt, paper 2 pt, scissors 3pts (my points for play)
            return shape switch
            {
                Shape.Rock => 1,
                Shape.Paper => 2,
                Shape.Scissors => 3,
                _ => 0,
            };
        }

        private Shape LookupOpponentShape(char letter)
        {
            return letter switch
            {
                'A' => Shape.Rock,
                'B' => Shape.Paper,
                'C' => Shape.Scissors,
                _ => throw new NotImplementedException()
            };
        }

    }

    public enum Shape
    {
        Rock,
        Paper,
        Scissors
    }
}
