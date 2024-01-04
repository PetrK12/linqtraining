using System;

namespace LinqBasics.CMS
{
    public class StudentLinqBasic
    {
        public StudentLinqBasic(int studentId, string firstName, string lastName, int courseId)
        {
            this.StudentId = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CourseId = courseId;
        }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseId { get; set; }
    }

    public class EngineeringStudent : StudentLinqBasic
    {
        public EngineeringStudent(int studentId, string firstName, string lastName, int courseId)
            : base(studentId, firstName, lastName, courseId)
        {          
        }
    }
    public class MedicalStudent : StudentLinqBasic
    {
        public MedicalStudent(int studentId, string firstName, string lastName, int courseId)
            : base(studentId, firstName, lastName, courseId)
        {
        }
    }
}
