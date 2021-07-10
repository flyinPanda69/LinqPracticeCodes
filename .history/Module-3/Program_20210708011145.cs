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
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District", Age = 30 },
                new Supplier() { Name = "Jane Doe", District = "District 99", Age = 30 },
            };


            #region Inner Join and Composite Join

            // var innerJoin = from s in suppliers
            //                 join b in buyers on s.District equals b.District
            //                 select new
            //                 {
            //                     SupplierName = s.Name,
            //                     BuyerName = b.Name,
            //                     b.District,
            //                 };
            //foreach (var item in innerJoin)
            //Console.WriteLine($"District : {item.District}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}");

            // var compositeJoin = from s in suppliers
            //                     join b in buyers on new { s.District, s.Age } equals new { b.District, b.Age }
            //                     select new
            //                     {
            //                         Supplier = s,
            //                         BuyerName = b.Name
            //                     };

            // foreach (var item in compositeJoin)
            // {
            //     Console.WriteLine($"District : {item.Supplier.District}, Age: {item.Supplier.Age}");
            //     Console.WriteLine($"Supplier : {item.Supplier.Name}");
            //     Console.WriteLine($"Buyer : {item.BuyerName}");
            // }
            #endregion

            #region Group Join
            // var groupJoin = from s in suppliers
            //                 join b in buyers on s.District equals b.District into buyersGroup
            //                 select new
            //                 {
            //                     s.Name,
            //                     s.District,
            //                     Buyers = buyersGroup
            //                 };

            // foreach (var item in groupJoin)
            // {
            //     Console.WriteLine($"Supplier : {item.Name}, District: {item.District}");
            //     foreach (var i in item.Buyers)
            //     {
            //         Console.WriteLine($"BuyerName : {i.Name}, District : {i.District}");
            //     }
            // }
            #endregion

            #region Group inner join
            // var groupInnerJoin = from s in suppliers
            //                      join b in buyers on s.District equals b.District into buyersGroup
            //                      select new
            //                      {
            //                          s.Name,
            //                          s.District,
            //                          Buyers = from x in buyersGroup
            //                                   orderby x.Age
            //                                   select x
            //                      };
            // foreach (var item in groupInnerJoin)
            // {
            //     Console.WriteLine($"Supplier : {item.Name}, District: {item.District}");
            //     foreach (var i in item.Buyers)
            //     {
            //         Console.WriteLine($"BuyerName : {i.Name}, District : {i.Age}");
            //     }
            // }
            #endregion

            #region Left Outer Join

            var leftOuterJoin = from s in suppliers
                                join b in buyers on s.District equals b.District into buyersGroup
                                select new
                                {
                                    s.Name,
                                    s.District,
                                    Buyers = buyersGroup.DefaultIfEmpty(
                                    new Buyer()
                                    {
                                        Name = "John Doe",
                                        District = "JDPur"
                                    }
                                )
                                };

            foreach (var item in leftOuterJoin)
            {
                Console.WriteLine($"{item.Name} {item.District}");
                foreach (var buyer in item.Buyers)
                {
                    Console.WriteLine($"  {buyer.District} {buyer.Name}");
                }
            }
            #endregion
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
