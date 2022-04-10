using System;
using System.ComponentModel.DataAnnotations;

namespace DentistApp.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get;set; }
        [Required]
        [Display(Name = "Patient-Name")]
        public string Name { get;set; }
        [Required]
        // [DataType(DataType.EmailAddress)]
        public string Email { get;set; }
        [Required]
        public int Age { get;set; }
        [Required]
        public DateTime Date { get;set; }
        [Required]
        public string Issue { get;set; }
    }
}