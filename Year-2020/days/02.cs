using System;
using System.Linq;
using Middleware;

namespace Year_2020.days {
    public static class DayTwo {
        public static void TaskOne() {
            var input = Utils.GetPuzzleInput("02-1");
            var validEntries = 0;

            foreach (var line in input) {
                var splitLine = line.Split(' ');
                var minmax = splitLine[0].Split('-');
                var min = int.Parse(minmax[0]);
                var max = int.Parse(minmax[1]);
                var targetChar = splitLine[1][0];
                var password = splitLine[2];

                var count = password.Count(c => c == targetChar);

                if (count >= min && count <= max)
                    validEntries++;
            }
            
            Console.WriteLine(validEntries);
        }

        public static void TaskTwo() {
            var input = Utils.GetPuzzleInput("02-1");
            var validEntries = 0;

            foreach (var line in input) {
                var splitLine = line.Split(' ');
                var positions = splitLine[0].Split('-');
                var posOne = int.Parse(positions[0]);
                var posTwo = int.Parse(positions[1]);
                var targetChar = splitLine[1][0];
                var password = splitLine[2];

                var posOneValid = false;
                var posTwoValid = false;

                try {
                    if (password[posOne - 1] == targetChar)
                        posOneValid = true;
                    if (password[posTwo - 1] == targetChar)
                        posTwoValid = true;
                }
                catch (Exception) {
                    // ignored
                }

                if((posOneValid && !posTwoValid) || (!posOneValid && posTwoValid))
                    validEntries++;
            }
            
            Console.WriteLine(validEntries);
        }
    }
}