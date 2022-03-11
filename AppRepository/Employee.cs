using System;
using System.ComponentModel.DataAnnotations;

namespace AppRepository
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Mobile { get; set; }
    }
}
