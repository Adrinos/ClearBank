using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interfaces
{
    public interface IPaymentSchemeStrategy
    {
        bool ValidatePayment(Account account, MakePaymentRequest request);
    }
}