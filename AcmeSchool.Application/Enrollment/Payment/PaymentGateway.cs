using AcmeSchool.Domain;

namespace AcmeSchool.Application.Enrollment.Payment
{
    public class PaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(Money amount)
        {
            //let's assume that any payment under $100 is successful. Any amount >= 100 payment fails
            if (amount.Amount < 100m)
            {
                return true;
            }

            return false;
        }
    }

}
