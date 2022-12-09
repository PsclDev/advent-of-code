namespace year_2020; 

public class DaySix {
    private static string abc = "abcdefghijklmnopqrstuvwxyz";
        
        private static Dictionary<char, bool> GetQuestionDict() {
            var dict = new Dictionary<char, bool>();
            
            foreach (var c in abc) {
                dict.Add(c, false);
            }
            return dict;
        }

        private static List<string> GetGroupscompressed(string[] input) {
            var list = new List<string>();
            var group = string.Empty;
            
            foreach (var line in input) {
                if (line.Length == 0) {
                    list.Add(group);
                    group = string.Empty;
                    continue;
                }

                group += line;
            }
            list.Add(group);
            return list;
        }

        private static List<List<string>> GetGroupsUncompressed(string[] input) {
            var list = new List<List<string>>();
            var group = new List<string>();
            
            foreach (var line in input) {
                if (line.Length == 0) {
                    list.Add(group);
                    group = new List<string>();
                    continue;
                }

                group.Add(line);
            }
            list.Add(group);
            return list;
        }

        private static void GetResult(List<int> results) {
            var i = 0;
            results.ForEach(x => i += x);
            Console.WriteLine(i);
        }
        
        public static void TaskOne() {
            var input = Util.GetPuzzleInput("06-1");
            var groups = GetGroupscompressed(input);
            var result = new List<int>();
            foreach (var group in groups) {
                var questionDict = GetQuestionDict();

                foreach (var answer in group) {
                    questionDict[answer] = true;
                }
                result.Add(questionDict.Count(x => x.Value));
            }

            GetResult(result);
        }

        public static void TaskTwo() {
            var input = Util.GetPuzzleInput("06-1");
            var groups = GetGroupsUncompressed(input);
            var result = new List<int>();

            foreach (var group in groups) {
                var questionDict = GetQuestionDict();
                
                foreach (var c in abc) {
                    questionDict[c] = group.All(x => x.Contains(c));
                }   
                
                result.Add(questionDict.Count(x => x.Value));
            }
            
            GetResult(result);
        }
}