using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Domain
{
    public class Course
    {
        public Guid CourseId { get; private set; }
        public string Name { get; private set; }
        public Money RegistrationFee { get; private set; }
        public CoursePeriod Period { get; private set; }
        private readonly List<Student> _enrolledStudents;
        public IReadOnlyCollection<Student> EnrolledStudents => _enrolledStudents.AsReadOnly();
        public int MaximumStudents { get; private set; }

        public Course(string name, Money registrationFee, CoursePeriod period, int maximumStudents = 30)
        {
            CourseId = Guid.NewGuid(); // Assign a unique ID to the course
            Name = name;
            RegistrationFee = registrationFee;
            Period = period;
            MaximumStudents = maximumStudents;
            _enrolledStudents = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (_enrolledStudents.Count >= MaximumStudents)
                throw new InvalidOperationException("Course is full.");

            _enrolledStudents.Add(student);
        }
    }
}
