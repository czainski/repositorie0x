using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Company : EntityBase
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        //[Index(IsUnique = true)]

        public string Name { get; set; }
        //[Index]
        public int?    EstablishmentYear { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
