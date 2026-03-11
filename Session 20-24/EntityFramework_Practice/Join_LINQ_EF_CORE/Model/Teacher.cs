using Join_LINQ_EF_CORE.Model.EntityFramework_Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Connection.Models
{
    namespace EntityFramework_Connection.Models
    {
        public class Teacher
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }

            public int DepartmentId { get; set; }
            public Department Department { get; set; }
        }
    }
}
