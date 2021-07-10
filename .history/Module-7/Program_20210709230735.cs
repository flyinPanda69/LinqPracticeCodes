using System;
using System.Linq;

namespace Module_7
{
    class Program
    {
        static void Main(string[] args)
        {
            object [] mix = {1,"string", 'd', new List<int>() {1,2,3,4,5,63,45,2}, new List<int> {5,3,4},"dd" ,"etc" };

            var allInteger = mix.OfType<int>();

            Console.WriteLine(string.Join(", allInteger))
        }
    }
}
