using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace setsAndDicsExercices
{
    class Population
    {
        static void Main()
        {
            //city|country|population
            var inp = Console.ReadLine();
            var dic = new Dictionary<string, Dictionary<string, long>>();

            while (inp != "report")
            {
                var tokens = inp.Split('|');
                var city = tokens[0];
                var country = tokens[1];
                var pop = long.Parse(tokens[2]);

                if (!dic.ContainsKey(country))
                {
                    dic[country] = new Dictionary<string, long>() { {city, pop} };
                }

                if (!dic[country].ContainsKey(city))
                {
                    dic[country].Add(city, pop);
                }

               
                inp = Console.ReadLine();
            }




            foreach (var country in dic.OrderByDescending(r => r.Value.Values.Sum()))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()}) ");

                foreach (var city in country.Value.OrderByDescending(c=>c.Value)) 
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");


                }

            }


        }
    }
}
