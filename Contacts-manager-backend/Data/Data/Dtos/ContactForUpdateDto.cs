using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Dtos
{
    public class ContactForUpdateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public ContactType ContactType { get; set; }
    }
}
