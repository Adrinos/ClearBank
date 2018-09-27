using Xunit;

namespace ClearBank.DeveloperTest.Tests
{
    [CollectionDefinition("Payment Strategy Collection")]
    public class PaymentStrategyCollection : ICollectionFixture<PaymentSchemeContextFixture>
    {
    }
}