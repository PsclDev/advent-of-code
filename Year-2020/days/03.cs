using System;
using Middleware;

namespace Year_2020.days {
    public static class DayThree {
        public static void TaskOne() {
            var input = Utils.GetPuzzleInput("03-1");
            var encounter = CalculateEncouters(input, 3,1);
            Console.WriteLine(encounter);
        }

        public static void TaskTwo() {
            var input = Utils.GetPuzzleInput("03-1");
            var result = 1;
            var slopes = new Tuple<int, int>[] {
                Tuple.Create(1, 1),
                Tuple.Create(3, 1),
                Tuple.Create(5, 1),
                Tuple.Create(7, 1),
                Tuple.Create(1, 2)
            };

            foreach (var slope in slopes) {
                var encounterdTrees = CalculateEncouters(input, slope.Item1, slope.Item2);
                result *= encounterdTrees;
            }
            Console.WriteLine(result);
        }
        
        private static int CalculateEncouters(string[] input, int stepX, int stepY) {
            var encounter = 0;
            var x = 0;
            
            for (int i = 0; i < input.Length; i+= stepY) {
                if (input[i][x] == '#')
                    encounter++;
                x += stepX;
                if (x >= input[i].Length)
                    x -= input[i].Length;
            }
            return encounter;
        }
    }
}