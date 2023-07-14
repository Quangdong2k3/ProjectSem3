using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models
{
    public class EmployeeModel
    {
        public int employee_id { get; set; }
        [DisplayName("Employee Name")]
        [DataType(DataType.Text)]
        public string employee_name { get; set; }
        
        public string address { get; set; }
        
        public string phone { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        [Required(ErrorMessage = "Email is not empty???!")]
        public string email { get; set; }
        [DisplayName("ID Job")]
        

        public Nullable<int> job_title_id { get; set; }
        [DisplayName("ID Department")]
        public Nullable<int> department_id { get; set; }
        [DisplayName("Username")]

        public string username { get; set; }
        [Required(ErrorMessage = "Password is not empty???!")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string department_name { get; set; }
        public string job_title_name { get; set; }
        
        public bool remember { get; set; }
    }
}