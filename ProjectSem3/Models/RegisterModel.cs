using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models
{
    public class RegisterModel
    {
        public int employee_id { get; set; }
        [DisplayName("Employee Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Employee Name is not empty???!")]

        public string employee_name { get; set; }
        [DisplayName("Address")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Address is not empty???!")]
        public string address { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        [Required(ErrorMessage = "Email is not empty???!")]
        public string email { get; set; }
        [DisplayName("ID Job")]
        [Required]


        public Nullable<int> job_title_id { get; set; }
       
        [DisplayName("Username")]

        public string username { get; set; }
        [Required(ErrorMessage = "Password is not empty???!")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
            
        [Compare("password")]
        [DataType(DataType.Password)]
        public string repassword { get; set; }
        [Required(ErrorMessage = "You must accepted terms")]

        public bool agreeTerms { get; set; }
    }
}