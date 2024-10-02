using AcmeSchool.Application.Enrollment.Strategy;
using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Application.Enrollment
{
    public class EnrollmentService
    {
        private readonly IEnumerable<IEnrollmentStrategy> _strategies;

        public EnrollmentService(IEnumerable<IEnrollmentStrategy> strategies)
        {
            _strategies = strategies;
        }

        public void EnrollStudentInCourse(Student student, Course course)
        {
            foreach (var strategy in _strategies)
            {
                strategy.Execute(student, course);
            }

            course.AddStudent(student);
        }
    }

}
