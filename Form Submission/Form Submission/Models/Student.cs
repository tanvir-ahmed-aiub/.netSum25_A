using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Form_Submission.Models
{
    public class Student
    {
        [Required]
        [Range(1,40)]
        public int? Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Address Is Needed")]
        [StringLength(1000,MinimumLength =10)]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string[] Hobbies { get; set; }
        [Required]
        public DateTime Dob { get; set; }
    }
}