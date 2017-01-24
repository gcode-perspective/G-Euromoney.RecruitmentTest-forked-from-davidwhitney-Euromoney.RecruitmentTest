using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ContentConsole {
    public static class Reader {
        public static void Main(string[] args) {
            string[] badWords = new[] { "bad", "word", "words", "horrible" };

            string input = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var output = Filter(input, badWords);
            Console.WriteLine("Scanned the text:");
            Console.WriteLine(output);
            Console.ReadKey();

        }
        public static string Filter(string input, string[] badWords) {
            var pattern = @"\b("
                + string.Join("|", badWords.Select(word =>
                    string.Join(@"\s*", word.ToCharArray())))
                + @")\b";
            //RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;

            var re = new Regex(
                @"\b("
                + string.Join("|", badWords.Select(word =>
                    string.Join(@"\s*", word.ToCharArray())))
                + @")\b", RegexOptions.IgnoreCase);



            return re.Replace(input, match =>
            {
                return new string('*', match.Length);
            });
        }
    }
}
