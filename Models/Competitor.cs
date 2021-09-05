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
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPwd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
