using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Repository
{
    public interface ICourseRepository
    {
        Course GetById(Guid courseId);
        IEnumerable<Course> GetAllCourses();
        void AddCourse(Course course);
    }
}
