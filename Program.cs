// See https://aka.ms/new-console-template for more information
using Practise_5_Dedok;

Console.WriteLine("Task_1: ");
var employeeManager = new EmployeeManager();

var emp1 = new Employee("Ivan Ivanov", "Manager", 1200m, "ivanov@company.com");
var emp2 = new Employee("Petro Petrov", "Developer", 2000m, "petrov@company.com");
var emp3 = new Employee("Olha Koval", "Designer", 1500m, "koval@company.com");

employeeManager.AddEmployee(emp1);
employeeManager.AddEmployee(emp2);
employeeManager.AddEmployee(emp3);

Console.WriteLine("All employees:");
employeeManager.ListEmployees();

Console.WriteLine("\nSorted by salary:");
var sortedBySalary = employeeManager.SortEmployees("salary");
foreach (var employee in sortedBySalary)
{
    Console.WriteLine(employee);
}

Console.WriteLine("\nSearching for 'Petro':");
var foundEmployees = employeeManager.SearchEmployees("Petro");
foreach (var employee in foundEmployees)
{
    Console.WriteLine(employee);
}

Console.WriteLine("\nUpdating Petro's position:");
employeeManager.UpdateEmployee("petrov@company.com", new Employee("Petro Petrov", "Team Lead", 2500m, "petrov@company.com"));
employeeManager.ListEmployees();

Console.WriteLine("\nRemoving Olha:");
employeeManager.RemoveEmployee("koval@company.com");
employeeManager.ListEmployees();
Console.WriteLine();
Console.ReadKey();
Console.WriteLine("Task_3: ");
CafeQueue cafe = new CafeQueue(3); 
cafe.StartSimulation();