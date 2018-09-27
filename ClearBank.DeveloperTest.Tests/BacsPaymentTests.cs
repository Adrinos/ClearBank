using System;
using ClearBank.DeveloperTest.Tests.Fixture;
using ClearBank.DeveloperTest.Types;
using Shouldly;
using Xunit;

namespace ClearBank.DeveloperTest.Tests
{
    [Collection("Payment Strategy Collection")]
    public class BacsPaymentTests
    {
        private readonly PaymentSchemeContextFixture _fixture;

        public BacsPaymentTests(PaymentSchemeContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void BacsPaymentShouldReturnTrue()
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

            var result = _fixture.Sut.ValidatePayment(account, request);

            result.ShouldBe(true);
        }

        [Fact]
        public void BacsPaymentShouldFailIfThereIsNoAccount()
        {
            var account = new Account();

            var request = new MakePaymentRequest()
            {
                Amount = 50.00m,
                DebtorAccountNumber = "1",
                CreditorAccountNumber = "2",
                PaymentDate = new DateTime(),
                PaymentScheme = PaymentScheme.Bacs
            };

            var result = _fixture.Sut.ValidatePayment(account, request);

            result.ShouldBe(false);
        }

        [Fact]
        public void BacsPaymentShoudlFailIfBacsFlagIsNotSet()
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
                PaymentScheme = PaymentScheme.FasterPayments
            };

            var result = _fixture.Sut.ValidatePayment(account, request);

            result.ShouldBe(false);
        }
    }
}
