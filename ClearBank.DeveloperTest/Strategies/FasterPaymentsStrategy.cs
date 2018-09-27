using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Strategies
{
    class FasterPaymentsStrategy : IPaymentSchemeStrategy
    {
        public bool ValidatePayment(Account account, MakePaymentRequest request)
        {
            if (account == null)
            {
                return false;
            }
            if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
            {
                return false;
            }
            if (account.Balance < request.Amount)
            {
                return false;
            }
            return true;
        }
    }
}