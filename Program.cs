using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    class Program
    {
        struct Rule
        {
            public string pattern;
            public string replacement;
            public bool isEnd;
            public Rule(string p, string r, bool end)
            {
                this.pattern = p;
                this.replacement = r;
                this.isEnd = end;
            }
        }
        const int n = 11;
        static Rule[] rules = new Rule[n];
        static string Result(string input)
        {
            while (true)
            {
                foreach(Rule rule in rules)
                {
                    if(rule.pattern == "")
                    {
                        input = rule.replacement + input;
                        Console.WriteLine(input);
                        break;
                    }
                    if (input.Contains(rule.pattern))
                    {
                        int pos = input.IndexOf(rule.pattern);
                        if (pos + rule.pattern.Length == input.Length)
                        {
                            input = input.Substring(0, pos) + rule.replacement;
                        }
                        else
                        {
                            Console.WriteLine(pos);
                            input = input.Substring(0, pos) + rule.replacement + input.Substring(pos + rule.pattern.Length);
                        }
                        Console.WriteLine(input);
                        if (rule.isEnd) return input;
                        break;
                    }
                }
            }
        }
        static void Main()
        {
            Rule r1 = new Rule("*a","aA*",false);
            Rule r2 = new Rule("*b", "bB*", false);
            Rule r3 = new Rule("*", "#", false);
            Rule r4 = new Rule("Aa", "aA", false);
            Rule r5 = new Rule("Ab", "bA", false);
            Rule r6 = new Rule("Ba", "aB", false);
            Rule r7 = new Rule("Bb", "bB", false);
            Rule r8 = new Rule("A#", "#a", false);
            Rule r9 = new Rule("B#", "#b", false);
            Rule r10 = new Rule("#", "", true);
            Rule r11 = new Rule("", "*", false);
            rules = new Rule[11] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11 };
            Result("abba");
            Console.ReadLine();
        }
    }
}
