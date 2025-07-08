using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI
{
    internal class Program
    {

        static bool isNegative(double num)
        {
            return (num < 0);

        }

        static bool isEven(int num)
        {
            return (num % 2 == 0);
        }


        static bool isSquare(double length, double width)
        {
            if (isNegative(length) || isNegative(width) || length == 0)
                return false;
            else
                return (length == width);

        }

        static void Main(string[] args)
        {


            Console.WriteLine("1\\ " + isNegative(-5));
            Console.WriteLine("2\\ " + isNegative(10));

            Console.WriteLine("3\\ " + isEven(4));
            Console.WriteLine("4\\ " + isEven(7));

            Console.WriteLine("5\\ " + isSquare(3.5, 3.5));
            Console.WriteLine("6\\ " + isSquare(-2, -2));
            Console.WriteLine("7\\ " + isSquare(4, 6));
            Console.WriteLine("8\\ " + isSquare(0, 0));


           

        }
    }
}
