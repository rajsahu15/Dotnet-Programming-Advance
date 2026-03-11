using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;

string serverName = "localhost\\SQLEXPRESS";
string databaseName = "PracticeModule";

string connectionString = "Server=" + serverName + ";Database=" + databaseName + ";Trusted_Connection=True;TrustServerCertificate=True;";

using (SqlConnection con = new SqlConnection(connectionString))
{
    try
    {
        con.Open();
        Console.WriteLine("Connection Established Successfully to " + databaseName);

        string sqlQuery = "SELECT * FROM EMP";
        SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, con);
        DataTable empTable = new DataTable();
        adapter.Fill(empTable);

        var employees = from emp in empTable.AsEnumerable()
                        select new
                        {
                            ID = emp.Field<int>("EMPLOYEE_ID"),
                            FullName = emp.Field<string>("FIRST_NAME") + " " + emp.Field<string>("LAST_NAME"),
                            Email = emp.Field<string>("EMAIL"),
                            HireDate = emp.Field<DateTime>("HIRE_DATE"),
                            Salary = emp.Field<decimal?>("SALARY")
                        };

    

        Console.WriteLine("\n--- High Earning Employees (LINQ Results) ---");
        foreach (var e in employees)
        {
            Console.WriteLine("ID: " + e.ID +
                              " | Name: " + e.FullName +
                              " | Hired: " + e.HireDate.ToShortDateString() +
                              " | Salary: $" + e.Salary);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}