using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreRestfulApiDemo.Entities
{
    public class Employee
    {
        [Required,MaxLength(36),MinLength(36)]
        public string Id { get; set; }
        [Required,MaxLength(36),MinLength(36)]
        public string CompanyId { get; set; }
        [Required,MaxLength(10)]
        public string EmployeeNo { get; set; }
        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        [Required,MaxLength(50)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Company Company { get; set; }
    }

    public enum Gender
    {
        男 = 1,
        女 = 2,
    }
}