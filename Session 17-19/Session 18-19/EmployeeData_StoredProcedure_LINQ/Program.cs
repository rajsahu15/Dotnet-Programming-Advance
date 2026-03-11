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

        // Call stored procedure
        using (SqlCommand cmd = new SqlCommand("GetAllEmployeeDeptDetails", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable empDeptTable = new DataTable();
            adapter.Fill(empDeptTable);

            // LINQ projection
            var employeesWithDept = empDeptTable.AsEnumerable()
                .Select(row => new
                {
                    ID = row.Field<int>("EMPLOYEE_ID"),
                    FullName = row.Field<string>("FIRST_NAME") + " " + row.Field<string>("LAST_NAME"),
                    Email = row.Field<string>("EMAIL"),
                    Phone = row.Field<string>("PHONE_NUMBER"),
                    Job = row.Field<string>("JOB_ID"),
                    Salary = row.Field<decimal?>("SALARY"),
                    Commission = row.Field<decimal?>("COMMISSION_PCT"),
                    ManagerID = row.Field<int?>("MANAGER_ID"),
                    DeptID = row.Field<short>("DEPARTMENT_ID"),
                    DeptName = row.Field<string>("DNAME"),
                    Location = row.Field<string>("LOC"),
                    HireDate = row.Field<DateTime>("HIRE_DATE")
                });

            // Display ALL employee + dept details
            Console.WriteLine("\n--- Complete Employee & Department Details ---");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID  | Name                    | Email        | Phone        | Job     | Salary  | Comm  | Mgr | Dept     | Location  | Hire Date ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (var emp in employeesWithDept)
            {
                Console.WriteLine(emp.ID + "  | " +
                                  emp.FullName + "            | " +
                                  emp.Email + "     | " +
                                  (emp.Phone ?? "N/A") + "    | " +
                                  emp.Job + "    | " +
                                  (emp.Salary ?? 0) + "  | " +
                                  (emp.Commission ?? 0) + "  | " +
                                  (emp.ManagerID ?? 0) + " | " +
                                  emp.DeptName + "  | " +
                                  emp.Location + "     | " +
                                  emp.HireDate.ToString("yyyy-MM-dd"));
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}
