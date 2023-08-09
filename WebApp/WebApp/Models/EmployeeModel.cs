using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}