using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreRestfulApiDemo.Entities
{
    public class Employee
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
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