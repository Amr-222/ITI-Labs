using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        static void MultiplicationTable()
        {
            for (int i = 1; i <= 12; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");

                }
            }
        }

        static bool HasDigit(string text)
        {
            bool digit = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] > '0' && text[i] < '9')
                {
                    digit = true;
                    break;
                }

            }

            return digit;
        }

        static void GetUserData()
        {
            int ID, Age;
            string Name;
            double Salary;

            bool flag = false;

            do
            {
                if (flag)
                    Console.WriteLine("\nInvalid Input! \nPlease Enter Again.\n");

                flag = false;

                Console.WriteLine("Enter Your ID: ");
                ID = int.Parse(Console.ReadLine());

                if (isNegative(ID))
                {
                    flag = true;
                    continue;

                }

                Console.WriteLine("Enter Your Name: ");
                Name = Console.ReadLine();

                if (HasDigit(Name))
                {
                    flag = true;
                    continue;
                }

                Console.WriteLine("Enter Your Age: ");
                Age = int.Parse(Console.ReadLine());

                if (isNegative(Age))
                {
                    flag = true;
                    continue;

                }

                Console.WriteLine("Enter Your Salary: ");
                Salary = double.Parse(Console.ReadLine());

                if (isNegative(Salary))
                {
                    flag = true;
                    continue;

                }


            } while (flag);


            //Degrees

            int size;
            int max = -1, min = 999;
            Console.WriteLine("How many degrees do you have?");
            size = int.Parse(Console.ReadLine());

            int[] Degrees = new int[size];

            for (int i = 0; i < size; i++)
            {
                Degrees[i] = int.Parse(Console.ReadLine());

                if (isNegative(Degrees[i]))
                {
                    Console.WriteLine("Invalid Input!");
                    return;
                }

                if (Degrees[i] > max)
                    max = Degrees[i];
                if (Degrees[i] < min)
                    min = Degrees[i];

            }

            Console.WriteLine($@"

The Max Degree: {max}

The Min Degree: {min}


");



        }









        static void Main(string[] args)
        {


            //Console.WriteLine("1\\ " + isNegative(-5));
            //Console.WriteLine("2\\ " + isNegative(10));

            //Console.WriteLine("3\\ " + isEven(4));
            //Console.WriteLine("4\\ " + isEven(7));

            //Console.WriteLine("5\\ " + isSquare(3.5, 3.5));
            //Console.WriteLine("6\\ " + isSquare(-2, -2));
            //Console.WriteLine("7\\ " + isSquare(4, 6));
            //Console.WriteLine("8\\ " + isSquare(0, 0));

  

            MultiplicationTable();
            GetUserData();



      
        }
    }
}
