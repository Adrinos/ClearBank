using ClearBank.DeveloperTest.Tests.Fixture;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Collection
{
    [CollectionDefinition("Payment Strategy Collection")]
    public class PaymentStrategyCollection : ICollectionFixture<PaymentSchemeContextFixture>
    {
    }
}