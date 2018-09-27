using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Strategies
{
    public class BacsPaymentStrategy : IPaymentSchemeStrategy
    {
        public bool ValidatePayment(Account account, MakePaymentRequest request)
        {
            if (account == null)
            {
                return false;
            }
            if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
            {
                return false;
            }
            return true;
        }
    }
}