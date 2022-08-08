using FluentAssertions;
using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;
using static Lengaburu.FamilyTree.Core.Enums.RelationshipEnum;

namespace Lengaburu.FamilyTree.Services.UnitTests
{
    public class PaternalAuntSearcherTests
    {
        [Fact]
        public void ShouldReturnEmptyListWhenNotFound()
        {
            var person = new Person("Bob", Gender.Male);
            var relationships = new List<Relationship>();

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindAllRelationships(It.IsAny<string>())).Returns(relationships);

            var searcher = new PaternalAuntSearcher(familyRepositoryMock.Object);
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

            var searcher = new PaternalAuntSearcher(familyRepositoryMock.Object);
            var results = searcher.FindAll(person);

            results.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnPaternalAuntsWhenFound()
        {
            var person = new Person("Bob", Gender.Male);
            var father = new Person("John", Gender.Male);
            var mother = new Person("Mary", Gender.Female);
            var uncle = new Person("Billy", Gender.Male);
            var aunt = new Person("Ashley", Gender.Female);

            var personsRelationships = new List<Relationship>()
            {
                new Relationship(person, RelationshipType.Child, father),
                new Relationship(person, RelationshipType.Child, mother),
            };

            var fathersRelationships = new List<Relationship>()
            {
                new Relationship(father, RelationshipType.Sibling, uncle),
                new Relationship(father, RelationshipType.Sibling, aunt),
            };

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindAllRelationships(person.Name)).Returns(personsRelationships);
            familyRepositoryMock.Setup(s => s.FindAllRelationships(father.Name)).Returns(fathersRelationships);

            var searcher = new PaternalAuntSearcher(familyRepositoryMock.Object);
            var results = searcher.FindAll(person);

            results.Count().Should().Be(1);
            results.Should().ContainEquivalentOf(aunt);
        }
    }
}