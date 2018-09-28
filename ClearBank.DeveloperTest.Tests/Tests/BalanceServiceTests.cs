using System.Collections.Generic;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Shouldly;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Tests
{
    public class BalanceServiceTests
    {
        private readonly BalanceService _fixture;

        public BalanceServiceTests()
        { 
            _fixture = new BalanceService();
        }

        public static IEnumerable<object[]> GetAccountsWithDifferentBalancesAndDifferentPaymentsWithDifferentAmounts()
        {
            yield return new object[] { new MakePaymentRequest{Amount = 50m}, new Account {Balance = 100m}, 50m};
            yield return new object[] { new MakePaymentRequest{Amount = 50m}, new Account {Balance = 10m}, -40m};
            yield return new object[] { new MakePaymentRequest{Amount = 50m}, new Account {Balance = 50m}, 0m}; 
           // yield return new object[] { new MakePaymentRequest{Amount = -50m}, new Account {Balance = 100m}, 50m}; <-- Bug/EdgeCase
        }

        [Theory]
        [MemberData(nameof(GetAccountsWithDifferentBalancesAndDifferentPaymentsWithDifferentAmounts))]
        
        public void DeductAmountTests(MakePaymentRequest request, Account account, decimal expected)
        {
            _fixture.DeductAmount(request, account);

            account.Balance.ShouldBe(expected);
        }
    }
}