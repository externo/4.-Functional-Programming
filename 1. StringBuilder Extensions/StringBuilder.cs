using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.StringBuilder_Extensions
{
    public static class StringBuilder
    {
        public static string Substring(this string str, int startIndex, int length) 
        {
            try
            {
                return str.Substring(startIndex, length);
            }
            catch (IndexOutOfRangeException)
            {                
                throw new IndexOutOfRangeException("invalid range");
            }
        }

        public static string RemoveText(this string str, string text)
        {
            return str.Replace(text, "");
        }

        public static string AppendAll<T>(this string str, IEnumerable<T> items) 
        {
            foreach (var item in items)
            {
                str += item.ToString();
            }
            return str;
        }
    }

    class Demo
    {
        static void Main(string[] args)
        {
            string s = "Hello Extension Methods";
            string i = s.Substring(2, 6);
            Console.WriteLine(i);
            string a = s.RemoveText("o");
            Console.WriteLine(a);

            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(ints.ToString());
            string b = s.AppendAll<int>(ints);
            Console.WriteLine(b);
        }
    }
}
