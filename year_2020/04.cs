using System.Text;
using System.Text.RegularExpressions;

namespace year_2020; 

public class DayFour {
    public static void TaskOne() {
            var passports = GetPassports();
            var validPassports = 0;

            foreach (var passport in passports) {
                if (ValidatePassport(passport))
                    validPassports++;
            }
            
            Console.WriteLine($"Valid Passports: {validPassports}");
        }
        
        public static void TaskTwo() {
            var passports = GetPassports();
            var validPassports = 0;

            foreach (var passport in passports) {
                if (ValidatePassportStrict(passport))
                    validPassports++;
            }
            
            Console.WriteLine($"Valid Passports: {validPassports}");
        }

        private static List<string> GetPassports() {
            var input = Util.GetPuzzleInput("04-1").ToList();
            var passports = new List<string>();

            var passportSb = new StringBuilder();
            var delimiter = string.Empty;

            var loop = 0;
            foreach(var line in input) {
                loop++;
                if (line.Length > 0) {
                    passportSb.Append(delimiter);
                    passportSb.Append(line);
                    delimiter = " ";
                }
                else {
                    var passport = passportSb.ToString();
                    passports.Add(passport);
                    passportSb = new StringBuilder();
                }

                if (loop == input.Count) {
                    var passport = passportSb.ToString();
                    passports.Add(passport);
                    passportSb = new StringBuilder();
                }
            }
            
            Console.WriteLine($"Passports found: {passports.Count}");
            return passports;
        }

        private static Dictionary<string, bool> GetValidationDictionary() {
            return new Dictionary<string, bool>() {
                {"byr", false},
                {"iyr", false},
                {"eyr", false},
                {"hgt", false},
                {"hcl", false},
                {"ecl", false},
                {"pid", false}
            };
        }

        private static bool ValidatePassport(string passport) {
            var requiredInfos = GetValidationDictionary();
            var keys = new List<string>(requiredInfos.Keys);

            foreach (var key in keys) {
                requiredInfos[key] = passport.Contains(key);
            }
            return requiredInfos.All(x => x.Value);
        }

        private static bool ValidatePassportStrict(string passport) {
            var requiredInfos = GetValidationDictionary();
            var keys = new List<string>(requiredInfos.Keys);
            var passportDict = GeneratePassportDictionary(passport);
            var value = string.Empty;
            Regex regex;
            foreach (var key in keys) {
                if(!passportDict.Keys.Contains(key))
                    continue;
                
                switch (key) {
                    case "byr":
                        value = passportDict[key];
                        if (int.Parse(value) >= 1920 && int.Parse(value) <= 2002)
                            requiredInfos[key] = true;
                        break;
                    case "iyr":
                        value = passportDict[key];
                        if (int.Parse(value) >= 2010 && int.Parse(value) <= 2020)
                            requiredInfos[key] = true;
                        break;
                    case "eyr":
                        value = passportDict[key];
                        if (int.Parse(value) >= 2020 && int.Parse(value) <= 2030)
                            requiredInfos[key] = true;
                        break;
                    case "hgt":
                        value = passportDict[key];
                        if (value.Contains("cm")) {
                            if (value.Length != 5)
                                continue;
                            
                            var height = int.Parse(value.Substring(0, 3));
                            if(height >= 150 && height <= 193)
                                requiredInfos[key] = true;
                        }
                        if (value.Contains("in")) {
                            if(value.Length != 4)
                                continue;

                            var height = int.Parse(value.Substring(0, 2));
                            if(height >= 59 && height <= 76)
                                requiredInfos[key] = true;
                        }
                        break;
                    case "hcl":
                        value = passportDict[key];
                        regex = new Regex("#[a0-f9]{6}");
                        requiredInfos[key] = regex.IsMatch(value);
                        break;
                    case "ecl":
                        value = passportDict[key];
                        regex = new Regex("(amb|blu|brn|gry|grn|hzl|oth)");
                        requiredInfos[key] = regex.IsMatch(value);
                        break;
                    case "pid":
                        value = passportDict[key];
                        if (value.Length == 9)
                            requiredInfos[key] = true;
                        break;
                }
            }
            return requiredInfos.All(x => x.Value);
        }

        private static Dictionary<string, string> GeneratePassportDictionary(string passport) {
            var dict = new Dictionary<string, string>();
            var passportData = passport.Split(' ');

            foreach (var data in passportData) {
                var split = data.Split(':');
                if(split.Length == 2)
                    dict.Add(split[0], split[1]);
            }

            return dict;
        }
}