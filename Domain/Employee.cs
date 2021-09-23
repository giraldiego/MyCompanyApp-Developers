using System;

namespace Domain
{
    public class Employee : Person
    {
        public int Salary { get; set; }

        public Manager Manager { get; set; }

    }
}
