using System.Text;
using System.Text.RegularExpressions;

namespace CleverenceTestTasks
{
    public class TestTask1
    {
        public static string Compress(string input)
        {
            Regex regex = new Regex(@"([a-z])\1*");
            MatchCollection matcehs = regex.Matches(input);

            
            
            string result = "";
            foreach (Match match in matcehs)
            {
                int charsCount = match.Value.Length;
                string countPostfix = (charsCount > 1) ? charsCount.ToString() : "";
                result += $"{match.Value[0]}{countPostfix}";
            }

            return result;
        }

        public static string Decompress(string input)
        {
            Regex regex = new Regex(@"([a-z]\d)|([a-z])");
            MatchCollection matcehs = regex.Matches(input);

            string result = "";
            foreach (Match match in matcehs)
            {

                //   int charsCount = int.Parse(Regex.Match(match.Value, @"(\d)").Value);
                string number = Regex.Match(match.Value, @"(\d)").Value;
                int count = number.Length > 0 ? int.Parse(number) : 1;
                result += new string(match.Value[0], count);
            }

            return result;
        }

    }
}
