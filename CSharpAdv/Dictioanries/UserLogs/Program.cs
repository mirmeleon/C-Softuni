using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new SortedDictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                var tokens = input.Split(' ');
                var ip = tokens[0].Replace("IP=", "");
                var user = tokens[2].Replace("user=", "");

                makeDict(ip, user, users);


                input = Console.ReadLine();
            }

            foreach (var user in users)
            {


                Console.WriteLine($"{user.Key}:");
                Console.WriteLine("{0}.", string.Join(", ",
                    user.Value.Select(a => $"{a.Key} => {a.Value}")));
            }

        }

        public static SortedDictionary<string, Dictionary<string, int>> makeDict(string ip, string user, SortedDictionary<string, Dictionary<string, int>> users)
        {
            //var users = new Dictionary<string, Dictionary<string, int>>();
            if (!users.ContainsKey(user))
            {
                //ako niama 1via dic
                users[user] = new Dictionary<string, int>() { { ip, 1 } };
            }
            else
            {
                if (!users[user].ContainsKey(ip))
                {
                    users[user].Add(ip, 1);
                    //ili taka
                    // users[user][ip] = 1;
                }
                else
                {
                    users[user][ip]++;
                }
            }

            return users;
        }
    
    }
}
