using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Application.Enrollment.Strategy
{
    public interface IEnrollmentStrategy
    {
        void Execute(Student student, Course course);
    }
}
