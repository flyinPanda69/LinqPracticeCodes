﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace Grouping
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 21, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 43, Gender.Female),
                new Person("John", "Jones", 7, 160, 37, Gender.Female),
                new Person("Samba", "TheLion", 8, 175, 33, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 18, Gender.Female)
            };


            #region Groping - Intro & Group By Multiple Keys
            // var genderGroup = from p in people
            //                   group p by p.Gender;

            // foreach (var person in genderGroup)
            // {
            //     Console.WriteLine($"{person.Key}");

            //     foreach (var p in person)
            //         Console.WriteLine($" {p.FirstName} {p.Gender}");
            // }

            // var groupWithCondition = from p in people
            //                          where p.Age > 20
            //                          group p by p.Age;

            // foreach (var key in groupWithCondition)
            // {
            //     Console.WriteLine($"{key.Key}");
            //     foreach (var item in key)
            //     {
            //         Console.WriteLine($" {item.FirstName}");
            //     }
            // }

            // var alphabaticallyGroup = from p in people
            //                           orderby p.FirstName
            //                           group p by p.FirstName[0];

            // foreach (var key in alphabaticallyGroup)
            // {
            //     Console.WriteLine($"{key.Key}");
            //     foreach (var item in key)
            //     {
            //         Console.WriteLine($" {item.Age} {item.FirstName}");
            //     }
            // }

            // //Order by multiple key
            // var multipleKey = from p in people
            //                   group p by new { p.Gender, p.Age };

            // // foreach (var key in multipleKey)
            // // {
            // //     Console.WriteLine($"{key.Key}");
            // //     foreach (var item in key)
            // //     {
            // //         Console.WriteLine($" {item.FirstName}");
            // //     }
            // // }

            // Console.WriteLine(new string('-', 40));

            // var orderedKeys = from p in multipleKey
            //                   orderby p.Count()
            //                   select p;


            // foreach (var key in orderedKeys)
            // {
            //     Console.WriteLine($"{key.Key.Gender}, {key.Key.Age}");
            //     foreach (var item in key)
            //     {
            //         Console.WriteLine($" {item.FirstName}");
            //     }
            // }

            #endregion

            #region Extend a Group Query with Into
            var peoplebyAge = from p in people
                              group p by p.Age into ageGroup
                              orderby ageGroup.Key
                              select ageGroup;

            foreach (var key in peoplebyAge)
            {
                Console.WriteLine($"Age :{key.Key}");
                foreach (var item in key)
                {
                    Console.WriteLine($" {item.Age}");
                }
            }


            // var multipleKeys = from p in people
            //                     group p by new {p.Gender, p.Age} into multiKeyGroup
            //                     orderby multiKeyGroup.Count()
            //                     select multiKeyGroup;

            int[] arrayOfNumbers = { 5, 6, 3, 1, 7, 45, 23, 12, 8, 9, 75, 10, 21, 22 };

            var evenOrOddNumbers = from n in arrayOfNumbers
                                   orderby n
                                   let evenOrodd = (n % 2 == 0) ? "T" : "F"
                                   group n by evenOrodd into nums
                                   orderby nums.Count()
                                   select nums;

            foreach (var key in evenOrOddNumbers)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var item in key)
                    Console.WriteLine($" {item}");
            };


            var clasifiedPeople = from p in people
                                  let category = p.Age < 20 ? "Young" : (p.Age > 20 && p.Age < 40) ? "Adult" : "Old"
                                  group p by category;

            foreach (var key in clasifiedPeople)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var item in key)
                    Console.WriteLine($" {item.FirstName}  {item.Age}");
            };


            var howManyEachGroup = from p in people
                                   group p by p.Gender into g
                                   select new { Gender = g.Key, NumOfPeople = g.Count() };


            foreach (var item in howManyEachGroup)
            {
                Console.WriteLine($"{item.Gender}");
                Console.WriteLine($"{item.NumOfPeople}");
            }


            var howManyEachGroup = from p in people
                                   group p by p.FirstName[0] into g
                                   select new { Gender = g.Key, NumOfPeople = g.Count() };

                                
            #endregion
        }
    }

    internal class YoungPerson
    {
        public string FullName { get; set; }
        public int Age { get; set; }
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
