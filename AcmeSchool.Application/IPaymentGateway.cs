using AcmeSchool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Application
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(Money amount);
    }
}
