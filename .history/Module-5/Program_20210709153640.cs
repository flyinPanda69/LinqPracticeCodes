using System;
using System.Linq;
using System.Collections.Generic;

namespace Module_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 22, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 19, Gender.Female),
                new Person("John", "Jones", 7, 160, 22, Gender.Male),
                new Person("Samba", "TheLion", 8, 175, 23, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 23, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 23, Gender.Female)
            };
            SepartionLine();
            Console.WriteLine("Lambda-grouping");

            var simpleGrouping = people.GroupBy(p => p.Gender);
            foreach (var item in simpleGrouping)
            {
                Console.WriteLine($"Gender : {item.Key}");
                foreach (var p in item)
                {
                    Console.WriteLine($"{p.FirstName}");
                }
            }

            SepartionLine();

            //With Condition
            //var simpleGroupingCondn = people.Where(x => x.Age > 20).GroupBy(p => p.Gender);


            //AlphabeticalGroup
            var alphabeticalGroup = people.OrderBy(x => x.FirstName).GroupBy(p => p.FirstName[0]);

            foreach (var itm in alphabeticalGroup)
            {
                Console.WriteLine(itm.Key);
                foreach (var i in itm)
                {
                    Console.WriteLine($" Name : {i.FirstName}");
                }
            }

            SepartionLine();
            //Group by multiple keys

            var multipleKey = people.GroupBy(p => new { p.Age, p.Gender });

            foreach (var item in multipleKey)
            {
                Console.WriteLine($"Key: {item.Key}");
                foreach (var i in item)
                {
                    Console.WriteLine($"{i.FirstName}");
                }
            }

            //Ordering by Group

            var multipleKeyOrdered = people.GroupBy(p => new { p.Age, p.Gender }).OrderBy(x => x.Count());

            SepartionLine();
            //Grouping by Custom Keys

            List<int> arrayOfNumbers = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            var evenOrOddNumbers = arrayOfNumbers.GroupBy(n => (n % 2 == 0));

            foreach (var group in evenOrOddNumbers)
            {
                Console.WriteLine($"Key: {group.Key}");
                foreach (var i in group)
                {
                    Console.WriteLine($"{i}");
                }
            }


        }

        internal static void SepartionLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }
    internal class Person
    {
        private string firstName;
        private string lastName;
        private int id;
        private int height;
        private int age;

        private Gender gender;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public Person(string firstName, string lastName, int id, int height, int age, Gender gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.Height = height;
            this.Age = age;
            this.Gender = gender;
        }
    }

    internal enum Gender
    {
        Male,
        Female
    }
}
