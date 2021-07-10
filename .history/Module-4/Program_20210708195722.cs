using System;
using System.Linq;
using System.Collections.Generic;

namespace Module_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            List<int> numbers = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };
            object[] mix = { 1, "string", 'd', new List<int>() { 1, 2, 3, 4 }, new List<int>() { 5, 2, 3, 4 }, "dd", 's', "Hello Kitty", 1, 2, 3, 4, };

            SeparatingLine();

            var oddNos = from n in numbers
                         where (n % 2 != 0)
                         select n;

            Console.WriteLine(string.Join(", ", oddNos));

            //Extracting odd numbers with lambda
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }


}
