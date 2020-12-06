using System;
using Middleware;

namespace Year_2020.days {
    public static class DayOne{
        private static int[] GetPuzzleInput() {
            var input = Utils.GetPuzzleInput("01-1");
            return Array.ConvertAll(input, i => Int32.Parse(i));
        }
        public static void TaskOne() {
            var input = GetPuzzleInput();
            foreach (var i in input) {
                foreach (var k in input) {
                    if(i + k == 2020)
                        Console.WriteLine(i * k);
                }
            }
        }

        public static void TaskTwo() {
            var input = GetPuzzleInput();
            foreach (var i in input) {
                foreach (var k in input) {
                    foreach (var j in input) {
                        if(i + k + j == 2020)
                            Console.WriteLine(i * k * j);
                    }
                }
            }
        }
    }
}