using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Company
    {
        public int CompanyId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Address { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
