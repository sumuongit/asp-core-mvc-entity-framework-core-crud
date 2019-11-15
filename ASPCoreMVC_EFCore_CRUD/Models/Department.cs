using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreMVC_EFCore_CRUD.Models
{
    public class Department
    {
        [Key]
        [Required(ErrorMessage ="This field is mandatory")]
        public int DepartmentId { get; set; }
        [Column(TypeName="nvarchar(50)")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
