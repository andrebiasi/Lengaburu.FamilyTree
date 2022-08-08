using FluentAssertions;
using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Services.Factories;
using Lengaburu.FamilyTree.Services.Transactions;
using Moq;
using System;
using Xunit;

namespace Lengaburu.FamilyTree.Services.UnitTests
{
    public class TransactionFactoryTests
    {
        [Fact]
        public void ShouldCreateInvalidTransactionWhenNoArgsProvided()
        {
            var args = new string[] { };
            var familyRepositoryMock = new Mock<IFamilyRepository>();
            var searcherFactoryMock = new Mock<ISearcherFactory>();

            var transactionFactory = new TransactionFactory(familyRepositoryMock.Object, searcherFactoryMock.Object);
            var transaction = transactionFactory.CreateTransaction(args);

            transaction.Should().BeOfType(typeof(InvalidTransaction));
        }

        [Fact]
        public void ShouldCreateInvalidTransactionWhenNoCommandIsNotDefined()
        {
            var args = new string[] { "command" };
            var familyRepositoryMock = new Mock<IFamilyRepository>();
            var searcherFactoryMock = new Mock<ISearcherFactory>();

            var transactionFactory = new TransactionFactory(familyRepositoryMock.Object, searcherFactoryMock.Object);
            var transaction = transactionFactory.CreateTransaction(args);

            transaction.Should().BeOfType(typeof(InvalidTransaction));
        }

        [Fact]
        public void ShouldCreateInvalidTransactionWhenAddChildArgsAreNot4()
        {
            var args = new string[] { "add_child", "arg1" };
            var familyRepositoryMock = new Mock<IFamilyRepository>();
            var searcherFactoryMock = new Mock<ISearcherFactory>();

            var transactionFactory = new TransactionFactory(familyRepositoryMock.Object, searcherFactoryMock.Object);
            var transaction = transactionFactory.CreateTransaction(args);

            transaction.Should().BeOfType(typeof(InvalidTransaction));
        }

        [Fact]
        public void ShouldCreateInvalidTransactionWhenGetRelationshipArgsAreNot3()
        {
            var args = new string[] { "get_relationship", "arg1" };
            var familyRepositoryMock = new Mock<IFamilyRepository>();
            var searcherFactoryMock = new Mock<ISearcherFactory>();

            var transactionFactory = new TransactionFactory(familyRepositoryMock.Object, searcherFactoryMock.Object);
            var transaction = transactionFactory.CreateTransaction(args);

            transaction.Should().BeOfType(typeof(InvalidTransaction));
        }

        [Fact]
        public void ShouldCreateAddChildTransaction()
        {
            var args = new string[] { "add_child", "mother", "child", "gender" };
            var familyRepositoryMock = new Mock<IFamilyRepository>();
            var searcherFactoryMock = new Mock<ISearcherFactory>();

            var transactionFactory = new TransactionFactory(familyRepositoryMock.Object, searcherFactoryMock.Object);
            var transaction = transactionFactory.CreateTransaction(args);

            transaction.Should().BeOfType(typeof(AddChildTransaction));
        }

        [Fact]
        public void ShouldCreateGetRelationshipTransaction()
        {
            var args = new string[] { "get_relationship", "name", "relationship" };
            var familyRepositoryMock = new Mock<IFamilyRepository>();
            var searcherFactoryMock = new Mock<ISearcherFactory>();

            var transactionFactory = new TransactionFactory(familyRepositoryMock.Object, searcherFactoryMock.Object);
            var transaction = transactionFactory.CreateTransaction(args);

            transaction.Should().BeOfType(typeof(GetRelationshipTransaction));
        }
    }
}
