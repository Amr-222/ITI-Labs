using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITI
{

    internal class Program
    {



        // Util
        static bool isNegativeOrZero(double num)
        {
            return (isNegative(num) || num == 0);
        }

        static bool isNegative(double num)
        {
            return (num < 0);
        }

        static bool isEven(int num)
        {
            return (num % 2 == 0);
        }

        static bool HasDigit(string text)
        {
            bool digit = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= '0' && text[i] <= '9')
                {
                    digit = true;
                    break;
                }

            }

            return digit;
        }

        static bool InRange(double num, double from, double to)
        {
            return (num >= from && num <= to);
        }



        // Lab 1
        static bool isSquare(double length, double width)
        {
            if (isNegative(length) || isNegative(width) || length == 0)
                return false;
            else
                return (length == width);

        }

        // Lab 2
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

        // Lab3


        static Employee[] Employees = new Employee[200];
        static int CountEmp = 0;

        static Employee CreateEmployee(int ID)
        {

            Employee e = new Employee();

            string name, city;
            double salary;


            while (true)
            {



                Console.WriteLine("Enter Your Name: ");
                name = Console.ReadLine();

                if (HasDigit(name))
                {
                    Console.WriteLine("Invalid name!");
                    continue;
                }

                Console.WriteLine("Enter Your City: ");
                city = Console.ReadLine();

                if (HasDigit(city))
                {
                    Console.WriteLine("Invalid city!");
                    continue;
                }

                Console.WriteLine("Enter Your Salary: ");
                salary = double.Parse(Console.ReadLine());

                if (isNegativeOrZero(salary))
                {
                    Console.WriteLine("Invalid salary!");
                    continue;

                }

                break;
            }
            e.SetID(ID);
            e.SetName(name);
            e.SetCity(city);
            e.SetSalary(salary);
            e.SetHiringDate(DateTime.Now);

            return e;

        }

        static void AddEmployee()
        {
            Employees[CountEmp] = CreateEmployee(CountEmp + 1);
            CountEmp++;
        }

        static void PrintHead(string text)
        {
            Console.WriteLine($@"
              ==========================================================================

                                             {text}

              ==========================================================================
");

        }

        static void PrintEmployee(Employee e)
        {
            if (e != null)
            {
                Console.WriteLine($@"
    {e.getID()}     |   {e.getName()}       |     {e.getSalary()}    |   {e.getCity()}  |   {e.getHiringDate()}

   _______________________________________________________________________
");

            }else
                Console.WriteLine("No Employee Found .");

        }

        static void PrintAllEmployees()
        {
            PrintHead("Employees");

            Console.WriteLine($@"

    ID    |   Name     |    Salary    |   City   |   Hirirng Date
   _______________________________________________________________________
");


           for(int i = 0; i < CountEmp; i++) {
                PrintEmployee(Employees[i]);
            }

        }

        static Employee GetEmployeeByID()
        {
            int id;

            while (true)
            {

                Console.WriteLine("Enter The ID: ");
                id = int.Parse(Console.ReadLine());

                if (isNegativeOrZero(id))
                {
                    Console.WriteLine("Invalid Number!");
                    continue;

                }
                break;
            }


            foreach (Employee e in Employees)
            {
                if (e.getID() == id)
                    return e;
            }
            return null;
        }

        static void ReturntoMain()
        {
            Console.WriteLine("Press any key to return to Main Menu ... ");
            Console.ReadKey();
            Console.Clear();

            MainMenu();
        }


        static string EditName()
        {
            string name;
            while (true)
            {



                Console.WriteLine("Enter Your Name: ");
                name = Console.ReadLine();

                if (HasDigit(name))
                {
                    Console.WriteLine("Invalid name!");
                    continue;
                }
                break;
            }
            return name;
        }

        static double EditSalary()
        {
            double salary;
            while (true)
            {
                Console.WriteLine("Enter Your Salary: ");
                salary = double.Parse(Console.ReadLine());

                if (isNegativeOrZero(salary))
                {
                    Console.WriteLine("Invalid salary!");
                    continue;

                }

                break;
            }
            return salary; 
        }

        static string EditCity()
        {
            string City;
            while (true)
            {



                Console.WriteLine("Enter Your City: ");
                City = Console.ReadLine();

                if (HasDigit(City))
                {
                    Console.WriteLine("Invalid City!");
                    continue;
                }
                break;
            }
            return City;

        }
        static void EditAll()
        {
            EditName();
            EditSalary();
            EditCity();
        }

        static void UpdateModerator(ref Employee e)
        {

            int choice;

            PrintHead("Update Choices");

            Console.WriteLine($"{1} - Update Name .");
            Console.WriteLine($"{2} - Update Salary .");
            Console.WriteLine($"{3} - Update City .");
            Console.WriteLine($"{4} - Update ALL .");


            while (true)
            {
                choice = int.Parse(Console.ReadLine());

                if (!InRange(choice, 1, 4))
                {
                    Console.WriteLine("Invalid Value ! \nPlease Enter again . \n");
                }
                break;
            }


            switch (choice)
            {
                case 1:
                    e.SetName(EditName()) ;
                    break;

                case 2:
                    e.SetSalary(EditSalary());

                    break;

                case 3:
                    e.SetCity( EditCity());

                    break;

                case 4:
                    e.SetName(EditName());
                    e.SetSalary(EditSalary());
                    e.SetCity(EditCity());
                    break;

                default:

                    Console.WriteLine("INVALID !");
                    break;






            }




        }


        static void MainManager(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddEmployee();
                    ReturntoMain();
                    break;

                case 2:
                    Console.Clear();
                    Employee e = GetEmployeeByID();
                    if (e != null)
                        UpdateModerator(ref e);
                    ReturntoMain();
                    break;

                case 3:
                    Console.Clear();
                    PrintEmployee(GetEmployeeByID());
                    ReturntoMain();
                    break;

                case 4:
                    Console.Clear();
                    PrintAllEmployees();
                    ReturntoMain();

                    break;

                default:

                    Console.WriteLine("INVALID !");
                    break;






            }
        }
        static void MainMenu()
        {

            int choice;

            PrintHead("Employees System");

            Console.WriteLine($"{1} - Add Employee .");
            Console.WriteLine($"{2} - Update Employee .");
            Console.WriteLine($"{3} - Get Employee By ID .");
            Console.WriteLine($"{4} - Get All Employees .");


            while (true)
            {
                choice = int.Parse(Console.ReadLine());

                if (!InRange(choice, 1, 4))
                {
                    Console.WriteLine("Invalid Value ! \nPlease Enter again . \n");
                }
                break;
            }


            MainManager(choice);

        }











        static void Main(string[] args)
        {

            #region Lab1

            //Console.WriteLine("1\\ " + isNegative(-5));
            //Console.WriteLine("2\\ " + isNegative(10));

            //Console.WriteLine("3\\ " + isEven(4));
            //Console.WriteLine("4\\ " + isEven(7));

            //Console.WriteLine("5\\ " + isSquare(3.5, 3.5));
            //Console.WriteLine("6\\ " + isSquare(-2, -2));
            //Console.WriteLine("7\\ " + isSquare(4, 6));
            //Console.WriteLine("8\\ " + isSquare(0, 0));
            #endregion

            #region Lab2
            //MultiplicationTable();
            //GetUserData();
            #endregion


            #region Lab3



            MainMenu();

         





            #endregion


        }
    }
}
