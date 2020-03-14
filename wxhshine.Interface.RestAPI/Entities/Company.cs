using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Entities
{
    public class Company
    {
        [Key]
        [Column(TypeName = "varchar"),MaxLength(32),MinLength(32)]
        public string Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required,MaxLength(500)]
        public string Introduction { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
