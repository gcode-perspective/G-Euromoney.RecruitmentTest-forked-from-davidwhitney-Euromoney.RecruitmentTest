using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace ContentConsole {
    public static class Administrator {
        public static void Main(string[] args) {
            var json = System.IO.File.ReadAllText(@"c:\badwords.json");
            Newtonsoft.Json.Linq.JArray jABadWords = Newtonsoft.Json.Linq.JArray.Parse(json);

            string[] badWords = jABadWords.Select(jv => (string)jv).ToArray();

            var phrases = System.IO.File.ReadAllText(@"c:\phrases.txt");

            var output = Filter(phrases, badWords);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(phrases);
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

        }
    }
}
