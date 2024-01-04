using System;
using System.ComponentModel.DataAnnotations;
namespace LinqBasics.CMS
{
    public class StudentEntity
    {
        public StudentEntity(int studentId, string firstName, string lastName,
            int courseId)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = LastName;
            CourseId = courseId;
        }
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}
