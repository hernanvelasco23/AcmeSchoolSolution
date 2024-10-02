using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Application.Enrollment.Strategy
{
    public class EnrollmentPolicyStrategy : IEnrollmentStrategy
    {
        private readonly EnrollmentPolicy _enrollmentPolicy;

        public EnrollmentPolicyStrategy(EnrollmentPolicy enrollmentPolicy)
        {
            _enrollmentPolicy = enrollmentPolicy;
        }

        public void Execute(Student student, Course course)
        {
            if (!_enrollmentPolicy.CanEnroll(student, course))
            {
                throw new InvalidOperationException("Student cannot be enrolled.");
            }
        }
    }
}
