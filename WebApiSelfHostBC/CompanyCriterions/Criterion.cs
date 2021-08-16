using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiSelfHostBC.CompanyCriterions
{
    public class Criterion
    {
        public string Keyword { set; get; }
        public byte EstablishmentYearFrom { set; get; }
        public byte EstablishmentYearTo     { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EmployeeDateOfBirthFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public int[] EmployeeJobTitles { get; set; }
    }
}
