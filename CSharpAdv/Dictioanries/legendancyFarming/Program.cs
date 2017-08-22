using System;
using System.Collections.Generic;
using System.Linq;


namespace legendancyFarming
{
    class Program
    {
        static void Main()
        {
          
            var keyMats = new Dictionary<string, int>();
            var junk = new SortedDictionary<string, int>();
            var qty=0;
            var name = "";
            bool noTimeToPrint = true;

            var input = Console.ReadLine();
            while (noTimeToPrint)
            {
                var tokens = input.Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tokens.Length; i++)
                {
                    var mat = "";
                   

                    if (i % 2 == 0)
                    {
                        
                        qty = int.Parse(tokens[i]);
                    }
                    else
                    {
                        mat = tokens[i].ToLower();
                       
                    }

                  
                    if (mat == "motes" || mat == "fragments" || mat == "shards")
                    {
                        if (!keyMats.ContainsKey(mat))
                        {
                            if (qty  >= 250) //oshte ot 1via put proveriavame
                            {
                               name = mat;
                          
                                keyMats[mat] = qty - 250;
                              
                                noTimeToPrint = PrintResult(name, keyMats, junk);
                               
                            }
                            else
                            {
                                keyMats[mat] = qty;
                            }
                           
                        }
                        else
                        {
                            if ((keyMats[mat]+qty) >= 250)
                            {
                              
                                 name = mat;
                                var currentVal = keyMats[mat];
                                keyMats[mat] = (currentVal + qty) -250;
                             
                                noTimeToPrint = PrintResult(name, keyMats, junk);
                                
                            }
                            else
                            {
                                keyMats[mat] += qty;
                            }

                        }
                    }
                    else if (mat == "")
                    {
                        continue;
                    } 
                    else
                    {
                        if (!junk.ContainsKey(mat))
                        {
                            junk[mat] = qty;
                        }
                        else
                        {
                            junk[mat] += qty;
                           
                        }
                    } //end if

                    if (!noTimeToPrint)
                    {
                        break;
                    }

                } //end for


                if (noTimeToPrint)
                {
                    input = Console.ReadLine();
                }
               
            } //end while

           

        }

       

        private static bool PrintResult(string name, Dictionary<string, int> keyMats, SortedDictionary<string, int> junk)
        {
            if (keyMats.Keys.Count < 3)
            {
                if (!keyMats.ContainsKey("shards"))
                {
                    keyMats["shards"] = 0;
                }

                if (!keyMats.ContainsKey("fragments"))
                {
                    keyMats["fragments"] = 0;
                }
                if (!keyMats.ContainsKey("motes"))
                {
                    keyMats["motes"] = 0;
                }
            }


            var legendaryName = "";
            switch (name.ToLower())
            {
                case "shards":
                    legendaryName = "Shadowmourne";
                    break;
                case "fragments":
                     legendaryName = "Valanyr";
                    break;
                case "motes":
                     legendaryName = "Dragonwrath";
                    break;

            }
          Console.WriteLine($"{legendaryName} obtained!");
            foreach (var mats in keyMats.OrderByDescending(m=>m.Value).ThenBy(k=>k.Key))
            {
               
                    Console.WriteLine($"{mats.Key.ToLower()}: {mats.Value}");
              
               
            }

            foreach (var mats in junk)
            {
                Console.WriteLine($"{mats.Key.ToLower()}: {mats.Value}");
            }
         
            return false;
        }
    }
}
