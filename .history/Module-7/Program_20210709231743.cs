﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace Module_7
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] mix = { 1, "string", 'd', new List<int>() { 1, 2, 3, 4, 5, 63, 45, 2 }, new List<int>() { 5, 3, 4 }, "dd", "etc", 1, 2, 3, 4 };

            var allInteger = mix.OfType<int>();

            Console.WriteLine(string.Join(", ", allInteger));

            List<Person> people = new List<Person>()
            {
                new Buyer() { Age = 20 , ID = 1, Height = 125, Weight = 77},
                new Buyer() { Age = 25 , ID = 2, Height = 150, Weight = 88},
                new Buyer() { Age = 20 , ID = 5, Height = 100, Weight = 58},
                new Supplier() { Age = 22 },
                new Supplier() { Age = 20 }
            };

            var suppliers = from p in people
                            where p is Buyer
                            let b = p as Buyer
                            where (p as Buyer).Age == 20
                            select p;

            foreach (var item in suppliers)
            {
                System.Console.WriteLine(item.GetType().ToString());
            }
        }
    }
    internal class Person
    {

    }

    internal class Buyer : Person
    {
        public int Age { get; set; }
        public int ID { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    internal class Supplier : Person
    {
        public int Age { get; set; }
    }
}
