namespace year_2020; 

public static class Util {
    public static string[] GetPuzzleInput(string filename) {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "puzzles",$"{filename}.txt");
        return File.ReadAllLines(filePath);
    }
}