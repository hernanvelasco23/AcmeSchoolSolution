using AcmeSchool.Application;
using AcmeSchool.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Test.Unit
{
    public class EnrollmentServiceTests
    {
        private readonly Mock<IPaymentGateway> _paymentGatewayMock;
        private readonly EnrollmentPolicy _enrollmentPolicy;
        private readonly EnrollmentService _enrollmentService;

        public EnrollmentServiceTests()
        {
            _paymentGatewayMock = new Mock<IPaymentGateway>();
            _enrollmentPolicy = new EnrollmentPolicy();
            _enrollmentService = new EnrollmentService(_paymentGatewayMock.Object, _enrollmentPolicy);
        }

        [Fact]
        public void EnrollStudentInCourse_ValidPayment_EnrollsStudent()
        {
            // Arrange
            var student = new Student("John Doe", 20);
            var coursePeriod = new CoursePeriod(DateTime.Now, DateTime.Now.AddMonths(1));
            var course = new Course("Math 101", new Money(100m, "USD"), coursePeriod);

            _paymentGatewayMock.Setup(pg => pg.ProcessPayment(It.IsAny<Money>())).Returns(true);

            // Act
            _enrollmentService.EnrollStudentInCourse(student, course);

            // Assert
            Assert.Contains(student, course.EnrolledStudents);
        }

        [Fact]
        public void EnrollStudentInCourse_FailedPayment_ThrowsException()
        {
            // Arrange
            var student = new Student("Jane Doe", 22);
            var coursePeriod = new CoursePeriod(DateTime.Now, DateTime.Now.AddMonths(1));
            var course = new Course("Physics 101", new Money(200m, "USD"), coursePeriod);

            _paymentGatewayMock.Setup(pg => pg.ProcessPayment(It.IsAny<Money>())).Returns(false);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _enrollmentService.EnrollStudentInCourse(student, course));
        }

        [Fact]
        public void EnrollStudentInCourse_StudentUnderage_ThrowsException()
        {
            // Arrange
            var student = new Student("John Doe", 16); // Underage student
            var coursePeriod = new CoursePeriod(DateTime.Now, DateTime.Now.AddMonths(1));
            var course = new Course("History 101", new Money(100m, "USD"), coursePeriod);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _enrollmentService.EnrollStudentInCourse(student, course));
        }
    }
}
