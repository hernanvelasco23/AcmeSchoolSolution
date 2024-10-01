using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();

        public Student GetById(Guid studentId)
        {
            return _students.FirstOrDefault(s => s.StudentId == studentId);
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
    }
}
