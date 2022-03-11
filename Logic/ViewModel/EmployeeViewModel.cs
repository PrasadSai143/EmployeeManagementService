using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppService.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Mobile { get; set; }
    }
}
