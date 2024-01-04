using System;
using System.ComponentModel.DataAnnotations;

namespace LinqBasics
{
    public class CourseEntity
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
    }
}
