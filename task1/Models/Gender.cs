using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace task1.Models
{
    public class Gender
    {
        public int Id{ get; set; }
        public String GenderType { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}