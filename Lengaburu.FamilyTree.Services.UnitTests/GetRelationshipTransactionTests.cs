using FluentAssertions;
using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using Lengaburu.FamilyTree.Services.Factories;
using Lengaburu.FamilyTree.Services.Transactions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;

namespace Lengaburu.FamilyTree.Services.UnitTests
{
    public class GetRelationshipTransactionTests
    {
        [Fact]
        public void ShouldReturnPersonNotFoundWhenNameIsNull()
        {
            string name = null;
            Person person = null;
            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindPersonByName(name)).Returns(person);
            var searcherFactoryMock = new Mock<ISearcherFactory>();

            var getRelationshipTransaction = new GetRelationshipTransaction(familyRepositoryMock.Object, searcherFactoryMock.Object, name, null);
            var result = getRelationshipTransaction.Execute();

            result.Should().Be("PERSON_NOT_FOUND");
        }

        [Fact]
        public void ShouldReturnPersonNotFoundWhenNotFound()
        {
            string name = "Bob";
            Person person = null;
            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindPersonByName(name)).Returns(person);
            var searcherFactoryMock = new Mock<ISearcherFactory>();

            var getRelationshipTransaction = new GetRelationshipTransaction(familyRepositoryMock.Object, searcherFactoryMock.Object, name, null);
            var result = getRelationshipTransaction.Execute();

            result.Should().Be("PERSON_NOT_FOUND");
        }

        [Fact]
        public void ShouldReturnNoneWhenNoRelationshipsFound()
        {
            string name = "Bob";
            var person = new Person(name, Gender.Male);
            var relationship = "Son";

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindPersonByName(name)).Returns(person);

            var searcherMock = new Mock<IRelationshipSearcher>();
            searcherMock.Setup(s => s.FindAll(person)).Returns(new List<Person>());

            var searcherFactoryMock = new Mock<ISearcherFactory>();
            searcherFactoryMock.Setup(s => s.CreateSearcher(relationship)).Returns(searcherMock.Object);

            var getRelationshipTransaction = new GetRelationshipTransaction(familyRepositoryMock.Object, searcherFactoryMock.Object, name, relationship);
            var result = getRelationshipTransaction.Execute();

            result.Should().Be("NONE");
        }

        [Fact]
        public void ShouldReturnRelativesWhenRelationshipsFound()
        {
            string name = "Bob";
            var person = new Person(name, Gender.Male);
            var relationship = "Son";
            var sons = new List<Person>()
            {
                new Person("Mike", Gender.Male),
                new Person("John", Gender.Male)
            };

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindPersonByName(name)).Returns(person);

            var searcherMock = new Mock<IRelationshipSearcher>();
            searcherMock.Setup(s => s.FindAll(person)).Returns(sons);

            var searcherFactoryMock = new Mock<ISearcherFactory>();
            searcherFactoryMock.Setup(s => s.CreateSearcher(relationship)).Returns(searcherMock.Object);

            var getRelationshipTransaction = new GetRelationshipTransaction(familyRepositoryMock.Object, searcherFactoryMock.Object, name, relationship);
            var result = getRelationshipTransaction.Execute();

            result.Should().Be("Mike John");
        }
    }
}
