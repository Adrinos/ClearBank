using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Interfaces;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IDataStoreHelper _dataStoreHelper;
        private readonly IPaymentSchemeContext _payPaymentSchemeContext;

        public PaymentService(IDataStoreHelper dataStoreHelper, IPaymentSchemeContext payPaymentSchemeContext)
        {
            _dataStoreHelper = dataStoreHelper;
            _payPaymentSchemeContext = payPaymentSchemeContext;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var accountDataStore = _dataStoreHelper.GetDataStoreType();

            var account = accountDataStore.GetAccount(request.DebtorAccountNumber);

            var result = new MakePaymentResult {Success = _payPaymentSchemeContext.ValidatePayment(account, request)};

            if (result.Success)
            {
                DeductAmount(request, account, accountDataStore);
            }
            return result;
        }

        private void DeductAmount(MakePaymentRequest request, Account account, IDataStore accountDataStore)
        {
            account.Balance -= request.Amount;

            accountDataStore.UpdateAccount(account);
        }
    }
}