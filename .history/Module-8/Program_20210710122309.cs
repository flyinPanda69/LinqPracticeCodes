using System;
using System.Linq;
using System.Collections.Generic;

namespace Module_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var manyNumbers = Enumerable.Repeat(5, 50); 
            var numbers = Enumerable.Range(1,10).Where(x=>x%2 ==0);

            var squared = Enumerable.Range(1,10).Select(x=> x*x);

            var squared = from n in Enumerable.Range()
        }
    }
}
