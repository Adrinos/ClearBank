using System;
using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using Shouldly;
using Xunit;

namespace ClearBank.DeveloperTest.Tests
{
    public class PaymentServiceTests
    {
        private Mock<IPaymentSchemeContext> PaymentSchemeContext { get; set; }
        private Mock<IDataStoreHelper> DataStoreHelperMock { get; set; }

        public PaymentServiceTests()
        {
            PaymentSchemeContext = new Mock<IPaymentSchemeContext>();
            DataStoreHelperMock = new Mock<IDataStoreHelper>();
        }

        [Fact]
        public void BacsPaymentIsSuccessful()
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

            DataStoreHelperMock.Setup(x => x.GetDataStoreType().GetAccount("1")).Returns(account);
            PaymentSchemeContext.Setup(p => p.ValidatePayment(account, request)).Returns(true);

            var sut = new PaymentService(DataStoreHelperMock.Object, PaymentSchemeContext.Object);

            var result = sut.MakePayment(request);

            result.Success.ShouldBe(true);
        }

        [Fact]
        public void FasterPaymentIsSuccessful()
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

            DataStoreHelperMock.Setup(x => x.GetDataStoreType().GetAccount("1")).Returns(account);
            PaymentSchemeContext.Setup(p => p.ValidatePayment(account, request)).Returns(true);

            var sut = new PaymentService(DataStoreHelperMock.Object, PaymentSchemeContext.Object);

            var result = sut.MakePayment(request);

            result.Success.ShouldBe(true);
        }

        [Fact]
        public void ChapsPaymentIsSuccessful()
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

            DataStoreHelperMock.Setup(x => x.GetDataStoreType().GetAccount("1")).Returns(account);
            PaymentSchemeContext.Setup(p => p.ValidatePayment(account, request)).Returns(true);

            var sut = new PaymentService(DataStoreHelperMock.Object, PaymentSchemeContext.Object);

            var result = sut.MakePayment(request);

            result.Success.ShouldBe(true);
        }
    }
}