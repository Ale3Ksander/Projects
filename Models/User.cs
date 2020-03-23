using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaCore.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "FirstName not specified")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName not specified")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email not specified"), EmailAddress]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
