namespace year_2020; 

public class DayThree {
    public static void TaskOne() {
        var input = Util.GetPuzzleInput("03-1");
        var encounter = CalculateEncounters(input, 3,1);
        Console.WriteLine(encounter);
    }

    public static void TaskTwo() {
        var input = Util.GetPuzzleInput("03-1");
        var result = 1;
        var slopes = new Tuple<int, int>[] {
            Tuple.Create(1, 1),
            Tuple.Create(3, 1),
            Tuple.Create(5, 1),
            Tuple.Create(7, 1),
            Tuple.Create(1, 2)
        };

        foreach (var slope in slopes) {
            var encounters= CalculateEncounters(input, slope.Item1, slope.Item2);
            result *= encounters;
        }
        Console.WriteLine(result);
    }
        
    private static int CalculateEncounters(string[] input, int stepX, int stepY) {
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