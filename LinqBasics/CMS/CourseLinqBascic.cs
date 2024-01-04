using System;

namespace LinqBasics
{
    public class CourseLinqBasic
    {
        public CourseLinqBasic(int courseId, string courseName)
        {
            this.CourseId = courseId;
            this.CourseName = courseName;
        }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
