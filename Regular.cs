using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace TestProject
{
    class Regular
    {
        [Test]
        public void RegularTest()
        {
            // Define a regular expression for repeated words.
            Regex rx = new Regex(@"7cb",
              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.        
            string text = "U206d25c2ea6bd87c17655609a1c37cb8";

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            // Report the number of matches found.
            Console.WriteLine("{0} matches found in:\n   {1}",
                              matches.Count,
                              matches[0].Value);

            // Report on each match.
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("'{0}' repeated at positions {1} and {2}",
                                  groups["word"].Value,
                                  groups[0].Index,
                                  groups[1].Index);
            }

        }
    }
}
