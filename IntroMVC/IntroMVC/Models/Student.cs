using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntroMVC.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Please fill your name")]
        [StringLength(50,ErrorMessage ="Name nust not excced 50 character")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$",ErrorMessage ="Id Must follow XX-XXXXX-X")]
        public string Id { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}