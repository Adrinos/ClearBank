using System;
using ClearBank.DeveloperTest.Types;
using Shouldly;
using Xunit;

namespace ClearBank.DeveloperTest.Tests
{
    [Collection("Payment Strategy Collection")]
    public class FasterPaymentTests
    {
        private readonly PaymentSchemeContextFixture _fixture;

        public FasterPaymentTests(PaymentSchemeContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void FasterPaymentShouldReturnTrue()
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

            var result = _fixture.Sut.ValidatePayment(account, request);

            result.ShouldBe(true);
        }

        [Fact]
        public void FasterPaymentShouldFailIfThereIsNoAccount()
        {
            var account = new Account();

            var request = new MakePaymentRequest()
            {
                Amount = 50.00m,
                DebtorAccountNumber = "1",
                CreditorAccountNumber = "2",
                PaymentDate = new DateTime(),
                PaymentScheme = PaymentScheme.FasterPayments
            };

            var result = _fixture.Sut.ValidatePayment(account, request);

            result.ShouldBe(false);
        }

        [Fact]
        public void FasterPaymentShoudlFailIfBacsFlagIsNotSet()
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
                PaymentScheme = PaymentScheme.Chaps
            };

            var result = _fixture.Sut.ValidatePayment(account, request);

            result.ShouldBe(false);
        }

        [Fact]
        public void FasterPaymentShouldFailIfBalanceIsLowerThanAmount()
        {
            var account = new Account()
            {
                AccountNumber = "1",
                Balance = 25.00m,
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

            var result = _fixture.Sut.ValidatePayment(account, request);

            result.ShouldBe(false);
        }
    }
}