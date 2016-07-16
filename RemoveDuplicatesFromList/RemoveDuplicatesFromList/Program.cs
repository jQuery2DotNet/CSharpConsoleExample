using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicatesFromList
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<List<string>>{
            new List<string>{ "1", "4", "6", "8" },
            new List<string>{ "1", "2", "6", "8" },
            new List<string>{ "9", "4", "6", "8" },
            new List<string>{ "3", "4", "5", "7" }
            };

            var result = items.RemoveDuplicates("-");

            result.ForEach(m => {
                Console.WriteLine(string.Join(",", m));
            });

            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static List<List<T>> RemoveDuplicates<T>(this List<List<T>> items, T replacedValue) where T : class
        {
            var ret = new List<List<T>>();

            items.ForEach(m => {
                var ind = items.IndexOf(m);

                if (ind == 0)
                {
                    ret.Add(items.FirstOrDefault());
                }
                else
                {
                    var prevItem = items.Skip(items.IndexOf(m) - 1).FirstOrDefault();

                    var item = new List<T>();
                    for (var a = 0; a < prevItem.Count; a++)
                    {
                        item.Add(prevItem[a] == m[a] ? replacedValue : m[a]);
                    }

                    ret.Add(item);
                }
            });

            return ret;
        }
    }
}
