using System;
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
                            where b.Age == 20
                            select p;

            foreach (var item in suppliers)
            {
                System.Console.WriteLine(item.GetType().ToString());
            }

            var supplierss = people.OfType<Buyer>().Where(x => x.Age == 20);
            foreach (var item in supplierss)
                Console.WriteLine($"{item.Age}");

            // var buyers = from p in people
            //                 where p is Buyer
            //                 let b = p as Buyer
            //                 where b.Age == 20
            //                 where b.ID < 5
            //                 where b.Height > 100
            //                 where b.Weight > 50
            //                 where b.Weight < 80
            //                 select b;


            // var buyers = from p in people
            //              where p is Buyer
            //              let b = p as Buyer
            //              where (b.Age == 20 && b.ID < 5) && (b.Height > 100 || (b.Weight > 50 && b.Weight < 80)
            //                 select b;




            //var buyers2 = people.OfType<Buyer>().Where((b.Age == 20 && b.ID < 5) && (b.Height > 100 || (b.Weight > 50 && b.Weight < 80)));
            var buyersToSuppliers = people.OfType<Buyer>().ToList().ConvertAll(b => new Supplier
            {
                Age = b.Age
            });


            var buyersToSuppliers2 = from p in people
                                     where p is Buyer
                                     let b = p as Buyer
                                     select new Supplier
                                     {
                                         Age = b.Age
                                     };
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            var numbersToString = numbers.ConvertAll(x=> x.ToString()).ToList();
            Console.WriteLine(string.Join(',',numbersToString))

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
