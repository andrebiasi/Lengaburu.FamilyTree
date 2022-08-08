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
    public class SisterInLawSearcherTests
    {
        [Fact]
        public void ShouldReturnEmptyListWhenNotFound()
        {
            var person = new Person("Bob", Gender.Male);
            var relationships = new List<Relationship>();

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindAllRelationships(It.IsAny<string>())).Returns(relationships);

            var searcher = new SisterInLawSearcher(familyRepositoryMock.Object);
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

            var searcher = new SisterInLawSearcher(familyRepositoryMock.Object);
            var results = searcher.FindAll(person);

            results.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnSistersInLawWhenFound()
        {
            var person = new Person("Bob", Gender.Male);
            var spouse = new Person("Mary", Gender.Female);
            var brother = new Person("Tom", Gender.Male);
            var sister = new Person("Lola", Gender.Female);
            var brotherOfSpouse = new Person("Sam", Gender.Male);
            var sisterOfSpouse = new Person("Bela", Gender.Female);
            var wifeOfBrother = new Person("Ashley", Gender.Female);
            var husbandOfSister = new Person("Rob", Gender.Male);

            var personsRelationships = new List<Relationship>()
            {
                new Relationship(person, RelationshipType.Spouse, spouse),
                new Relationship(person, RelationshipType.Sibling, brother),
                new Relationship(person, RelationshipType.Sibling, sister),
            };

            var spousesRelationships = new List<Relationship>()
            {
                new Relationship(spouse, RelationshipType.Sibling, brotherOfSpouse),
                new Relationship(spouse, RelationshipType.Sibling, sisterOfSpouse),
            };

            var brothersRelationships = new List<Relationship>()
            {
                new Relationship(brother, RelationshipType.Spouse, wifeOfBrother),
            };

            var sistersRelationships = new List<Relationship>()
            {
                new Relationship(sister, RelationshipType.Spouse, husbandOfSister),
            };

            var expectedResult = new List<Person>()
            {
                sisterOfSpouse,
                wifeOfBrother
            };

            var familyRepositoryMock = new Mock<IFamilyRepository>();
            familyRepositoryMock.Setup(s => s.FindAllRelationships(person.Name)).Returns(personsRelationships);
            familyRepositoryMock.Setup(s => s.FindAllRelationships(spouse.Name)).Returns(spousesRelationships);
            familyRepositoryMock.Setup(s => s.FindAllRelationships(brother.Name)).Returns(brothersRelationships);
            familyRepositoryMock.Setup(s => s.FindAllRelationships(sister.Name)).Returns(sistersRelationships);

            var searcher = new SisterInLawSearcher(familyRepositoryMock.Object);
            var results = searcher.FindAll(person);

            results.Should().BeEquivalentTo(expectedResult);
        }
    }
}