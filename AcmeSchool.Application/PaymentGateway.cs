using AcmeSchool.Domain;

namespace AcmeSchool.Application
{
    public class PaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(Money amount)
        {
            // For simplicity, let's assume that any payment under $100 is successful.
            if (amount.Amount < 100m)
            {
                return true;
            }

            return false; // For any amount equal to or greater than $100, the payment fails.
        }
    }

}
