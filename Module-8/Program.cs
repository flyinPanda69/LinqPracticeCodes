﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace Module_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var manyNumbers = Enumerable.Repeat(5, 50);
            var numbers = Enumerable.Range(1, 10).Where(x => x % 2 == 0);

            var squared = Enumerable.Range(1, 10).Select(x => x * x);

            var squared2 = from n in Enumerable.Range(1, 10)
                           select n * n;


            Random rng = new Random();

            var randoms = Enumerable.Range(1, 10).Select(_ => rng.Next(1, 100));

            var alphabet = Enumerable.Range(0, 26).Select(c => (char)(c + 'a'));

            var fontSize = Enumerable.Range(1, 0).Select(i => (i * 10) + "pt");


            string st1 = "I am a cat";
            string st2 = "I am a dog";
            List<int> int1 = List<int>() { 1,2,3,34,12,23,3,2,1,23,3,4,34,5,6,1};

            var distinct = st1.Distinct();
            var distNumber = int1.Distinct();

            var intersect = st1.Intersect(st2);

            var union = st1.Union(st2);

            var except = st1.Except(st2);


            int[] ints2 = int1.Skip().ToArray();

            int[] ints3 = int1.Take(5).ToArray()
            //int1.Skip(5).Take(5).ToArray();


            //Taking highest 3
            int[] Top3 = int1.OrderByDescending(i => i).Take(3).ToArray();

            int[] instskipwhile = int1.SkipWhile(x => x < 5).ToArray();

            int[] insttakeWhile = int1.TakeWhile(i => i < 8).ToArray();

            var all = int1.All(i => i > 5);

            var any = int1.Any(c => c == 5);
            //empty.any();
            //int1.any();


            //Take the array square the second half while keeping the first half as it is
            var intsconcat = int1.Take(int1.Length / 2).Concat(int1.Skip(int1.Length / 2).Select(i => i * i)).ToArray();


            var intSum = int1.Aggregate((p, i) => p + i);


            int p = 0;
            for (int i = 0; i < int1.Length; i++)
            {
                p = p + int1[i];
            }

            int intSum1 = int1.Aggregate(1,(p,i) => p*i);

            //int1.Sum();
            //Average();
            //Min()
            //Max()
        }
    }
}
