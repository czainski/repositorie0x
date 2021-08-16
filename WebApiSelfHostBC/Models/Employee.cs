using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSelfHostBC.Models
{
    public class Employee : EntityBase
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string LastName { get; set; }
        //
        [DataType(DataType.Date)]
        [Index]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Index]
        public DateTime? DateOfBirth { get; set; }
        //
        [Required]
        [Index]
        public JobTitle JobTitle { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
