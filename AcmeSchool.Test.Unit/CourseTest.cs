using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Test.Unit
{
    public class CourseTest
    {

        private readonly Money registrationFee;
        private readonly CoursePeriod coursePeriod;
        public CourseTest() 
        {
            registrationFee = new Money(100, "USD");
            coursePeriod = new CoursePeriod(DateTime.Now, DateTime.Now.AddMonths(3));
        }

        [Fact]
        public void AddStudent_ShouldAddStudent_WhenUnderMaximumCapacity()
        {
            // Arrange
            var course = new Course("Math", registrationFee, coursePeriod, 20);
            var student = new Student("John Doe", 20);

            // Act
            course.AddStudent(student);

            // Assert
            Assert.Contains(student, course.EnrolledStudents);
        }

        [Fact]
        public void AddStudent_ShouldThrowInvalidOperationException_WhenCourseIsFull()
        {
            // Arrange
            var course = new Course("Math", registrationFee, coursePeriod, 1); // Máximo 1 estudiante
            var student1 = new Student("John Doe", 20);
            var student2 = new Student("Jane Smith", 22);
            course.AddStudent(student1); // Agregar el primer estudiante

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => course.AddStudent(student2));
            Assert.Equal("Course is full.", exception.Message);
        }

        [Fact]
        public void AddStudent_ShouldThrowArgumentNullException_WhenStudentIsNull()
        {
            // Arrange
            var course = new Course("Math", registrationFee, coursePeriod, 10);

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => course.AddStudent(null));
            Assert.Equal("student", exception.ParamName); 
        }
    }
}
