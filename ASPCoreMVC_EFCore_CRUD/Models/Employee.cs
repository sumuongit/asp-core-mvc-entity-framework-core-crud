using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreMVC_EFCore_CRUD.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "This field is mandatory")]
        public String FullName { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Designation { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Location { get; set; }
        
        public Department Department { get; set; }
    }
}
