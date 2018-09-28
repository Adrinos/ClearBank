using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class BalanceService : IBalanceService
    {
        public void DeductAmount(MakePaymentRequest request, Account account)
        {
            account.Balance -= request.Amount;
        }
    }
}