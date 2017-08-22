using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAgregator
{
    class Program
    {
        static void Main()
        {
            //{IP} {user} {duration}
            var dic = new SortedDictionary<string, SortedDictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                string ip = input[0];
                string name = input[1];
                int duration = int.Parse(input[2]);

                if (!dic.ContainsKey(name))
                {
                    dic[name] = new SortedDictionary<string, int>();
                }

                if (!dic[name].ContainsKey(ip))
                {
                    dic[name][ip] = duration;
                    continue;
                }

                dic[name][ip] += duration;
            }


            foreach (var name in dic)
            {
                Console.Write($"{name.Key}: ");
                var sum = name.Value.Values.Sum();
                
                var ips = name.Value.Keys.ToArray();
                Console.WriteLine(sum + " [" + string.Join(", ", ips)+"]");
            
               // foreach (var kvp in name.Value)
               // {
                    
                  //  Console.WriteLine($"{kvp.Value} [{kvp.Key}]");
              //  }
            }
            
        }
    }
}
