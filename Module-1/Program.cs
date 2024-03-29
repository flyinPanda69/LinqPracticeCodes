﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace vsc
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "I love mountains";
            string[] mountainNames = { "Nanda Ghunti", "Trishul", "Everest", "Alps", "Annapurna", "Nanda devi", "K2" };
            int[] numbers = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };


            var getTheNumbers = from number in numbers
                                where number < 5
                                select number;

            List<int> newNumbers = new List<int>();

            // foreach (var n in numbers)
            // {
            //     if (n < 5)
            //     {
            //         newNumbers.Add(n);
            //     }
            // }

            //Simple Linq Example


            #region Lecture 2 - Where, Select, Sorting, Multiple Conditions

            var mNamesWithA = from name in mountainNames
                              where name.Contains("a") && (name.Length > 5)
                              orderby name
                              select name;

            //Console.WriteLine(string.Join(", ", mNamesWithA));
            #endregion


            #region Object example

            // List<Person> people = new List<Person>()
            // {
            //     new Person("Tod", 180, 70, Gender.Male),
            //     new Person("John", 170, 88, Gender.Male),
            //     new Person("Anna", 150, 48, Gender.Female),
            //     new Person("Kyle", 164, 77, Gender.Male),
            //     new Person("Anna", 164, 77, Gender.Male),
            //     new Person("Maria", 160, 55, Gender.Female),
            //     new Person("John", 160, 55, Gender.Female)
            // };


            // // var fourCharPeople = from p in people
            // //                      where (p.Name.Length == 4)
            // //                      orderby p.Weight
            // //                      select p;

            // // foreach (var item in fourCharPeople)
            // // {
            // //     Console.WriteLine($"Name : {item.Name}, Weight : {item.Weight}");
            // // }

            // var fourCharPeople = from p in people
            //                      where (p.Name.Length == 4)
            //                      orderby p.Name descending, p.Height
            //                      select p.Name;

            // foreach (var item in fourCharPeople)
            // {
            //     Console.WriteLine($"Name : {item}");
            // }
            #endregion

            #region Creating/Extracting New Objects with Linq Queries
            // Person class has been modified


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

            var youngPeople = from p in people
                              where p.Age < 25
                              select new { Name = p.FirstName, p.Age };
            //select new { p.FirstName, Age = p.Age};
            foreach (var p in youngPeople)
                Console.WriteLine($"{p.Name} is {p.Age} years old");

            var youngPeopleObj = from p in people
                                 where p.Age < 25
                                 select new YoungPerson
                                 {
                                     FullName = $"{p.FirstName} {p.LastName}",
                                     Age = p.Age
                                 };

            // foreach (var x in youngPeopleObj)
            //     Console.WriteLine($"{x.FullName} is {x.Age} years old");



            //Let example
            var peopleWithA = from p in people
                              let firstCharacter = p.FirstName.ToLower()[0]
                              where firstCharacter == 'a'
                              let fullName = string.Format($"{p.FirstName} {p.LastName}")
                              select new YoungPerson
                              {
                                  FullName = fullName,
                                  Age = p.Age
                              };

            foreach (var y in peopleWithA)
                Console.WriteLine(y.FullName);



            List<List<int>> lists = new List<List<int>>(){
                new List<int>() {1,2,3},
                new List<int>() {4,5,6},
                new List<int>() {7,8,9}
            };

            // var allNumbers = from l in lists
            //                  let num = l
            //                  from n in num
            //                  select n;

            var allNumbers = from l in lists
                             from n in l
                             let val = n * n
                             where val < 50
                             select val;

            foreach (var n in allNumbers)
                Console.WriteLine(n);

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
