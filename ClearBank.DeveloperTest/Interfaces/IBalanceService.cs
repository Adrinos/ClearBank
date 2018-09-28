using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IBalanceService
    {
        void DeductAmount(MakePaymentRequest request, Account account);
    }
}