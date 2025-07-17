using Company;
using DataStructure;

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


        static Company.Employee[] Employees = new Employee[1];
        static int CountEmp = 0;

  /*     Turned Abstract
        
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
 */

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



                Console.WriteLine("Enter The Name: ");
                name = Console.ReadLine();

                if (HasDigit(name))
                {
                    Console.WriteLine("Invalid Name!");
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
               //     AddEmployee();   Abstract
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



        //  Lab 4 & 5 

        static List<Developer> Developers = new List<Developer>();
        static List<Department> Departments = new List<Department>();
        static List<Project> Projects = new List<Project>();

        enum MainChoices { enDevelopers = 1, enDepartments, enProjects, enExit }
        enum DevOperations { enAdd = 1, enUpdate, enDelete, enView, enAssigntoDep, enMain }
        enum DepOperations { enAdd = 1, enUpdate, enDelete, enView, enAssign , enRemove, enMain }
        enum ProjOperations { enAdd = 1, enUpdate, enDelete, enView, enAssign, enRemove, enMain }


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

        static Developer GetDeveloper()
        {
            
                int id;

                while (true)
                {

                    Console.WriteLine("Enter The Developer ID: ");
                    id = int.Parse(Console.ReadLine());

                    if (isNegativeOrZero(id))
                    {
                        Console.WriteLine("Invalid Number!");
                        continue;

                    }
                    break;
                }


                foreach (Developer dev in Developers)
                {
                    if (dev.getID() == id)
                        return dev;
                }
                return null;
            
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

        static void DeletDeveloper()
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


                for (int i = 0; i < Developers.Count; i++) // Re arrange the IDs from First
                {
                    Developers[i].SetID(i + 1);
                }
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
City: {d.getCity()} 
Department ID: {d.DepartmentID}
Max Projects Can Work On: {d.maxprojects}
Currently Works On: {d.ProjectIDs.Count()}
Salary: {d.getSalary()}
Bonus: {d.getBonus()*100}%
Total Salary: {d.GetTotalSalary()}
Hiring Date: {d.getHiringDate()}
");
                
                    Console.WriteLine(@"

                                            Projects
");
                if (d.ProjectIDs.Count() == 0)
                    Console.WriteLine("No Projects Yet .\n");

                PrintProjects(GetProjects(d.ProjectIDs), true);

                

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

        static int EditMaxNumber()
        {
            int max;
            while (true)
            {
                Console.WriteLine("Enter The Max Number : ");
                max = int.Parse(Console.ReadLine());

                if (isNegativeOrZero(max))
                {
                    Console.WriteLine("Invalid Number!");
                    continue;

                }

                break;
            }
            return max;
        }

        static void DeveloperToDepartment(bool assign) // if not assign it is remove
        {
            Developer dev2 = GetDeveloper();
            Department dep2 = GetDepartment();
            if (dev2 != null && dep2 != null)
            {
                if (assign)
                {
                    if (dep2.AssignEmployee(dev2.getID()))
                        dev2.DepartmentID = dep2.ID;
                }
                else
                {
                    if (dep2.RemoveEmployee(dev2.getID()))
                        dev2.DepartmentID = 0;
                }
            }
            else
                Console.WriteLine("Not Found");

        }
       
        static void DeveloperToProject(bool assign)
        {
            Developer dev = GetDeveloper();
            Project proj = GetProject();
            if (dev != null && proj != null)
            {
                
                if (assign)
                {
                    if (dev.AssignProject(proj.ID))
                        proj.AssignEmployee(dev.getID());
                }
                else
                {
                    if (dev.RemoveProject(proj.ID))
                        proj.RemoveEmployee(dev.getID());
                }
            }
            else
                Console.WriteLine("Not Found");
        }


        //Project
        static void PrintAllProjects()
        {
            PrintHead("Projects");
            PrintProjects(Projects);
        }

        static void PrintProjects(List<Project> projects, bool dev = false)
        {

            if (dev)
            {
                foreach (Project p in projects)
                {
                    PrintProjectsOfDeveloper(p);
                }

            }
            else
            {
                foreach (Project p in projects)
                {
                    PrintProject(p);
                }
            }

        }

        static Project GetProject()
        {
            int id;

            while (true)
            {
                Console.WriteLine("Enter Project ID: ");
                id = int.Parse(Console.ReadLine());

                if (isNegativeOrZero(id))
                {
                    Console.WriteLine("Invalid id!");
                    continue;

                }
                break;
            }

            foreach (Project p in Projects)
            {
                if (p.ID == id)
                    return p;
            }

            return null;
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

        static void PrintProjectsOfDeveloper(Project p)
        {
            Console.WriteLine($@"
    _______________________________________________________________________

Project ID: {p.ID}
Project Name: {p.Name}    
     _______________________________________________________________________
");
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

        static void DeletProject()
        {
            int id;

            while (true)
            {
                Console.WriteLine("Enter Project ID: ");
                id = int.Parse(Console.ReadLine());

                if (isNegativeOrZero(id))
                {
                    Console.WriteLine("Invalid id!");
                    continue;

                }
                break;
            }

            Project p = GetProject(id);

            if (p != null)
            {
                foreach(Developer dev in Developers)
                {
                    dev.RemoveProject(p.ID);
                }

                Projects.Remove(p);
                Console.WriteLine($"Project {id} removed.");

                for (int i = 0; i < Projects.Count; i++) // Re arrange the IDs from First
                {
                    Projects[i].ID = i + 1;
                }

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
Manager ID: {dep.ManagerID}
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
                if (dep.ID == id)
                    return dep;
            }
            return null;
        }

        static Department GetDepartment()
        {
            int id;

            while (true)
            {
                Console.WriteLine("Enter Department ID: ");
                id = int.Parse(Console.ReadLine());

                if (isNegativeOrZero(id))
                {
                    Console.WriteLine("Invalid id!");
                    continue;

                }
                break;
            }
            foreach (Department dep in Departments)
            {
                if (dep.ID == id)
                    return dep;
            }
            return null;

        }

        static void DeletDepartmnet()
        {
            int id;

            while (true)
            {
                Console.WriteLine("Enter Department ID: ");
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
                foreach (Developer dev in Developers)
                {

                    if (dev.DepartmentID == dep.ID)
                    {
                        dev.DepartmentID = 0;
                        dev.isManager = false;
                    }

                }


                Departments.Remove(dep);
                Console.WriteLine($"Department {id} removed.");

                for (int i = 0; i < Departments.Count; i++) // Re arrange the IDs from First
                {
                    Departments[i].ID = i + 1;
                }
            }
            else
            {
                Console.WriteLine($"Department {id} not found .");
            }
        }

        static int EditID()
        {
            int ID;
            while (true)
            {
                Console.WriteLine("Enter The ID: ");
                ID = int.Parse(Console.ReadLine());

                if (isNegativeOrZero(ID))
                {
                    Console.WriteLine("Invalid Number!");
                    continue;

                }

                break;
            }
            return ID;
        }
        



        // Menus

        static void SwitchDevelopers(DevOperations choice)
        {
            switch (choice)
            {

                case DevOperations.enAdd:
                    Console.Clear();
                    AddDeveloper();
                    ReturntoDevelpersMenu();
                    break;

                case DevOperations.enUpdate:
                    Console.Clear();
                    Developer dev = GetDeveloper();
                    if (dev != null)
                        UpdateDevModerator(dev);
                    else
                        Console.WriteLine("Not Found");

                    ReturntoDevelpersMenu();
                    break;

                case DevOperations.enDelete:
                    Console.Clear();
                    DeletDeveloper();
                    ReturntoDevelpersMenu();
                    break;
                case DevOperations.enView:
                    Console.Clear();
                    PrintAllDevelopers();
                    ReturntoDevelpersMenu();
                    break;
                case DevOperations.enAssigntoDep:
                    Console.Clear();
                    DeveloperToDepartment(true);
                    ReturntoDevelpersMenu();
                    break;
                case DevOperations.enMain:
                    Console.Clear();
                    MainMenuCompany();
                    break;
                default:
                    Console.WriteLine("Invalid!");
                    break;

            }

        }


        static void SwitchDepartments(DepOperations choice)
        {


            switch (choice)
            {

                case DepOperations.enAdd:
                    Console.Clear();
                    AddDepartment();
                    ReturntoDepartmentsMenu();
                    break;

                case DepOperations.enUpdate:
                    Console.Clear();
                    Department dep = GetDepartment();
                    if (dep != null)
                        UpdateDepModerator(dep);
                    else
                        Console.WriteLine("Not Found");

                    ReturntoDepartmentsMenu();
                    break;

                case DepOperations.enDelete:
                    Console.Clear();
                    DeletDepartmnet();
                    ReturntoDepartmentsMenu();
                    break;
                case DepOperations.enView:
                    Console.Clear();
                    PrintDepartments();
                    ReturntoDepartmentsMenu();
                    break;
                case DepOperations.enAssign:
                    Console.Clear();
                    DeveloperToDepartment(true);
                    ReturntoDepartmentsMenu();
                    break;
                case DepOperations.enRemove:
                    Console.Clear();
                    DeveloperToDepartment(false);
                    ReturntoDepartmentsMenu();
                    break;
                case DepOperations.enMain:
                    Console.Clear();
                    MainMenuCompany();
                    break;
                default:
                    Console.WriteLine("Invalid!");
                    break;

            }
        }


        static void SwitchProject(ProjOperations choice)
        {
            switch (choice)
            {

                case ProjOperations.enAdd:
                    Console.Clear();
                    AddProject();
                    ReturntoProjectsMenu();
                    break;

                case ProjOperations.enUpdate:
                    Console.Clear();
                    Project proj = GetProject();
                    if (proj != null)
                        UpdateProjectModerator(proj);
                    else
                        Console.WriteLine("Not Found");

                    ReturntoProjectsMenu();
                    break;

                case ProjOperations.enDelete:
                    Console.Clear();
                    DeletProject();
                    ReturntoProjectsMenu();
                    break;
                case ProjOperations.enView:
                    Console.Clear();
                    PrintAllProjects();
                    ReturntoProjectsMenu();
                    break;
                case ProjOperations.enAssign:
                    Console.Clear();
                    DeveloperToProject(true);
                    ReturntoProjectsMenu();
                    break;
                case ProjOperations.enRemove:
                    Console.Clear();
                    DeveloperToProject(false);
                    ReturntoProjectsMenu();
                    break;
                case ProjOperations.enMain:
                    Console.Clear();
                    MainMenuCompany();
                    break;
                default:
                    Console.WriteLine("Invalid!");
                    break;

            }
        }



        static void DevelopersMenu()
        {
            Console.Clear();

            PrintHead("Developers");

            Console.WriteLine(@"
1 - Add Developer
2 - Update Developer
3 - Delete Developer
4 - View All Developers
5 - Assign to new Department
6 - Return to Main Menu
");

            int num;

            while (true)
            {
                num = int.Parse(Console.ReadLine());

                if (!InRange(num, 1, 6))
                {
                    Console.WriteLine("Invalid Value ! \nPlease Enter again . \n");
                }
                break;
            }


            SwitchDevelopers((DevOperations)num);


   

        }

        static void DepartmentsMenu()
        {
            Console.Clear();

            PrintHead("Departments");

            Console.WriteLine(@"
1 - Add Department
2 - Update Department
3 - Delete Department
4 - View All Departments
5 - Assign Developer to Department
6 - Remove Developer from Department
7 - Return to Main Menu
");



            int num;

            while (true)
            {
                num = int.Parse(Console.ReadLine());

                if (!InRange(num, 1, 7))
                {
                    Console.WriteLine("Invalid Value ! \nPlease Enter again . \n");
                }
                break;
            }


            SwitchDepartments((DepOperations)num);



        }

        static void ProjectsMenu()
        {
            Console.Clear();

            PrintHead("Projects");

            Console.WriteLine(@"
1 - Add Project
2 - Update Project
3 - Delete Project
4 - View All Projects
5 - Assign Developer to Project
6 - Remove Developer from Project
7 - Return to Main Menu
");




            int num;

            while (true)
            {
                num = int.Parse(Console.ReadLine());

                if (!InRange(num, 1, 7))
                {
                    Console.WriteLine("Invalid Value ! \nPlease Enter again . \n");
                }
                break;
            }


            SwitchProject((ProjOperations)num);

        }





        static void UpdateDevModerator(Developer dev)
        {
            int choice;

            PrintHead("Update Choices");

            Console.WriteLine($"{1} - Update Name .");
            Console.WriteLine($"{2} - Update Salary .");
            Console.WriteLine($"{3} - Update City .");
            Console.WriteLine($"{4} - Update Max Projects Can Work .");
            Console.WriteLine($"{5} - Update ALL .");
            Console.WriteLine($"{6} - Return To Developers Menu .");


            while (true)
            {
                choice = int.Parse(Console.ReadLine());

                if (!InRange(choice, 1, 6))
                {
                    Console.WriteLine("Invalid Value ! \nPlease Enter again . \n");
                }
                break;
            }


            switch (choice)
            {
                case 1:
                    dev.SetName(EditName());
                    break;

                case 2:
                    dev.SetSalary(EditSalary());

                    break;

                case 3:
                    dev.SetCity(EditCity());

                    break;

                case 4:
                    dev.maxprojects = EditMaxNumber();
                    break;
                case 5:
                     dev.SetName(EditName());
                    dev.SetSalary(EditSalary());
                    dev.SetCity(EditCity());
                    dev.maxprojects = EditMaxNumber();
                    break;
                case 6:
                    Console.Clear();
                    DevelopersMenu();
                    break;
                default:

                    Console.WriteLine("INVALID !");
                    break;

            }

        }

        static void UpdateDepModerator(Department dep)
        {
            int choice;

            PrintHead("Update Choices");

            Console.WriteLine($"{1} - Update Name .");
            Console.WriteLine($"{2} - Update Manager ID .");
            Console.WriteLine($"{3} - Update Both .");
            Console.WriteLine($"{4} - Return To Departments Menu .");


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
                    dep.Name = EditName();
                    break;

                case 2:
                    Developer dev = GetDeveloper();
                    if (dep.ManagerID == dev.getID())
                        Console.WriteLine("Alredy Exist !");
                    else if(dep.ManagerID==0)
                    {
                        dep.ManagerID = dev.getID();
                        dep.AssignEmployee(dev.getID());
                        dev.isManager= true;
                        dev.DepartmentID = dep.ID;
                    }
                    else
                    {
                        Developer oldmanager = GetDeveloper(dep.ManagerID);
                        oldmanager.isManager = false;

                        dep.ManagerID = dev.getID();
                        dev.isManager = true;
                        dev.DepartmentID = dep.ID;
                        dep.AssignEmployee(dev.getID());
                    }

                        break;

                case 3:
                    dep.Name = EditName();
                    Developer dev2 = GetDeveloper();
                    if (dep.ManagerID == dev2.getID())
                        Console.WriteLine("Alredy Exist !");
                    else
                        dep.ManagerID = dev2.getID();

                    break;
                case 4:
                    Console.Clear();
                    DepartmentsMenu();
                    break;
                default:

                    Console.WriteLine("INVALID !");
                    break;

            }
        }

        static void UpdateProjectModerator(Project proj)
        {
            int choice;

            PrintHead("Update Choices");

            Console.WriteLine($"{1} - Update Name .");
            Console.WriteLine($"{2} - Update Max Number Of Employees .");
            Console.WriteLine($"{3} - Update Both .");
            Console.WriteLine($"{4} - Return To Projects Menu .");


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
                    proj.Name = EditName();
                    break;
                case 2:
                    proj.MaxNumberOfEmployees = EditMaxNumber();
                    break;
                case 3:
                    proj.Name = EditName();
                    proj.MaxNumberOfEmployees = EditMaxNumber();
                    break;
                case 4:
                    Console.Clear();
                    ProjectsMenu();
                    break;
                default:

                    Console.WriteLine("INVALID !");
                    break;

            }
        }





        static void ReturntoDevelpersMenu()
        {
            Console.WriteLine("Press any key to return to Developers Menu ... ");
            Console.ReadKey();
            Console.Clear();

            DevelopersMenu();
        }

        static void ReturntoDepartmentsMenu()
        {
            Console.WriteLine("Press any key to return to Departmnets Menu ... ");
            Console.ReadKey();
            Console.Clear();

            DepartmentsMenu();
        }

        static void ReturntoProjectsMenu()
        {
            Console.WriteLine("Press any key to return to Projects Menu ... ");
            Console.ReadKey();
            Console.Clear();

            ProjectsMenu();
        }


        static void ReturntoMainMenuCompany()
        {
            Console.WriteLine("Press any key to return to Main Menu ... ");
            Console.ReadKey();
            Console.Clear();

            MainMenuCompany();
        }

        static void SwitchMain(MainChoices choice)
        {
            Console.Clear();


            switch (choice)
            {
                case MainChoices.enDevelopers:
                    Console.Clear();
                    DevelopersMenu();
                    break;
                case MainChoices.enDepartments:
                    Console.Clear();
                    DepartmentsMenu();

                    break;
                case MainChoices.enProjects:
                    Console.Clear();
                    ProjectsMenu();
                    break;
                case MainChoices.enExit:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid!");
                    break;
            }


        }

        static void MainMenuCompany()
        {


            PrintHead("Main Menu");

            Console.WriteLine(@"
1 - Developers
2 - Departments
3 - Projects
4 - Exit
");

            int num;

            while (true)
            {
                num = int.Parse(Console.ReadLine());

                if (!InRange(num, 1, 4))
                {
                    Console.WriteLine("Invalid Value ! \nPlease Enter again . \n");
                }
                break;
            }
  

            SwitchMain((MainChoices)num);

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

            //   MainMenuCompany();

            #endregion

            #region Lab5
            DynamicArray<int> myArray = new DynamicArray<int>();
            myArray.Add(10);
            myArray.Add(20);
            myArray.Add(30);
            myArray.Add(40);
            myArray.Add(50);

            myArray.PrintAll();

            Console.WriteLine($"Count: {myArray.Count}");

            Console.WriteLine($"Average: {myArray.Average()}");

            #endregion
        }
    }
}
