using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Application
{
    public class EnrollmentService
    {
        private readonly IPaymentGateway _paymentGateway;
        private readonly EnrollmentPolicy _enrollmentPolicy;

        public EnrollmentService(IPaymentGateway paymentGateway, EnrollmentPolicy enrollmentPolicy)
        {
            _paymentGateway = paymentGateway;
            _enrollmentPolicy = enrollmentPolicy;
        }

        public void EnrollStudentInCourse(Student student, Course course)
        {
            if (!_enrollmentPolicy.CanEnroll(student, course))
            {
                throw new InvalidOperationException("Student cannot be enrolled.");
            }

            if (!_paymentGateway.ProcessPayment(course.RegistrationFee))
            {
                throw new InvalidOperationException("Payment failed.");
            }

            course.AddStudent(student);
        }
    }

}
