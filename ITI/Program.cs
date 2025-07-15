using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Company;

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


        static Company.Employee[] Employees = new Employee[200];
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

            }
            else
                Console.WriteLine("No Employee Found .");

        }

        static void PrintAllEmployees()
        {
            PrintHead("Employees");

            Console.WriteLine($@"

    ID    |   Name     |    Salary    |   City   |   Hirirng Date
   _______________________________________________________________________
");


            for (int i = 0; i < CountEmp; i++)
            {
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
                    e.SetName(EditName());
                    break;

                case 2:
                    e.SetSalary(EditSalary());

                    break;

                case 3:
                    e.SetCity(EditCity());

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



        //  Lab 4

        static List<Developer> Developers = new List<Developer>();
        static List<Department> Departments = new List<Department>();
        static List<Project> Projects = new List<Project>();

        //Developer
        static Developer CreateDeveloper(int id)
        {
            Developer dev = new Developer();

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
            dev.SetID(id);
            dev.SetName(name);
            dev.SetCity(city);
            dev.SetSalary(salary);
            dev.SetHiringDate(DateTime.Now);



            return dev;

        }

        static void AddDeveloper()
        {
            Developers.Add(CreateDeveloper(Developer.GetNextID()));
            Developer.IncrementID();
        }

        static Developer GetDeveloper(int id)
        {

            foreach (Developer d in Developers)
            {
                if (d.getID() == id)
                    return d;
            }
            return null;

        }

        static void RemoveDeveloper()
        {

            int id;

            while (true)
            {
                Console.WriteLine("Enter Your ID: ");
                id = int.Parse(Console.ReadLine());

                if (isNegativeOrZero(id))
                {
                    Console.WriteLine("Invalid id!");
                    continue;

                }
                break;
            }

            Developer d = GetDeveloper(id);

            if (d != null)
            {
                Developers.Remove(d);
                Console.WriteLine($"Developer {id} removed.");
            }
            else
            {
                Console.WriteLine($"Developer {id} not found .");
            }

        }

        static void PrintDeveloper(Developer d)
        {
            if (d != null)
            {
                Console.WriteLine($@"
ID: {d.getID()}
Name: {d.getName()}    
Salary: {d.getSalary()}
City: {d.getCity()} 
Hiring Date: {d.getHiringDate()}
Max Projects Can Work On: {d.maxprojects}
");
                Console.WriteLine(@"

                                            Projects
");

                PrintProjects(GetProjects(d.ProjectIDs));

                Console.WriteLine($@"
         _______________________________________________________________________
");

            }
            else
                Console.WriteLine("No Developers Found .");

        }

        static void PrintAllDevelopers()
        {
            PrintHead("Developers");

            foreach (Developer d in Developers)
            {
                PrintDeveloper(d);
            }

        }




        //Project
        static void PrintAllProjects()
        {
            PrintHead("Projects");
            PrintProjects(Projects);
        }

        static void PrintProjects(List<Project> projects)
        {

  

            foreach (Project p in projects)
            {
                PrintProject(p);
            }

        }

        static Project GetProject(int id)
        {

            foreach (Project p in Projects)
            {
                if (p.ID == id)
                    return p;
            }

            return null;
        }

        static List<Project> GetProjects(List<int> IDs)
        {
            List<Project> temprojects = new List<Project>();
            Project p = new Project();

            foreach (int id in IDs)
            {
                p = GetProject(id);
                if (p != null)
                    temprojects.Add(p);

            }
            return temprojects;
        }

        static void PrintProject(Project p)
        {
            if (p != null)
            {
                Console.WriteLine($@"
Project ID: {p.ID}
Project Name: {p.Name}    
Max Number of Employess can work on: {p.MaxNumberOfEmployees}
Number of Employees currently work on: {p.EmployeeIDs.Count()}
   _______________________________________________________________________
");
            }
        }

        static Project CreateProject(int id)
        {
            Project proj = new Project();

            string name;
            int maxnumofemployees;


            while (true)
            {



                Console.WriteLine("Enter Name Of The Project: ");
                name = Console.ReadLine();

                if (HasDigit(name))
                {
                    Console.WriteLine("Invalid name!");
                    continue;
                }



                Console.WriteLine("Enter The Max Number Of Employees: ");
                maxnumofemployees = int.Parse(Console.ReadLine());

                if (isNegativeOrZero(maxnumofemployees))
                {
                    Console.WriteLine("Invalid Number!");
                    continue;

                }




                break;
            }
            proj.ID = id;
            proj.Name = name;
            proj.MaxNumberOfEmployees = maxnumofemployees;


            return proj;
        }
       
        static void AddProject()
        {
            Projects.Add(CreateProject(Project.GetNextID()));
            Project.IncrementID();

        }

        static void RemoveProject()
        {
            int id;

            while (true)
            {
                Console.WriteLine("Enter Your ID: ");
                id = int.Parse(Console.ReadLine());

                if (isNegativeOrZero(id))
                {
                    Console.WriteLine("Invalid id!");
                    continue;

                }
                break;
            }

            Project p= GetProject(id);

            if (p != null)
            {
                Projects.Remove(p);
                Console.WriteLine($"Project {id} removed.");
            }
            else
            {
                Console.WriteLine($"Project {id} not found .");
            }
        }






        //Department
        static Department CreateDepartment(int id)
        {
            Department dep = new Department();

            string name;
            


            while (true)
            {



                Console.WriteLine("Enter Name Of The Department: ");
                name = Console.ReadLine();

                if (HasDigit(name))
                {
                    Console.WriteLine("Invalid name!");
                    continue;
                }

                break;
            }
            dep.ID = id;
            dep.Name = name;
           
            return dep;
        }

        static void AddDepartment()
        {
            Departments.Add(CreateDepartment(Department.GetNextID()));
            Department.IncrementID();
        }

        static void PrintDepartment(Department dep)
        {
            if (dep != null)
            {
                Console.WriteLine($@"
Project ID: {dep.ID}
Project Name: {dep.Name}    
Number of Employees: {dep.EmployeeIDs.Count()}
   _______________________________________________________________________
");
            }
        } 

        static void PrintDepartments()
        {
            PrintHead("Departments");

            foreach (Department d in Departments)
            {
                PrintDepartment(d);
            }
        }

        static Department GetDepartment(int id)
        {
            foreach (Department dep in Departments)
            {
                if(dep.ID == id)
                    return dep;
            }
            return null;
        }
 
        static void RemoveDepartmnet()
        {
            int id;

            while (true)
            {
                Console.WriteLine("Enter Your ID: ");
                id = int.Parse(Console.ReadLine());

                if (isNegativeOrZero(id))
                {
                    Console.WriteLine("Invalid id!");
                    continue;

                }
                break;
            }

            Department dep = GetDepartment(id);

            if (dep != null)
            {
                Departments.Remove(dep);
                Console.WriteLine($"Department {id} removed.");
            }
            else
            {
                Console.WriteLine($"Department {id} not found .");
            }
        }





        static void ReturntoMainMenuCompany()
        {
            Console.WriteLine("Press any key to return to Main Menu ... ");
            Console.ReadKey();
            Console.Clear();

            MainMenuCompany();
        }

        static void MainMenuCompany()
        {
            PrintHead("Main Menu");
            Console.WriteLine(@"
1 - Add Developer
2 - Add Department
3 - Add Project
4 - View All Developers
5 - View All Departments
6 - View All Projects
7 - Delete Developer
8 - Delete Department
9 - Delete Project
0 - Exit
");

            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddDeveloper();
                    ReturntoMainMenuCompany();
                    break;
                case 2:
                    Console.Clear();
                     AddDepartment();
                    ReturntoMainMenuCompany();

                    break;
                case 3:
                    Console.Clear();
                     AddProject();
                    ReturntoMainMenuCompany();

                    break;
                case 4:
                    Console.Clear();
                     PrintAllDevelopers();
                    ReturntoMainMenuCompany();

                    break;
                case 5:
                    Console.Clear();
                    PrintDepartments();
                    ReturntoMainMenuCompany();

                    break;
                case 6:
                    Console.Clear();
                    PrintAllProjects();
                    ReturntoMainMenuCompany();

                    break;
                case 7:
                    Console.Clear();
                    RemoveDeveloper();
                    ReturntoMainMenuCompany();

                    break;
                case 8:
                    Console.Clear();
                    RemoveDepartmnet();
                    ReturntoMainMenuCompany();

                    break;
                case 9:
                    Console.Clear();
                    RemoveProject();
                    ReturntoMainMenuCompany();

                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid!");
                    break;
            }

            ReturntoMain();
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

            //  MainMenu();


            #endregion

            #region Lab4

            MainMenuCompany();


            #endregion

        }
    }
}
