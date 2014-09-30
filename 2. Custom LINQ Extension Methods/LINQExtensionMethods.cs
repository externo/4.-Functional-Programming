using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Custom_LINQ_Extension_Methods
{
    static class LINQExtensionMethods
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            var i = ints.Repeat(13);
            foreach (var item in i)
            {
                Console.WriteLine(item);
            }
            var c = ints.WhereNot(x => x % 2 == 0);
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }

            List<string> towns = new List<string> { "Sofia", "Varna", "Pleven", "Ruse", "Bourgas" };
            var suffixes = new[] {"a", "n"};
            var atowns = towns.WhereEndsWith(suffixes);
            foreach (var item in atowns)
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate) 
        {
            return from c in collection
                   where !predicate(c)
                   select c;
        } 

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count) 
        {
            var result = collection.ToList();
            for (int i = 1; i < count; i++)
			{
                var temp = from c in collection
                           select c;
                result.AddRange(temp);
			}
            return result;
        } 

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes) 
        {
            return from c in collection
                   from s in suffixes                   
                   where c.EndsWith(s)
                   select c;
        } 
    }
}
