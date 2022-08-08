using FluentAssertions;
using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using Moq;
using System.Collections.Generic;
using Xunit;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;
using static Lengaburu.FamilyTree.Core.Enums.RelationshipEnum;

namespace Lengaburu.FamilyTree.Services.UnitTests
{
    public class SonSearcherTests
    {
        [Fact]
        public void ShouldReturnEmptyListWhenNotFound()
        {
            var person = new Person("Bob", Gender.Male);
            var relationships = new List<Relationship>();

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindAllRelationships(It.IsAny<string>())).Returns(relationships);

            var searcher = new SonSearcher(familyRepositoryMock.Object);
            var results = searcher.FindAll(person);

            results.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnEmptyListWhenGivenNull()
        {
            Person person = null;
            var relationships = new List<Relationship>();

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindAllRelationships(It.IsAny<string>())).Returns(relationships);

            var searcher = new SonSearcher(familyRepositoryMock.Object);
            var results = searcher.FindAll(person);

            results.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnSistersInLawWhenFound()
        {
            var person = new Person("Bob", Gender.Male);
            var son = new Person("Mike", Gender.Male);
            var daughter = new Person("Sofia", Gender.Female);

            var personsRelationships = new List<Relationship>()
            {
                new Relationship(person, RelationshipType.Parent, son),
                new Relationship(person, RelationshipType.Parent, daughter),
            };

            var expectedResult = new List<Person>()
            {
                son,
            };

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindAllRelationships(person.Name)).Returns(personsRelationships);

            var searcher = new SonSearcher(familyRepositoryMock.Object);
            var results = searcher.FindAll(person);

            results.Should().BeEquivalentTo(expectedResult);
        }
    }
}