using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SrubskoUnlished
{
    class Program
    {
        static void Main()
        {
            var pattern =
                "^(?<singer>[a-zA-Z\\s]+)(?:\\s{1})@(?<venue>[a-zA-Z\\s]+[a-zA-Z]+)\\s{1}(?<tickets>\\d+)\\s{1}(?<price>\\d+)$";
               // "(?<singer>[a-zA-Z\\s]+)(?:\\s{1})@(?<venue>[a-zA-Z]+\\s?[a-zA-Z]+)\\s{1}(?<tickets>\\d+)\\s{1}(?<price>\\d+)";
               //  "((?<singer>[a-zA-Z]+\\s?[a-zA-Z]+))(?:\\s{1})@(?<venue>[a-zA-Z]+\\s?[a-zA-Z]+)\\s{1}(?<tickets>\\d+)\\s{1}(?<price>\\d+)";

            Regex rgx = new Regex(pattern);
            var dic = new Dictionary<string, Dictionary<string, decimal>>();

            var inp = Console.ReadLine();
            while (inp.ToLower() != "end")
            {
                if (!rgx.IsMatch(inp))
                {
                    inp = Console.ReadLine();
                    continue;

                }
                else
                {
                    var match = rgx.Match(inp);
                    var singer = match.Groups["singer"].Value;
                    var city = match.Groups["venue"].Value;
                    var tickets = decimal.Parse(match.Groups["tickets"].Value);
                    var price = decimal.Parse(match.Groups["price"].Value);

                    if (!dic.ContainsKey(city))
                    {
                        dic[city] = new Dictionary<string, decimal>();
                    }

                    if (!dic[city].ContainsKey(singer))
                    {
                        dic[city][singer] = 0;
                    }

                    //if (tickets <= 0)
                    //{
                    //    tickets = 1; 
                    //} else if(price <= 0)
                    //{
                    //    price = 1;
                    //} 

                   dic[city][singer] += tickets * price;
                }

                
                
                inp = Console.ReadLine();
            }

            PrintResult(dic);

        }

        private static void PrintResult(Dictionary<string, Dictionary<string, decimal>> dic)
        {
            foreach (var city in dic)
            {
                Console.WriteLine($" {city.Key}");
                foreach (var kvp in city.Value.OrderByDescending(v=>v.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
