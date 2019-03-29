using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="plz fill this filed")]
        [MinLength(3,ErrorMessage ="the min char > 3")]
        [MaxLength(9,ErrorMessage ="the max char < 10")]
        public String CusName { get; set; }
        [Required(ErrorMessage = "plz fill this filed")]
        public String CusMobile { get; set; }
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}