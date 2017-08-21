using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceBreakDown.Models
{
    public class Person
    {
        public virtual Income income { get; set; }
        public virtual List<Bill> bill { get; set; }
    }

    public class Income
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Where do you work?")]
        public string name { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^(?!0*[.,]0*$|[.,]0*$|0*$)\d+[,.]?\d{0,2}$", ErrorMessage = "Sorry, not valid")]
        [Display(Name = "How much do you make per week?")]
        public decimal amount { get; set; }
    }

    public class Bill
    {
        public string name { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^-?(?:0|[1-9]\d{0,2}(?:,?\d{3})*)(?:\.\d+)?$", ErrorMessage = "Sorry, not valid")]
        [Display(Name = "How much do you make per month?")]
        public decimal amount { get; set; }
    }
}