using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Domain
{
    public class Student
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Guid StudentId { get; private set; }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            StudentId = Guid.NewGuid();
        }
        public void UpdateDetails(string name, int age)
        {
            if (age < 18)
                throw new InvalidOperationException("Student must be an adult.");
            Name = name;
            Age = age;
        }
    }
}
