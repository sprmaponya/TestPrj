using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestPrj
{
    public class AdventCode_Day_1
    {

        public async static Task<int> Day_1_Part_1 (string line)
        {
            MatchCollection matches = Regex.Matches(line, @"\d");

            if (matches.Count == 0)
            {
                return 0;
            }

            // First digit
            string firstDigit = matches[0].Value;
            // Last digit, default to first digit if there's only one digit
            string lastDigit = matches[matches.Count > 1 ? matches.Count - 1 : 0].Value;

            // Combine them to form the two-digit number
            int combinedNumber = int.Parse(firstDigit + lastDigit);

            return combinedNumber;
           
        }


        static Dictionary<string, string> numberWords = new Dictionary<string, string>
    {
        {"one", "1"}, {"two", "2"}, {"three", "3"}, {"four", "4"},
        {"five", "5"}, {"six", "6"}, {"seven", "7"}, {"eight", "8"}, {"nine", "9"}
    };    
        static Dictionary<string, string> correcting = new Dictionary<string, string>
    {
        {"one", "oonee"}, {"two", "ttwoo"}, {"three", "tthreee"}, {"four", "ffourr"},
        {"five", "ffivee"}, {"six", "ssixx"}, {"seven", "ssevenn"}, {"eight", "eeightt"}, {"nine", "nninee"}
    };


        static string ReplaceNumberWords(string line)
        {
            // incase two words share a last letter, we seperate them by adding another letter so that when conversion
            //take place, words are not becasue they are not complete
            foreach (var word in correcting)
            {
                line = Regex.Replace(line, word.Key, word.Value, RegexOptions.IgnoreCase);
            }
            
            foreach (var word in numberWords)
            {
                line = Regex.Replace(line, word.Key, word.Value, RegexOptions.IgnoreCase);
            }
            return line;
        }
        public async static Task<int> Day_1_Part_2(string line)
        {
            line = ReplaceNumberWords(line);

            // Use regular expressions to find all digits in the line
            MatchCollection matches = Regex.Matches(line, @"\d");

            if (matches.Count == 0)
            {
                return 0;
            }

            // First digit
            string firstDigit = matches[0].Value;
            // Last digit, default to first digit if there's only one digit
            string lastDigit = matches[matches.Count > 1 ? matches.Count - 1 : 0].Value;

            // Combine them to form the two-digit number
            int combinedNumber = int.Parse(firstDigit + lastDigit);

            return combinedNumber;

        }

    }


}
