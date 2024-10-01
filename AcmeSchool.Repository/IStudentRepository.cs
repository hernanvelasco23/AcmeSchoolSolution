using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Repository
{
    public interface IStudentRepository
    {
        Student GetById(Guid studentId);
        void AddStudent(Student student);
    }
}
