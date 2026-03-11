using EntityFramework_Connection.Data;
using EntityFramework_Connection.Models;

var context = new AppDbContext();

var emp = new Employee
{
    Name = "Raj",
    Salary = 50000
};

context.Employees.Add(emp);
context.SaveChanges();

Console.WriteLine("Employee inserted successfully");