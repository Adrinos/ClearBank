using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Strategies
{
    class ChapsPaymentStrategy : IPaymentSchemeStrategy
    {
        public bool ValidatePayment(Account account, MakePaymentRequest request)
        {
            if (account == null)
            {
                return false;
            }
            if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
            {
                return false;
            }
            if (account.Status != AccountStatus.Live)
            {
                return false;
            }
            return true;
        }
    }
}