using AcmeSchool.Domain;

namespace AcmeSchool.Application
{
    public class EnrollmentPolicy
    {
        private const int MinimumAge = 18; // Only adults can enroll

        public bool CanEnroll(Student student, Course course)
        {
            if (student.Age < MinimumAge)
            {
                return false; // Student is not an adult
            }

            // Add other enrollment rules if necessary
            return true;
        }
    }
}
