using EntityFramework_Connection.Models.EntityFramework_Connection.Models;
using Join_LINQ_EF_CORE.Data;
using Join_LINQ_EF_CORE.Model;
using Join_LINQ_EF_CORE.Model.EntityFramework_Connection.Models;

using var context = new AppDbContext();
/*
// Insert Departments
var d1 = new Department { DepartmentName = "Computer Science" };
var d2 = new Department { DepartmentName = "Mathematics" };

context.Department.AddRange(d1, d2);
context.SaveChanges();

// Insert Teachers
var t1 = new Teacher
{
    Name = "Raj",
    Salary = 50000,
    DepartmentId = d1.Id
};

var t2 = new Teacher
{
    Name = "Amit",
    Salary = 45000,
    DepartmentId = d2.Id
};

context.Teacher.AddRange(t1, t2);
context.SaveChanges();

Console.WriteLine("Data Inserted Successfully");

*/
var Teacher = context.Teacher.ToList();

var dept = context.Department.ToList();

foreach (var item in Teacher) { 
     Console.WriteLine(item.Name+" = "+item.Salary+" ,"+item.DepartmentId);

}
foreach (var item in dept) {
    Console.WriteLine(item.DepartmentName+" ,"+item.Id);
}





var result = context.Teacher
    .Join(context.Department,
        t => t.DepartmentId,
        d => d.Id,
        (t, d) => new
        {
            TeacherName = t.Name,
            DepartmentName = d.DepartmentName
        })
    .ToList();

foreach (var item in result)
{
    Console.WriteLine(item.TeacherName + " - " + item.DepartmentName);
}