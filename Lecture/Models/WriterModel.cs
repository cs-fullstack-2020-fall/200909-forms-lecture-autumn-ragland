using System.ComponentModel.DataAnnotations;

namespace Lecture.Models
{
    public class WriterModel 
    {
        [Key]
        public int id{get;set;}
        [Required]
        [Display(Name = "First Name")]
        public string fName{get;set;}
        [Display(Name = "Last Name")]
        public string lName{get;set;}
        [Range(15,115)]
        [Display(Name = "Age")]
        public int age{get;set;}
        [Display(Name = "Published")]
        public bool isPublished{get;set;}
    }
}