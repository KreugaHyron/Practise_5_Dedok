using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise_5_Dedok
{
    public class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string CorporateEmail { get; set; }
        public Employee(string fullName, string position, decimal salary, string corporateEmail)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            CorporateEmail = corporateEmail;
        }
        public override string ToString()
        {
            return $"Name: {FullName}, Position: {Position}, Salary: {Salary:C}, Email: {CorporateEmail}";
        }
    }
    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public bool RemoveEmployee(string email)
        {
            var employee = employees.FirstOrDefault(e => e.CorporateEmail == email);
            if (employee != null)
            {
                employees.Remove(employee);
                return true;
            }
            return false;
        }
        public bool UpdateEmployee(string email, Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.CorporateEmail == email);
            if (employee != null)
            {
                employee.FullName = updatedEmployee.FullName;
                employee.Position = updatedEmployee.Position;
                employee.Salary = updatedEmployee.Salary;
                employee.CorporateEmail = updatedEmployee.CorporateEmail;
                return true;
            }
            return false;
        }
        public List<Employee> SearchEmployees(string searchTerm)
        {
            return employees
                .Where(e => e.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            e.CorporateEmail.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public List<Employee> SortEmployees(string sortBy, bool ascending = true)
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    return ascending
                        ? employees.OrderBy(e => e.FullName).ToList()
                        : employees.OrderByDescending(e => e.FullName).ToList();
                case "position":
                    return ascending
                        ? employees.OrderBy(e => e.Position).ToList()
                        : employees.OrderByDescending(e => e.Position).ToList();
                case "salary":
                    return ascending
                        ? employees.OrderBy(e => e.Salary).ToList()
                        : employees.OrderByDescending(e => e.Salary).ToList();
                default:
                    return employees;
            }
        }
        public void ListEmployees()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
