using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_Connection.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("EmployeeName", TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }  // C# 11+ 'required' fixes CS8618

        [Column("AnnualSalary", TypeName = "decimal(18,2)")]
        [Range(0, int.MaxValue, ErrorMessage = "Salary must be positive")]
        public decimal Salary { get; set; }  // Changed to decimal for money
    }
}
