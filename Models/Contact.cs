using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Contact
    {

        [Required]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is Required"), MinLength(8)]
        [Phone]
        public string Phone { get; set; }
        [Phone]
        public string Landline { get; set; }

        public string Website { get; set; }
        public string Address { get; set; }
    }
}
