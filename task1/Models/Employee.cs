using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "plz fill this filed")]
        [MinLength(3, ErrorMessage = "the min char > 3")]
        [MaxLength(9, ErrorMessage = "the max char < 10")]
        public String EmpName { get; set; }
        [Required(ErrorMessage = "plz fill this filed")]
        
        public String Passwrd { get; set; }

        [Compare("Passwrd",ErrorMessage ="passwrd Not Mached")]
        public String Confpasswrd { get; set; }

        [Required(ErrorMessage = "plz fill this filed")]
        
        public String Email { get; set; }

       

    }
}