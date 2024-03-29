﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace Module_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "Scientists District", Age = 40 },
                new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22 },
                new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30 },
                new Buyer() { Name = "Jaime", District = "Developers District", Age = 35 },
                new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40 }
            };
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", District = "Fantasy District", Age = 22 },
                new Supplier() { Name = "Charles", District = "Developers District", Age = 40 },
                new Supplier() { Name = "Hailee", District = "Scientists District", Age = 35 },
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District", Age = 30 }
            };

            //----------------------------------------------
            SeparatingLine();
            // 01. Simple Inner Join, just selecting properties
            var innerJoin = suppliers.Join(buyers, s => s.District, b => b.District, (s, b) => new
            {
                SupplierName = s.Name,
                BuyerName = b.Name,
                District = s.District
            });

            foreach (var item in innerJoin)
            {
                Console.WriteLine($"District : {item.District} , SupplierName : {item.SupplierName} , BuyerName = {item.BuyerName}");
            }

            SeparatingLine();
            // 02. Join on multiple keys, Composite Join
            var CompositeJoin = suppliers.Join(buyers,
                    s => new { s.District, s.Age },
                    b => new { b.District, b.Age },
                    (s, b) => new
                    {
                        SupplierName = s.Name,
                        BuyerName = b.Name,
                        District = s.District,
                        Age = s.Age
                    }
                    );

            foreach (var item in CompositeJoin)
            {
                Console.WriteLine($"District : {item.District} , Age : {item.Age}");
                Console.WriteLine($"SupplierName : {item.SupplierName} , BuyerName = {item.BuyerName}");
            }

            SeparatingLine();
            // 03. Group Join 
            var groupJoin = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
                                (s, buyersGroup) => new
                                {
                                    s.Name,
                                    s.District,
                                    Buyers = buyersGroup.OrderBy(x => x.Name)
                                });

            foreach (var supplier in groupJoin)
            {
                Console.WriteLine($"Supplier : {supplier.Name}, District :{ supplier.District}");

                foreach (var item in supplier.Buyers)
                {
                    Console.WriteLine($"{item.Name}");
                }
            }

            SeparatingLine();
            // 03. Left outer join

            var leftOuterJoin = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
                                (s, buyersGroup) => new
                                {
                                    s.Name,
                                    s.District,
                                    Buyers = buyersGroup.OrderBy(x => x.Name)
                                }).SelectMany(s => s.Buyers.DefaultIfEmpty(), (s, b) =>
                                new
                                {
                                    s.Name,
                                    s.District,
                                    BuyersName = b?.Name ?? "No Name",
                                    BuyersDistrict = b?.District ?? "No place"
                                });
            foreach (var item in leftOuterJoin)
            {
                Console.WriteLine($"{item.District}");
                Console.WriteLine($"{item.Name} - {item.BuyersName}");
            }


            var leftOuterType = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
                                (s, buyersGroup) => new
                                {
                                    s.Name,
                                    s.District,
                                    Buyers = buyersGroup.DefaultIfEmpty(new Buyer()
                                    {
                                        Name = "No Name",
                                        District = "No Place"
                                    })
                                });

            foreach (var supplier in leftOuterType)
            {
                Console.WriteLine($"{supplier.Name}, {supplier.District}");

                foreach (var buyer in supplier.Buyers)
                {
                    System.Console.WriteLine($"{buyer.Name}");
                }
            }
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }

    internal class Supplier
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
    }

    internal class Buyer
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
    }
}
