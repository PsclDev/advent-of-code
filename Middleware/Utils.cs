using System;
using System.IO;

namespace Middleware {
    public static class Utils {
        public static string[] GetPuzzleInput(string filename) {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "puzzle",$"{filename}.txt");
            return File.ReadAllLines(filePath);
        }
    }
}