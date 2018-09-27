using System;
using ClearBank.DeveloperTest.Strategies;
using ClearBank.DeveloperTest.Types;
using Shouldly;
using Xunit;

namespace ClearBank.DeveloperTest.Tests
{
    public class StrategiesFixtureTest : IDisposable
    {
        public PaymentSchemeContext Sut { get; set; }

        public StrategiesFixtureTest()
        {
            Sut = new PaymentSchemeContext();
        }

        [Fact]
        public void BacsStrategyTest()
        {
            var account = new Account()
            {
                AccountNumber = "1",
                Balance = 100.00m,
                Status = AccountStatus.Live,
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };

            var request = new MakePaymentRequest()
            {
                Amount = 50.00m,
                DebtorAccountNumber = "1",
                CreditorAccountNumber = "2",
                PaymentDate = new DateTime(),
                PaymentScheme = PaymentScheme.Bacs
            };

            var result = Sut.ValidatePayment(account, request);

            result.ShouldBe(true);
        }

        [Fact]
        public void FasterPaymentStrategyTest()
        {
            var account = new Account()
            {
                AccountNumber = "1",
                Balance = 100.00m,
                Status = AccountStatus.Live,
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments
            };

            var request = new MakePaymentRequest()
            {
                Amount = 50.00m,
                DebtorAccountNumber = "1",
                CreditorAccountNumber = "2",
                PaymentDate = new DateTime(),
                PaymentScheme = PaymentScheme.FasterPayments
            };

            var result = Sut.ValidatePayment(account, request);

            result.ShouldBe(true);
        }

        [Fact]
        public void ChapsStrategyTest()
        {
            var account = new Account()
            {
                AccountNumber = "1",
                Balance = 100.00m,
                Status = AccountStatus.Live,
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps
            };

            var request = new MakePaymentRequest()
            {
                Amount = 50.00m,
                DebtorAccountNumber = "1",
                CreditorAccountNumber = "2",
                PaymentDate = new DateTime(),
                PaymentScheme = PaymentScheme.Chaps
            };

            var result = Sut.ValidatePayment(account, request);

            result.ShouldBe(true);
        }

        public void Dispose()
        {
            
        }
    }
}