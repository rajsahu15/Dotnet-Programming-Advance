using EntityFramework_Connection.Data;
using EntityFramework_Connection.Models;
using System;

var context = new AppDbContext();
/*  
 *  Data Insertion
 *  
var emp = new Employee
{
    Name = "Sita",
    Salary = 100000
};

context.Employees.Add(emp);
context.SaveChanges();

Console.WriteLine("Employee inserted successfully");

*/
/*
 * Data Retrieve
 * 
var employees = context.Employees.ToList();
foreach (var employee in employees) { 
          Console.WriteLine(employee.Name +" = "+employee.Salary);
 }
*/
/* 
 * Data Update
 * 
var emp = context.Employees.FirstOrDefault(e => e.Name == "Raj");
emp.Salary = 90000;
context.SaveChanges();
var employees = context.Employees.ToList();
foreach (var employee in employees)
{
    Console.WriteLine(employee.Name + " = " + employee.Salary);
}
*/

/* Deleting the Data from Database

var emp = context.Employees.FirstOrDefault(e => e.Name == "Raj");
context.Remove(emp);
context.SaveChanges();
var employees = context.Employees.ToList();
foreach (var employee in employees)
{
    Console.WriteLine(employee.Name + " = " + employee.Salary);
}
*/
/*
var employees = context.Employees
                       .Where(e => e.Salary > 190000)
                       .ToList();
foreach (var employee in employees)
{
    Console.WriteLine(employee.Name + " = " + employee.Salary );
}
int total = context.Employees.Count();
Console.WriteLine(total);
*/

var emp = new Employee
{
    Name = "karn",
    Salary = 10000
};

context.Employees.Add(emp);
context.SaveChanges();
Console.WriteLine("Record Inserted");


var emp2 = context.Employees.ToList();
foreach (var item in emp2) { 
   Console.WriteLine(item.Name +"= "+item.Salary);
}