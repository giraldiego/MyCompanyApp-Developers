using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

    }
}
