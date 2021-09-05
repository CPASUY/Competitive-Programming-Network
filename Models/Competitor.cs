using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Rcp.Models
{
    public class Competitor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "ConfirmPwd")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm password does not match")]
        public string ConfirmPwd { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
