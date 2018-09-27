using System;
using ClearBank.DeveloperTest.Tests.Fixture;
using ClearBank.DeveloperTest.Types;
using Shouldly;
using Xunit;

namespace ClearBank.DeveloperTest.Tests
{
    [Collection("Payment Strategy Collection")]
    public class ChapsPaymentTests
    {
        private readonly PaymentSchemeContextFixture _fixture;

        public ChapsPaymentTests(PaymentSchemeContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ChapsPaymentShouldReturnTrue()
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

            var result = _fixture.Sut.ValidatePayment(account, request);

            result.ShouldBe(true);
        }

        [Fact]
        public void ChapsPaymentShouldFailIfThereIsNoAccount()
        {
            var account = new Account();

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
        public void ChapsPaymentShouldFailIfTheAccountIsNotLive()
        {
            var account = new Account()
            {
                AccountNumber = "1",
                Balance = 100.00m,
                Status = AccountStatus.Disabled,
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

            var result = _fixture.Sut.ValidatePayment(account, request);

            result.ShouldBe(false);
        }
    }
}