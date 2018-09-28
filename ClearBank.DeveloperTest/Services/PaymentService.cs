using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Interfaces;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IDataStoreHelper _dataStoreHelper;
        private readonly IPaymentSchemeContext _payPaymentSchemeContext;
        private readonly IBalanceService _balanceService;

        public PaymentService(IDataStoreHelper dataStoreHelper, IPaymentSchemeContext payPaymentSchemeContext, IBalanceService balanceService)
        {
            _dataStoreHelper = dataStoreHelper;
            _payPaymentSchemeContext = payPaymentSchemeContext;
            _balanceService = balanceService;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var accountDataStore = _dataStoreHelper.GetDataStoreType();

            var account = accountDataStore.GetAccount(request.DebtorAccountNumber);

            var result = new MakePaymentResult {Success = _payPaymentSchemeContext.ValidatePayment(account, request)};

            if (result.Success)
            {
                _balanceService.DeductAmount(request, account);

                accountDataStore.UpdateAccount(account);
            }
            return result;
        }
    }
}