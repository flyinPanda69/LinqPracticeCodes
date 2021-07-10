using System;
using System.Linq;
using System.Collections.Generic;

namespace Module_3
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
                new Buyer() { Name = "Joshua", District = "EarthIsFlat District", Age = 40 },
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

            var innerJoin = from s in suppliers
                            join b in buyers on s.District equals b.District
                            select new
                            {
                                SupplierName = s.Name,
                                BuyerName = b.Name,
                                b.District,
                            };
            foreach (var item in innerJoin)
                Console.WriteLine($"District : {item.District}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}");

            var compositeJoin = from s in suppliers
                                join b in buyers on new {s.District , s.Age} equals new {b.District, b.Age}
                                select new {
                                    Supplier = s,
                                    BuyerName = b.Name
                                };

            foreach (var item in compositeJoin)
                Console.WriteLine($"District : {item.Supplier.District}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}");



        }
    }

    internal class Buyer
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
    }

    internal class Supplier
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
    }
}
