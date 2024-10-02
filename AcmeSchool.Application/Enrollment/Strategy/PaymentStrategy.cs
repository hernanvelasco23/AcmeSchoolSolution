using AcmeSchool.Application.Enrollment.Payment;
using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Application.Enrollment.Strategy
{
    public class PaymentStrategy : IEnrollmentStrategy
    {
        private readonly IPaymentGateway _paymentGateway;

        public PaymentStrategy(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }

        public void Execute(Student student, Course course)
        {
            if (!_paymentGateway.ProcessPayment(course.RegistrationFee))
            {
                throw new InvalidOperationException("Payment failed.");
            }
        }
    }
}
