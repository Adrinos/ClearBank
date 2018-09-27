using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interfaces
{
    public interface IPaymentSchemeContext
    {
        bool ValidatePayment(Account account, MakePaymentRequest request);
    }
}