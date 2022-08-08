using FluentAssertions;
using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using Lengaburu.FamilyTree.Services.Transactions;
using Moq;
using System.Collections.Generic;
using Xunit;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;

namespace Lengaburu.FamilyTree.Services.UnitTests
{
    public class AddChildTransactionTests
    {
        [Fact]
        public void ShouldReturnChildAdditionFailedWhenMothersNameIsNull()
        {
            var familyRepositoryMock = new Mock<IFamilyRepository>();

            var transaction = new AddChildTransaction(familyRepositoryMock.Object, null, null, null);
            var result = transaction.Execute();

            result.Should().Be("CHILD_ADDITION_FAILED");
        }

        [Fact]
        public void ShouldReturnChildAdditionFailedWhenChildsNameIsNull()
        {
            var mothersName = "Mary";
            var familyRepositoryMock = new Mock<IFamilyRepository>();

            var transaction = new AddChildTransaction(familyRepositoryMock.Object, mothersName, null, null);
            var result = transaction.Execute();

            result.Should().Be("CHILD_ADDITION_FAILED");
        }

        [Fact]
        public void ShouldReturnChildAdditionFailedWhenInvalidGender()
        {
            var mothersName = "Mary";
            var childsName = "Bob";
            var gender = "foo";
            var familyRepositoryMock = new Mock<IFamilyRepository>();

            var transaction = new AddChildTransaction(familyRepositoryMock.Object, mothersName, childsName, gender);
            var result = transaction.Execute();

            result.Should().Be("CHILD_ADDITION_FAILED");
        }

        [Fact]
        public void ShouldReturnChildAdditionFailedWhenChildAlreadyExists()
        {
            var childsName = "Bob";
            var childsGender = "Male";
            var mothersName = "Mary";
            var child = new Person(childsName, Gender.Male);

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindPersonByName(childsName)).Returns(child);

            var transaction = new AddChildTransaction(familyRepositoryMock.Object, mothersName, childsName, childsGender);
            var result = transaction.Execute();

            result.Should().Be("CHILD_ADDITION_FAILED");
        }

        [Fact]
        public void ShouldReturnPersonNotFoundWhenMotherNotFound()
        {
            var childsName = "Bob";
            var childsGender = "Male";
            var mothersName = "Mary";
            var familyRepositoryMock = new Mock<IFamilyRepository>();

            var transaction = new AddChildTransaction(familyRepositoryMock.Object, mothersName, childsName, childsGender);
            var result = transaction.Execute();

            result.Should().Be("PERSON_NOT_FOUND");
        }

        [Fact]
        public void ShouldReturnChildAdditionFailedWhenMotherIsNotFemale()
        {
            var childsName = "Bob";
            var childsGender = "Male";
            var mothersName = "Mary";
            var mother = new Person(mothersName, Gender.Male);
            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindPersonByName(mothersName)).Returns(mother);

            var transaction = new AddChildTransaction(familyRepositoryMock.Object, mothersName, childsName, childsGender);
            var result = transaction.Execute();

            result.Should().Be("CHILD_ADDITION_FAILED");
        }

        [Fact]
        public void ShouldReturnChildAdditionSucceeded()
        {
            var childsName = "Bob";
            var childsGender = "Male";
            var mothersName = "Mary";
            var mother = new Person(mothersName, Gender.Female);
            var mothersRelationships = new List<Relationship>();

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindPersonByName(mothersName)).Returns(mother);
            familyRepositoryMock.Setup(s => s.FindAllRelationships(mothersName)).Returns(mothersRelationships);

            var transaction = new AddChildTransaction(familyRepositoryMock.Object, mothersName, childsName, childsGender);
            var result = transaction.Execute();

            result.Should().Be("CHILD_ADDITION_SUCCEEDED");
        }
    }
}