using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly List<Course> _courses = new List<Course>();

        public Course GetById(Guid courseId)
        {
            return _courses.FirstOrDefault(c => c.CourseId == courseId);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courses;
        }

        public void AddCourse(Course course)
        {
            _courses.Add(course);
        }
    }
}
