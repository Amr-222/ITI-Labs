using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI
{
    internal class Employee
    {

        int ID;
        string Name;
        double Salary;
        DateTime HiringDate;
        string City;

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


    }
}
