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
            var oddNumbers = numbers.Where(n => (n % 2 == 1));
            Console.WriteLine(string.Join(", ", oddNumbers));


            SeparatingLine();
            // 2. Select vs Where
            List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior() { Height = 100 },
                new Warrior() { Height = 80 },
                new Warrior() { Height = 100 },
                new Warrior() { Height = 70 },
            };

            // var shortWarriors = warriors.Where(h => (h.Height == 100));
            // foreach (var h in shortWarriors)
            //     Console.WriteLine($"{h.Height}");

            List<int> shortWarriors = warriors.Where(h => (h.Height == 100))
                                        .Select(h => h.Height)
                                        .ToList();

            warriors.ForEach(w => Console.WriteLine(w.Height));

            shortWarriors.ForEach(x=>Console.Write($" {x}"))

        }

        private static int[] StringToIntArray(string array)
        {
            int[] arrayFromString = array.Split(' ')
                                    .Select(element => int.Parse(element))
                                    .ToArray();

            return arrayFromString;
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }
    internal class Warrior
    {
        public int Height { get; set; }
    }


}
