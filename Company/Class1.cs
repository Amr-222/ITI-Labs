namespace Company
{
    interface IBonus
    {
       public double getBonus();
    }



    public abstract class Employee 
    {

        int ID;
        string Name;
        double Salary;
        DateTime HiringDate;
        string City;
       public bool isManager { set; get; } = false;

        public Employee()
        {

        }

        public Employee(int _ID, string _Name, double _Salary, string _City)
        {
            ID = _ID;
            Name = _Name;
            Salary = _Salary;
            City = _City;
            HiringDate = DateTime.Now;

        }

        public int getID()
        {
            return ID;
        }
        public string getName()
        {
            return Name;
        }

        public double getSalary()
        {
            return Salary;
        }

        public DateTime getHiringDate()
        {
            return HiringDate;
        }

        public string getCity()
        {
            return City;
        }

        public void SetID(int _ID)
        {
            ID = _ID;
        }
        public void SetSalary(double _Salary)
        {
            Salary = _Salary;
        }

        public void SetName(string _Name)
        {
            Name = _Name;
        }

        public void SetCity(string _City)
        {
            City = _City;
        }

        public void SetHiringDate(DateTime _HiringDate)
        {
            HiringDate = _HiringDate;
        }


      public  abstract double GetTotalSalary();
        
    }



    public class Developer : Employee, IBonus
    {

        public List<int> ProjectIDs = new List<int>();
        public int maxprojects { get; set; } = 5;
       public int DepartmentID {  get; set; }

        static int NextID = 1;

        static public int GetNextID()
        {
            return NextID;
        }

        static public void IncrementID()
        {
            NextID++;
        }

        public Developer()
        {
        }


        public Developer(int _ID, string _Name, double _Salary, string _City, int maxprojects = 5) : base(_ID, _Name, _Salary, _City)
        {
            this.maxprojects = maxprojects;
        }





     

        public bool AssignProject(int projectId)
        {
            if (ProjectIDs.Contains(projectId))
            {
                //  Console.WriteLine("Project already exist.");
                return false;

            }
            else if (ProjectIDs.Count < maxprojects)
            {
                ProjectIDs.Add(projectId);
                return true;
            }
            else
            {
                Console.WriteLine("Developer has max projects.");
                return false;

            }
        }

        public bool RemoveProject(int projectId)
        {

            if (ProjectIDs.Contains(projectId))
            {
                ProjectIDs.Remove(projectId);
                //Console.WriteLine($"Project {projectId} removed.");
                return true;
            }
            else
            {
                //Console.WriteLine($"Project {projectId} not found in this list.");
                return false;
            }
        }



        public double getBonus() => isManager ? 0.5 : 0.3;        

        public override double GetTotalSalary()
        {
            return (getBonus() * getSalary() + getSalary());
        }



    }



    public class Project
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int MaxNumberOfEmployees { get; set; }

        public List<int> EmployeeIDs = new List<int>();

        static int NextID = 1;


        public Project()
        {
        }

        public Project(int iD, string name, int maxNumberOfEmployees)
        {
            ID = iD;
            Name = name;
            MaxNumberOfEmployees = maxNumberOfEmployees;
        }


        static public int GetNextID()
        {
            return NextID;

        }

        static public void IncrementID()
        {
            NextID++;
        }

        public void AssignEmployee(int empId)
        {
            if (EmployeeIDs.Contains(empId))
            {
                Console.WriteLine("Employee already exist.");

            }
            else if (EmployeeIDs.Count < MaxNumberOfEmployees)
            {

                EmployeeIDs.Add(empId);
            }
            else
            {
                Console.WriteLine("Project has max Emplyees.");
            }
           
        }

        public void RemoveEmployee(int empId)
        {

            if (EmployeeIDs.Contains(empId))
            {
                EmployeeIDs.Remove(empId);
                Console.WriteLine($"Employee {empId} removed.");
            }
            else
            {
                Console.WriteLine($"Employee {empId} not found in this list.");
            }
        }
    }





    public class Department
    {
        public int ID { set; get; }
        public string Name { set; get; }

        public List<int> EmployeeIDs = new List<int>();

        public int ManagerID { get; set; } = 0;


        static int NextID = 1;

        static public int GetNextID()
        {
            return NextID;
        }

        static public void IncrementID()
        {
            NextID++;
        }



        public bool AssignEmployee(int empId)
        {


            if (!EmployeeIDs.Contains(empId))
            {
                EmployeeIDs.Add(empId);
                Console.WriteLine($"Employee {empId} Added Successfuly.");
                return true;
            }
            else
            {
                Console.WriteLine($"Employee {empId} already exist.");
                return false;
            }
        }

        public bool RemoveEmployee(int empId)
        {
            if (EmployeeIDs.Contains(empId))
            {
                EmployeeIDs.Remove(empId);
                Console.WriteLine($"Employee {empId} removed Successfully.");
                return true;
            }
            else
            {
                Console.WriteLine($"Employee {empId} not found in this list.");
                return false ;
            }
        }


      
    }
}




