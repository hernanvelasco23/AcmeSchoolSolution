using AcmeSchool.Domain;

namespace AcmeSchool.Application.Enrollment
{
    public class EnrollmentPolicy
    {
        private const int MinimumAge = 18; // Only > 18 can enroll

        public bool CanEnroll(Student student, Course course)
        {
            if (student.Age < MinimumAge)
            {
                return false;
            }

            return true;
        }
    }
}
