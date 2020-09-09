using System.ComponentModel.DataAnnotations;

namespace Lecture.Models
{
    public class WriterModel 
    {
        [Key]
        public int id{get;set;}
        [Required]
        public string fName{get;set;}
        public string lName{get;set;}
        [Range(15,115)]
        public int age{get;set;}
        public bool isPublished{get;set;}
    }
}