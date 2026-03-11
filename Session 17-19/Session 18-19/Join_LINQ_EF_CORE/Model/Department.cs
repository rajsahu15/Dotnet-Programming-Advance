using EntityFramework_Connection.Models;
using EntityFramework_Connection.Models.EntityFramework_Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Join_LINQ_EF_CORE.Model
{
    namespace EntityFramework_Connection.Models
    {
        public class Department
        {
            public int Id { get; set; }
            public string DepartmentName { get; set; }

            public List<Teacher> Teacher { get; set; }
        }
    }
}
