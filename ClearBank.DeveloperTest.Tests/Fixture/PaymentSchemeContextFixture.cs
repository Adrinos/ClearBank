using System;
using ClearBank.DeveloperTest.Strategies;

namespace ClearBank.DeveloperTest.Tests.Fixture
{
    public class PaymentSchemeContextFixture : IDisposable
    {
        public PaymentSchemeContext Sut { get; private set; }

        public PaymentSchemeContextFixture()
        {
            Sut = new PaymentSchemeContext();
        }

        public void Dispose()
        {
            Sut = null;
        }
    }
}