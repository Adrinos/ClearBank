using System.Collections.Generic;
using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Strategies
{
    public class PaymentSchemeContext : IPaymentSchemeContext
    {
        private static readonly Dictionary<PaymentScheme, IPaymentSchemeStrategy> Strategies = 
            new Dictionary<PaymentScheme, IPaymentSchemeStrategy>();

        public PaymentSchemeContext()
        {
            Strategies.Add(PaymentScheme.Bacs, new BacsPaymentStrategy());
            Strategies.Add(PaymentScheme.FasterPayments, new FasterPaymentsStrategy());
            Strategies.Add(PaymentScheme.Chaps, new ChapsPaymentStrategy());
        }

        public bool ValidatePayment(Account account, MakePaymentRequest request)
        {
            return Strategies[request.PaymentScheme].ValidatePayment(account, request);
        }
    }
}