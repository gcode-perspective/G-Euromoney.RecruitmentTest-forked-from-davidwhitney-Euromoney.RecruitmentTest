using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentConsole {
    public static class Curator {

        public static void Main(string[] args) {
            Console.WriteLine("Disable negative word filtering");
            Console.ReadKey();
            
            string[] badWords = new[] { "bad", "word", "words", "horrible" };

            string input = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var output = Filter(input, badWords);
            Console.WriteLine("Scanned the text:");
            Console.WriteLine(input);
            Console.WriteLine("Total Number of negative words: " + output);
            Console.ReadKey();

        }
        public static int Filter(string input, string[] badWords) {
            var badWordCount = 0;
            var pattern = @"\b("
                + string.Join("|", badWords.Select(word =>
                    string.Join(@"\s*", word.ToCharArray())))
                + @")\b";
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;

            var re = new Regex(
                @"\b("
                + string.Join("|", badWords.Select(word =>
                    string.Join(@"\s*", word.ToCharArray())))
                + @")\b", RegexOptions.IgnoreCase);


            foreach (Match match in Regex.Matches(input, pattern, options)) {
                badWordCount++;
            }
            return badWordCount;

            //    return re.Replace(input, match =>
            //    {
            //        return new string('*', match.Length);
            //    });
        }
    }
}
