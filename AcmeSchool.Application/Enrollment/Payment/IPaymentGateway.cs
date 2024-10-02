using AcmeSchool.Domain;


namespace AcmeSchool.Application.Enrollment.Payment
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(Money amount);
    }
}
