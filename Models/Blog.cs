using System;
using System.ComponentModel.DataAnnotations;

namespace DentistApp.Models
{
    public class Blog
    {
        [Key]
        public int Id { get;set; }
        [Required]
        [Display(Name = "Blog-Title")]
        public string Title { get;set; }
        [Required]
        [Display(Name = "Date-Created")]
        public DateTime Date { get;set; }
        [Required]
        public string Para { get;set; }
    }
}