using FluentAssertions;
using Lengaburu.FamilyTree.Services.Transactions;
using Xunit;

namespace Lengaburu.FamilyTree.Services.UnitTests
{
    public class InvalidTransactionTests
    {
        [Fact]
        public void ShouldReturnInvalidTransaction()
        {
            var transaction = new InvalidTransaction();
            var result = transaction.Execute();

            result.Should().Be("INVALID_TRANSACTION");
        }
    }
}