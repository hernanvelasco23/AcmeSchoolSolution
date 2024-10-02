using AcmeSchool.Application.Enrollment;
using AcmeSchool.Application.Enrollment.Payment;
using AcmeSchool.Application.Enrollment.Strategy;
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

        public EnrollmentServiceTests()
        {
            _paymentGatewayMock = new Mock<IPaymentGateway>();
        }

        [Fact]
        public void EnrollStudentInCourse_ShouldSucceed_WhenStudentIsValidAndPaymentSucceeds()
        {
            // Arrange
            var student = new Student("Jane Doe", 22);
            var coursePeriod = new CoursePeriod(DateTime.Now, DateTime.Now.AddMonths(1));
            var course = new Course("Physics 101", new Money(200m, "USD"), coursePeriod);

            // Mock de la política de inscripción que siempre permite la inscripción
            var mockEnrollmentPolicy = new Mock<IEnrollmentStrategy>();
            mockEnrollmentPolicy
                .Setup(ep => ep.Execute(student, course))
                .Verifiable();

            // Mock del PaymentGateway que simula un pago exitoso
            _paymentGatewayMock.Setup(pg => pg.ProcessPayment(It.IsAny<Money>())).Returns(true);

            var paymentStrategy = new PaymentStrategy(_paymentGatewayMock.Object);

            // Creamos el servicio de inscripción con ambas estrategias
            var enrollmentService = new EnrollmentService(new List<IEnrollmentStrategy>
            {
                mockEnrollmentPolicy.Object,
                paymentStrategy
            });

            // Act
            enrollmentService.EnrollStudentInCourse(student, course);

            // Assert
            Assert.Contains(student, course.EnrolledStudents); // Verifica que el estudiante haya sido añadido al curso
            mockEnrollmentPolicy.Verify(ep => ep.Execute(student, course), Times.Once);
        }

        [Fact]
        public void EnrollStudent_ShouldThrowException_WhenPaymentFails()
        {

            var student = new Student("Jane Doe", 22);
            var coursePeriod = new CoursePeriod(DateTime.Now, DateTime.Now.AddMonths(1));
            var course = new Course("Physics 101", new Money(200m, "USD"), coursePeriod);

            _paymentGatewayMock.Setup(pg => pg.ProcessPayment(It.IsAny<Money>())).Returns(false);

            var paymentStrategy = new PaymentStrategy(_paymentGatewayMock.Object);


            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => paymentStrategy.Execute(student, course));
            Assert.Equal("Payment failed.", exception.Message);
        }

        [Fact]
        public void EnrollStudent_ShouldThrowException_WhenStudent_Uder_Age()
        {

            var student = new Student("Jane Doe", 16);
            var coursePeriod = new CoursePeriod(DateTime.Now, DateTime.Now.AddMonths(1));
            var course = new Course("History 101", new Money(100m, "USD"), coursePeriod);

            // Arrange
            var enrollmentPolicy = new EnrollmentPolicyStrategy(new EnrollmentPolicy());

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => enrollmentPolicy.Execute(student, course));
            Assert.Equal("Student cannot be enrolled.", exception.Message);
        }

    }
}
